using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WorkTimer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            Model.WorkManager.Instance.AddTime();           
        }
    }
}