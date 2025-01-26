// This is the main DLL file.

#include "stdafx.h"

#include "wrapper.h"
using namespace System::Runtime::InteropServices;

namespace wrapper
{
    void WFilePerfCmd::RwStartTest(const MRwStats^ pRwStats)
    {
        RwSetStats(pRwStats);
        pCfilePerfCmd->RwStartTest(); 
    }
    
    void WFilePerfCmd::RwStopTest()
    {
        pCfilePerfCmd->RwStopTest();
    }

    void WFilePerfCmd::RwPauseTest()
    {
        pCfilePerfCmd->RwPauseTest();
    }

    void WFilePerfCmd::RwResumeTest()
    {
        pCfilePerfCmd->RwResumeTest();
    }


    MRwStats::MRwStats(CFilePerfCmd::RwStats* pRwStats)
    {
        makeFilePercent = pRwStats->makeFilePercent;
        runningSize     = pRwStats->runningSize;    
        runningTest     = pRwStats->runningTest;    
        runningSubTest  = pRwStats->runningSubTest; 
        runningPercent  = pRwStats->runningPercent; 
                                    
        fileKbSize      = pRwStats->fileKbSize;     
                                    
        numTests        = int(pRwStats->testValues.size() / CFilePerfCmd::RwStats::eTestWidth); 
        // testWidth       = CFilePerfCmd::RwStats::eTestWidth;
        // double^ pTestValues;  // size, read KB/s, write KB/s

        // int maxMsg      = pRwStats->maxMsg;
        // char^ pMessage;
    }

    MRwStats^ WFilePerfCmd::RwGetStats()
    {
        return gcnew MRwStats(pCfilePerfCmd->RwGetStatPtr());
    }

    int Strlen(const char* cPtr)
    {
        int len = 0;
        while (cPtr[len] != '\0')
            len++;

        return len;
    }

    MRwStats^ WFilePerfCmd::RwGetFullStats()
    {
        MRwStats^ pRwStats = gcnew MRwStats(pCfilePerfCmd->RwGetStatPtr());

        if (pRwStats->numTests > 0 && pRwStats->numTests < 100)
        {
            int numValues = pRwStats->numTests * pRwStats->eTestWidth;
            pRwStats->pTestValues = gcnew array<double>(numValues);

            for (int tstIdx = 0; tstIdx < numValues; tstIdx++)
            {
                pRwStats->pTestValues[tstIdx] = pCfilePerfCmd->RwGetStatPtr()->testValues[tstIdx];
            }
        }

        size_t drvLen = pCfilePerfCmd->RwGetStatPtr()->driveList.length();
        if (drvLen != 0)
        {
            pRwStats->drvList = gcnew String(pCfilePerfCmd->RwGetStatPtr()->driveList.c_str());
        }

        size_t msgLen = pCfilePerfCmd->RwGetStatPtr()->message.length();
        if (msgLen != 0)
        {
            pRwStats->message = gcnew String(pCfilePerfCmd->RwGetStatPtr()->message.c_str());
        }

        return pRwStats;
    }

    void WFilePerfCmd::RwSetStats(const MRwStats^ pRwStats)
    {
        CFilePerfCmd::RwStats stats;
        
        stats.makeFilePercent = pRwStats->makeFilePercent;   
        stats.runningSize     = pRwStats->runningSize;       
        stats.runningTest     = pRwStats->runningTest;       
        stats.runningSubTest  = pRwStats->runningSubTest;    
        stats.runningPercent  = pRwStats->runningPercent;    
                             
        stats.fileKbSize      = pRwStats->fileKbSize;        
                             
        int numValues = pRwStats->numTests * pRwStats->eTestWidth;

        stats.testValues.resize(numValues);
        for (int n = 0; n < numValues; n++)
            stats.testValues[n] = pRwStats->pTestValues[n];

        stats.message.resize(0);
        if (pRwStats->message)
        {
            char* pTmpMessage = (char*)(void*)Marshal::StringToHGlobalAnsi(pRwStats->message);
            stats.message = pTmpMessage;
            Marshal::FreeHGlobal(IntPtr((void*)pTmpMessage));
        }

        stats.driveList.resize(0);
        if (pRwStats->drvList)
        {
            char* pTmpDrvList = (char*)(void*)Marshal::StringToHGlobalAnsi(pRwStats->drvList);
            stats.driveList = pTmpDrvList;
            Marshal::FreeHGlobal(IntPtr((void*)pTmpDrvList));
        }

        pCfilePerfCmd->RwSetStat(stats);
    }
   
}

