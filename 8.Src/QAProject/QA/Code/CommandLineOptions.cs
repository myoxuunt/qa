
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

}
