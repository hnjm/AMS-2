﻿using System;
using System.Threading;
using System.Windows.Forms;

namespace BioMetrixCore
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool instanceCountOne = false;

            using (Mutex mtex = new Mutex(true, "MyRunningApp", out instanceCountOne))
            {
                if (instanceCountOne)
                {
                    Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2());
                    mtex.ReleaseMutex();
                }
                else
                {
                    MessageBox.Show("An application instance is already running");
                }
            }
        }
    }
}
