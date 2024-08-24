using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    internal class parserConfig
    {
        public static string storagePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "YouTubeInfoParser");
        public string inputPath { get; set; }
    }
}
