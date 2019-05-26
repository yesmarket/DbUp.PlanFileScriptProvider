using System;

namespace DbUp.PlanFileScriptProvider
{
    internal class Script
    {
        public string Path { get; set; }
        public DateTime Timestamp { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
    }
}