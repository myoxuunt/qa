using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QA
{
    public class CommandLineOptions : Codeblast.CommandLineOptions
    {
        public CommandLineOptions(string[] args)
            : base(args)
        {

        }

        [Codeblast.Option(Short = "d")]
        public bool IsDebugMode = false;
    }

    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            CommandLineOptions cmdOptioins = new CommandLineOptions(args);
            QAApp.App.Config.CommandLineOptions = cmdOptioins;
            QAApp.App.Run();
        }
    }
}
