using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FilePerf
{
    static class Program
    {
        /// <summary>
        /// Program to measure sequencial disk Read and Write performance.  
        /// C# is a front end to the unmanaged C++ test engine.
        /// 
        /// Code By:  Dennis Lang 2009
        ///           https://landenlabs.com/
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new mainForm());
        }
    }
}
