using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using pl.xtb.api.message.codes;
using pl.xtb.api.message.command;
using pl.xtb.api.message.records;
using pl.xtb.api.message.response;
using pl.xtb.api.streaming;
using pl.xtb.api.sync;

namespace SpreadInformer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
