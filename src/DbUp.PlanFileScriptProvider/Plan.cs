using System.Collections.Generic;
using DbUp.Engine;

namespace DbUp.PlanFileScriptProvider
{
    internal class Plan
    {
        public List<Script> Scripts { get; set; }
    }
}