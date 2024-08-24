using System.Collections.Generic;

namespace Parser
{
    internal class videoInfoJson
    {
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public List<string> tags { get; set; }
        public List<string> categories { get; set; }
    }
}
