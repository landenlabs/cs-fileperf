

// #include <windows.h>
#include <string>
#include <vector>

class CFilePerfCmd
{
public:
    CFilePerfCmd(); 
    ~CFilePerfCmd();

    int  RwStartTest();
    void RwStopTest();
    void RwPauseTest();
    void RwResumeTest();
    void RwClear();

    struct RwStats
    {
        // RwStats& operator=(const RwStats& rhs);

        int makeFilePercent;
        int runningSize;
        int runningTest;
        int runningSubTest;
        int runningPercent;

        int fileKbSize;
        enum { eDrvIdx=0, eRecSize=1, eReadSpd=2, eWriteSpd=3, eTestWidth=4};
        std::vector<double> testValues; // driveIdx, recSize, readSpd, writeSpd ...
        std::string message;
        std::string driveList;
    };

    RwStats*  RwGetStatPtr();
    void RwSetStat(const RwStats&);

    RwStats         m_rwStats;
    enum RunStat {eRun, ePause, eStop};
    RunStat         m_rwRunStat;

    typedef unsigned int Dword;
    Dword           m_rwThreadId;

    typedef void* Handle;
    Handle          m_rwThread;
    Handle          m_rwEvent;

    std::string     m_basePath;
    std::string     m_filename;
    Handle          m_hFile;    // handle to test file.
};


