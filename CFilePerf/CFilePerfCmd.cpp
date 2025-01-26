
#define  _CRT_SECURE_NO_WARNINGS

#include "CFilePerfCmd.h"

#include <windows.h>
#include <ctype.h>
#include <string.h>
#include <math.h>
#include <stdlib.h>
#include <time.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <stdio.h>

#include <string>

#define stricmp _stricmp

const unsigned long KB = (1 << 10);
const unsigned long MB = (1 << 20);
const unsigned long GB = (1 << 30);

// ----------------------------------------------------------------------------
static unsigned long DecodeSize(const char* numStr)
{
    char* endPtr = 0;
    unsigned long n = strtoul(numStr, &endPtr, 10);
    while (isspace(*endPtr))
        endPtr++;

    if (stricmp(endPtr, "KB") == 0)
        n *= KB;
    else if (stricmp(endPtr, "MB") == 0)
        n *= MB;
    else if (stricmp(endPtr, "GB") == 0)
        n *= GB;

    return n;
}

// ----------------------------------------------------------------------------
template <typename T>
inline T NextRecordSize(T value)
{
    return value * 2;
}

// ----------------------------------------------------------------------------
static size_t CkSum(size_t ckSum, const unsigned char* buffer, size_t len)
{
    while (len-- > 0)
        ckSum += *buffer++;

    return ckSum;
}

// ----------------------------------------------------------------------------
static void SetMsg(CFilePerfCmd::RwStats* pRwStats, const char* pMsg, int msgLen)
{
    pRwStats->message = pMsg;
    OutputDebugStringA(pMsg);
}

// ----------------------------------------------------------------------------
bool OpenTestFile(CFilePerfCmd& filePerfCmd)
{
    CFilePerfCmd::RwStats& rwStats = filePerfCmd.m_rwStats;
    DWORD file_flags = 0
        | FILE_FLAG_NO_BUFFERING
        | FILE_FLAG_WRITE_THROUGH       // by-pass cache
        | FILE_FLAG_SEQUENTIAL_SCAN     // hint sequencial access.
        //  | FILE_FLAG_RANDOM_ACCESS
        ;

    if (filePerfCmd.m_hFile != INVALID_HANDLE_VALUE)
        CloseHandle(filePerfCmd.m_hFile);

    filePerfCmd.m_hFile = CreateFileA(filePerfCmd.m_filename.c_str() 
        , GENERIC_READ | GENERIC_WRITE 
        , FILE_SHARE_READ| FILE_SHARE_WRITE 
        , 0 
        , CREATE_ALWAYS 
        , 0
        | FILE_ATTRIBUTE_NORMAL 
        // | FILE_FLAG_DELETE_ON_CLOSE
        | file_flags
        , 0);
        
    if (filePerfCmd.m_hFile == INVALID_HANDLE_VALUE)
    {
        DWORD error = GetLastError();
        char msg[MAX_PATH];
        int msgLen = _snprintf(msg, sizeof(msg), "Failed to open file, error=%d\n", error);
        SetMsg(&rwStats, msg, msgLen+1);
        return false;
    }
    return true;
}

// ----------------------------------------------------------------------------
bool MakeTestFile(CFilePerfCmd& filePerfCmd)
{
    CFilePerfCmd::RwStats& rwStats = filePerfCmd.m_rwStats;
    LARGE_INTEGER filePos, fileEndSize;
    fileEndSize.QuadPart = rwStats.fileKbSize * KB;

    // Check if file already exists and is large enough
    struct __stat64 statInfo;
    if (_stat64(filePerfCmd.m_filename.c_str(), &statInfo) == 0 &&
        statInfo.st_size >= fileEndSize.QuadPart)
        return true;

    // Open file for creation.
    if (OpenTestFile(filePerfCmd) == false)
        return false;

    // TODO - Get sector size , see GetFreeDiskSpace function
    // Align buffer on sector boundary, assume 512
    static char sBuffer[MB*8+4096];
    DWORD bytesPerSector = 512;
    char* buffer = (char*)((ULONG_PTR)(sBuffer + bytesPerSector-1) & ~((ULONG_PTR)(bytesPerSector-1)));


  
    filePos.QuadPart = 0;

    DWORD startTick, endTick;
    double seconds;
    DWORD  ioSize  = 1;
    int    recNum = 0;
    size_t ckSum1 = 0;
    size_t wrtSize = MB * 8;
                
    OutputDebugStringA("Start Creating Test File\n");
    startTick = GetTickCount();
    while (filePos.QuadPart < fileEndSize.QuadPart 
        && ioSize != 0 
        && filePerfCmd.m_rwRunStat != CFilePerfCmd::eStop)
    {
        if (wrtSize > size_t(fileEndSize.QuadPart - filePos.QuadPart))
            ioSize = DWORD(wrtSize = size_t(fileEndSize.QuadPart - filePos.QuadPart));

        if (wrtSize > 0)
        {
            memset(buffer, recNum++, wrtSize);
            ckSum1 = CkSum(ckSum1, (const unsigned char*)buffer, wrtSize);
            WriteFile(filePerfCmd.m_hFile, buffer, (DWORD)wrtSize, &ioSize, 0);
            filePos.QuadPart += ioSize;
            rwStats.makeFilePercent = int(filePos.QuadPart * 100 / fileEndSize.QuadPart);
        }
    }
    endTick = GetTickCount();
    seconds = (endTick - startTick) / 1000.0;

    int  msgLen;
    char msg[MAX_PATH];
    msgLen =_snprintf(msg, sizeof(msg), 
            "%.4f seconds, Done Create, %lu KB bytes written, records:%d, file %s\n", 
            seconds, ULONG(filePos.QuadPart/KB), recNum, filePerfCmd.m_filename.c_str());
    SetMsg(&rwStats, msg, msgLen+1);
    OutputDebugStringA(msg);

    CloseHandle(filePerfCmd.m_hFile);
    filePerfCmd.m_hFile = INVALID_HANDLE_VALUE;
    return true;
}


// ----------------------------------------------------------------------------
static DWORD WINAPI sRwTest(void* data)
{
    const DWORD sMaxSeconds = 5;

    char  msg[512];
    int   msgLen;

    CFilePerfCmd* pFilePerfCmd = (CFilePerfCmd*)data;
    CFilePerfCmd::RwStats* pRwStats = &pFilePerfCmd->m_rwStats;

    std::vector<std::string> drvStrVec;
    std::string  drvStr = pRwStats->driveList;
    size_t drvLen = drvStr.length();

    int last = 0;
    for (int i = 0; i < drvLen; i++)
    {
        if (drvStr[i] == ';')
        {
            std::string s = drvStr.substr(last, i-last);
            // drvListVec.push_back(s);
        }
    }


#if 0
    wchar_t wDriveStr[MAX_PATH];
    int srcLen = pRwStats->driveList.length();
    int wlen = mbtowc(wDriveStr, pRwStats->driveList.c_str(), srcLen < MAX_PATH ? srcLen : MAX_PATH);
    m_basePath = std::wstring(wDriveStr, wlen);
    m_basePath += L":\\";
#endif

    std::string filename = pFilePerfCmd->m_basePath + pFilePerfCmd->m_filename;

    pRwStats->runningTest = -1;
    pRwStats->runningSubTest = -1;
    pRwStats->makeFilePercent = 0;

    if (pFilePerfCmd->m_hFile != INVALID_HANDLE_VALUE)
        CloseHandle(pFilePerfCmd->m_hFile);

    // TODO - Get sector size , see GetFreeDiskSpace function
    static char sBuffer[MB*8+4096];
    DWORD bytesPerSector = 512;

    char* buffer = (char*)((ULONG_PTR)(sBuffer + bytesPerSector-1) & ~((ULONG_PTR)(bytesPerSector-1)));

    DWORD file_flags = 0
        | FILE_FLAG_NO_BUFFERING
        | FILE_FLAG_WRITE_THROUGH       // by-pass cache
        | FILE_FLAG_SEQUENTIAL_SCAN     // hint sequencial access.
        //  | FILE_FLAG_RANDOM_ACCESS
        ;

    pFilePerfCmd->m_hFile = CreateFileA(filename.c_str() 
        , GENERIC_READ | GENERIC_WRITE 
        , FILE_SHARE_READ| FILE_SHARE_WRITE 
        , 0 
        , CREATE_ALWAYS 
        , 0
        | FILE_ATTRIBUTE_NORMAL 
        | FILE_FLAG_DELETE_ON_CLOSE
        | file_flags
        , 0);
        
    if (pFilePerfCmd->m_hFile == INVALID_HANDLE_VALUE)
    {
        pRwStats->makeFilePercent = 100;
        pRwStats->runningTest = -2;
        pRwStats->runningSubTest = -2;
        DWORD error = GetLastError();
        msgLen = _snprintf(msg, sizeof(msg), "Failed to create file, error=%d\n", error);
        SetMsg(pRwStats, msg, msgLen+1);
        OutputDebugStringA(msg);
        return error;
    }

    LARGE_INTEGER filePos, fileEndSize;
    filePos.QuadPart = 0;
    fileEndSize.QuadPart = pRwStats->fileKbSize * KB;
    DWORD startTick, endTick;
    double seconds;
    DWORD  ioSize  = 1;
    int    recNum = 0;
    size_t ckSum1 = 0;
    size_t wrtSize = MB * 8;
                
    OutputDebugStringA("Start Creating Test File\n");
    startTick = GetTickCount();
    while (filePos.QuadPart < fileEndSize.QuadPart 
        && ioSize != 0 
        && pFilePerfCmd->m_rwRunStat != CFilePerfCmd::eStop)
    {
        if (wrtSize > size_t(fileEndSize.QuadPart - filePos.QuadPart))
            ioSize = DWORD(wrtSize = size_t(fileEndSize.QuadPart - filePos.QuadPart));

        if (wrtSize > 0)
        {
            memset(buffer, recNum++, wrtSize);
            ckSum1 = CkSum(ckSum1, (const unsigned char*)buffer, wrtSize);
            WriteFile(pFilePerfCmd->m_hFile, buffer, (DWORD)wrtSize, &ioSize, 0);
            filePos.QuadPart += ioSize;
            pRwStats->makeFilePercent = int(filePos.QuadPart * 100 / fileEndSize.QuadPart);
        }
    }
    endTick = GetTickCount();

    seconds = (endTick - startTick) / 1000.0;
    msgLen =_snprintf(msg, sizeof(msg), 
            "%.4f seconds, Done Create, %lu KB bytes written, records:%d, file %s\n", 
            seconds, ULONG(filePos.QuadPart/KB), recNum, filename.c_str());
    SetMsg(pRwStats, msg, msgLen+1);
    OutputDebugStringA(msg);

#if 0
    // --------------------------------------
    DWORD file_flags2 = 0
        //  | FILE_FLAG_NO_BUFFERING
        //  | FILE_FLAG_RANDOM_ACCESS
        | FILE_FLAG_SEQUENTIAL_SCAN     // hint that sequencial access.
        | FILE_FLAG_WRITE_THROUGH       // by-pass cache
        ;

    HANDLE hFile2 = CreateFile(filename.c_str()
        , GENERIC_READ | GENERIC_WRITE 
        , FILE_SHARE_READ | FILE_SHARE_WRITE 
        , 0 
        , OPEN_EXISTING 
        , 0
        | FILE_ATTRIBUTE_NORMAL 
        | file_flags2
        , 0);

    if (hFile2 == INVALID_HANDLE_VALUE)
    {
        pRwStats->makeFilePercent = 100;
        pRwStats->runningTest = -2;
        pRwStats->runningSubTest = -2;
        DWORD error = GetLastError();
        _snprintf(pRwStats->pMessage, pRwStats->maxMsg, "Failed to create file, error=%d\n", error);
        OutputDebugStringA(pRwStats->pMessage);
        return error;
    }
#endif

 // ......................
    pRwStats->runningTest = 0;
    pRwStats->runningSubTest = 0;

    size_t tstCnt = pRwStats->testValues.size();
    while (pRwStats->runningTest < tstCnt && pFilePerfCmd->m_rwRunStat != CFilePerfCmd::eStop)
    {
        size_t writeCnt = 0;
        size_t readCnt = 0;

        pRwStats->runningSubTest = 0;
        pRwStats->runningPercent = 0;
        DWORD recordSize = pRwStats->runningSize = int(pRwStats->testValues[pRwStats->runningTest * 
            CFilePerfCmd::RwStats::eTestWidth + CFilePerfCmd::RwStats::eRecSize]);

        // ----------------------------------------------
        // ---- PreWrite Test
#if 0
        SetFilePointer(hFile2, 0, 0, FILE_BEGIN);
        filePos.QuadPart = 0;
        ioSize = 1;
        size_t ckSum2 = 0;
        recNum = 0;

        startTick = GetTickCount();
        while (
            (filePos.QuadPart < fileEndSize.QuadPart || (GetTickCount() - startTick) < 100)
            && ioSize != 0
            && pFilePerfCmd->m_rwRunStat != CFilePerfCmd::eStop)
        {
            memset(buffer, recNum++, recordSize);
            ckSum2 = CkSum(ckSum2, (const unsigned char*)buffer, recordSize);
            WriteFile(hFile2, buffer, recordSize, &ioSize, 0);
            writeCnt++;
            filePos.QuadPart += ioSize;
            pRwStats->runningPercent = filePos.QuadPart * 100 / fileEndSize.QuadPart;

            if (pFilePerfCmd->m_rwRunStat == CFilePerfCmd::ePause)
            {
                WaitForSingleObject(pFilePerfCmd->m_rwEvent, 0);
            }
        }

        endTick = GetTickCount();
        seconds = (endTick - startTick) / 1000.0;

        pRwStats->pTestValues[pRwStats->runningTest * CFilePerfCmd::RwStats::eTestWidth + CFilePerfCmd::RwStats::eWriteSpd] =
            (seconds > 0 )? filePos.QuadPart / (KB * seconds) : 0; 
        _snprintf(pRwStats->pMessage, pRwStats->maxMsg, 
            "%u Writes, %.4f Seconds, %u KB bytes Direct written, Cksum %u, File %S\n", 
            writeCnt, seconds, size_t(filePos.QuadPart/KB), ckSum2, filename.c_str());
        OutputDebugStringA(pRwStats->pMessage);
#endif

        // ----------------------------------------------
        // ---- Read Test
        SetFilePointer(pFilePerfCmd->m_hFile, 0, 0, FILE_BEGIN);
        filePos.QuadPart = 0;
        ioSize = 1;
        size_t ckSum3 = 0;

        OutputDebugStringA("Start Read Test\n");
        startTick = GetTickCount();
        endTick   = startTick + sMaxSeconds * 1000;
        while (filePos.QuadPart < fileEndSize.QuadPart
            && ioSize != 0
            && pFilePerfCmd->m_rwRunStat != CFilePerfCmd::eStop
            && GetTickCount() < endTick)
        {
            ReadFile(pFilePerfCmd->m_hFile, buffer, recordSize, &ioSize, 0);
            ckSum3 = CkSum(ckSum3, (const unsigned char*)buffer, recordSize);

            readCnt++;
            filePos.QuadPart += ioSize;
            pRwStats->runningPercent = int(filePos.QuadPart * 100 / fileEndSize.QuadPart);

            if (pFilePerfCmd->m_rwRunStat == CFilePerfCmd::ePause)
            {
                WaitForSingleObject(pFilePerfCmd->m_rwEvent, 0);
            }
        }

        endTick = GetTickCount();
        seconds = (endTick - startTick) / 1000.0;

        pRwStats->testValues[pRwStats->runningTest * CFilePerfCmd::RwStats::eTestWidth + CFilePerfCmd::RwStats::eReadSpd] =
            (seconds > 0 )? filePos.QuadPart / (KB * seconds) : 0; 

        char tmpMsg[512];
        _snprintf(tmpMsg, sizeof(tmpMsg), 
            "%lu reads, %.4f Seconds, %lu KB bytes read, ckSum %lu, File %s\n", 
            (ULONG)readCnt, seconds, ULONG(filePos.QuadPart/KB), (ULONG)ckSum3, filename.c_str());
        pRwStats->message = tmpMsg;
        OutputDebugStringA(tmpMsg);

        pRwStats->runningSubTest++;

        // ----------------------------------------------
        // ---- Write Test
        SetFilePointer(pFilePerfCmd->m_hFile, 0, 0, FILE_BEGIN);
        filePos.QuadPart = 0;
        ioSize = 1;
        writeCnt = 0;

        startTick = GetTickCount();
        while (filePos.QuadPart < fileEndSize.QuadPart
            && ioSize != 0
            && pFilePerfCmd->m_rwRunStat != CFilePerfCmd::eStop)
        {
            WriteFile(pFilePerfCmd->m_hFile, buffer, recordSize, &ioSize, 0);
            writeCnt++;
            filePos.QuadPart += ioSize;
            pRwStats->runningPercent = int(filePos.QuadPart * 100 / fileEndSize.QuadPart);

            if (pFilePerfCmd->m_rwRunStat == CFilePerfCmd::ePause)
            {
                WaitForSingleObject(pFilePerfCmd->m_rwEvent, 0);
            }
        }

        endTick = GetTickCount();
        seconds = (endTick - startTick) / 1000.0;

        pRwStats->testValues[pRwStats->runningTest * CFilePerfCmd::RwStats::eTestWidth + CFilePerfCmd::RwStats::eWriteSpd] =
            (seconds > 0 )? filePos.QuadPart / (KB * seconds) : 0; 


        _snprintf(tmpMsg, sizeof(tmpMsg), "%lu writes, %.4f Seconds, %lu KB bytes written to %s\n", 
            (ULONG)writeCnt, seconds, ULONG(filePos.QuadPart/KB), filename.c_str());
        pRwStats->message = tmpMsg;
        OutputDebugStringA(tmpMsg);
        pRwStats->runningSubTest++;


        pRwStats->runningTest++;
    }

    // Done
    CloseHandle(pFilePerfCmd->m_hFile);
 //   CloseHandle(hFile2);
    DeleteFileA(filename.c_str());

    pFilePerfCmd->m_hFile = INVALID_HANDLE_VALUE;
    pRwStats->runningTest = -2;
    pRwStats->runningSubTest = -2;
    OutputDebugStringA("rwThread done\n");

    return 0;
}


// ----------------------------------------------------------------------------
CFilePerfCmd::CFilePerfCmd() : 
    m_rwThread(INVALID_HANDLE_VALUE), 
    m_rwEvent(INVALID_HANDLE_VALUE),
    m_hFile(INVALID_HANDLE_VALUE)
{
    m_basePath = "c:\\";
    m_filename = "fileperf.tmp";
}

// ----------------------------------------------------------------------------
CFilePerfCmd::~CFilePerfCmd()
{
    RwClear();
}

// ----------------------------------------------------------------------------
void CFilePerfCmd::RwClear()
{
    if (m_rwThread != INVALID_HANDLE_VALUE)
    {
        CloseHandle(m_rwThread);
        m_rwThread = INVALID_HANDLE_VALUE;
    }

    if (m_rwEvent != INVALID_HANDLE_VALUE)
    {
        CloseHandle(m_rwEvent);
        m_rwEvent = INVALID_HANDLE_VALUE;
    }

    if (m_hFile != INVALID_HANDLE_VALUE)
    {
        CloseHandle(m_hFile);
        m_hFile = INVALID_HANDLE_VALUE;
    }

    if (m_rwRunStat == ePause)
    {
        m_rwRunStat = eStop;
        SetEvent(m_rwEvent);
    }

    m_rwRunStat = eStop;
}

// ----------------------------------------------------------------------------
int CFilePerfCmd::RwStartTest()
{
#if 0
    wchar_t wDriveStr[20];
    int srcLen = (driveStr == 0) ? 0 : strlen(driveStr);
    int wlen = mbtowc(wDriveStr, driveStr, srcLen < 20 ? srcLen : 20);
    m_basePath = std::wstring(wDriveStr, wlen);
    m_basePath += L":\\";
#endif

    // Running stats;
    m_rwStats.makeFilePercent = 0;
    m_rwStats.runningTest = 0;
    m_rwStats.runningSubTest = 0;
    m_rwStats.runningPercent = 0;
    m_rwStats.runningSize = 0;

    RwClear();

    void*  value = this;
    DWORD threadId;
    m_rwRunStat  = eRun;
    m_rwEvent    = CreateEvent(0, false, false, L"rwTest");
    m_rwThread   = CreateThread(0, 0, (LPTHREAD_START_ROUTINE)sRwTest, (PVOID)value, 0, &threadId);
    m_rwThreadId = threadId;

    return 0;
}

// ----------------------------------------------------------------------------
void  CFilePerfCmd::RwStopTest()
{
    m_rwRunStat = eStop;           
}

// ----------------------------------------------------------------------------
void  CFilePerfCmd::RwPauseTest()
{
    if (m_rwRunStat == eRun)
        m_rwRunStat = ePause;
}

// ----------------------------------------------------------------------------
void  CFilePerfCmd::RwResumeTest()
{
    if (m_rwRunStat == ePause)
    {
        m_rwRunStat = eRun;
        SetEvent(m_rwEvent);
    }
}

// ----------------------------------------------------------------------------
CFilePerfCmd::RwStats* CFilePerfCmd::RwGetStatPtr()
{
#if 0
    if (m_rwStats.pTestValues == 0)
    {
        memset(&m_rwStats, 0, sizeof(m_rwStats));
    }
#endif

    return &m_rwStats;
}

// ----------------------------------------------------------------------------
void CFilePerfCmd::RwSetStat(const CFilePerfCmd::RwStats& rwStats)
{
   m_rwStats = rwStats;  
}

#if 0
// ----------------------------------------------------------------------------
CFilePerfCmd::RwStats& CFilePerfCmd::RwStats::operator =(const CFilePerfCmd::RwStats& rhs)
{
    if (this != &rhs)
    {
        makeFilePercent    = rhs.makeFilePercent;   
        runningSize        = rhs.runningSize;       
        runningTest        = rhs.runningTest;       
        runningSubTest     = rhs.runningSubTest;    
        runningPercent     = rhs.runningPercent;    
                             
        fileKbSize         = rhs.fileKbSize;        
        minRecord          = rhs.minRecord;         
        maxRecord          = rhs.maxRecord;         
                             
        numTests           = rhs.numTests;  
        testWidth          = rhs.testWidth;
        maxMsg             = rhs.maxMsg;

        delete []pTestValues;
        pTestValues = new double[numTests*testWidth];
        memcpy(pTestValues, rhs.pTestValues, rhs.numTests*3*sizeof(pTestValues[0]));
       
        delete [] pMessage;
        pMessage = new char[maxMsg];
        memcpy(pMessage, rhs.pMessage, maxMsg);
    }
    return *this;
}
#endif
