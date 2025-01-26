// wrapper.h

#pragma once

using namespace System;
using namespace System::Runtime::InteropServices;


#include "..\CFilePerf\CFilePerfCmd.h"

namespace wrapper {

    public ref class MRwStats
    {
    public:
        MRwStats() : numTests(0) {} 
        MRwStats(CFilePerfCmd::RwStats* pRwStats);

        int makeFilePercent;
        int runningSize;
        int runningTest;
        int runningSubTest;
        int runningPercent;

        int fileKbSize;

        int numTests;
        // enum { eDrvIdx=0, eRecSize=1, eReadSpd=2, eWriteSpd=3, eTestWidth=4};

        static const int eDrvIdx = CFilePerfCmd::RwStats::eDrvIdx;
        static const int eRecSize = CFilePerfCmd::RwStats::eRecSize;  
        static const int eReadSpd = CFilePerfCmd::RwStats::eReadSpd;  
        static const int eWriteSpd = CFilePerfCmd::RwStats::eWriteSpd;  
        static const int eTestWidth = CFilePerfCmd::RwStats::eTestWidth;
        array<double>^ pTestValues;  // size, read KB/s, write KB/s
        String^ drvList;
        String^ message;
    };

	public ref class WFilePerfCmd
	{
    private:
        CFilePerfCmd *pCfilePerfCmd;
        void Destruct() { delete pCfilePerfCmd; pCfilePerfCmd = 0; }

    public:
        WFilePerfCmd() { pCfilePerfCmd = new CFilePerfCmd(); }
        ~WFilePerfCmd() { Destruct(); }
        !WFilePerfCmd() { Destruct(); }

        void RwStartTest(const MRwStats^ pRwStats);
        void RwStopTest();
        void RwPauseTest();
        void RwResumeTest();

        // Shallow copy, just copy integers
        MRwStats^ RwGetStats();

        // Deep copy, copy all values
        MRwStats^ RwGetFullStats();

        void RwSetStats(const MRwStats^ pRwStats);
	};
}
