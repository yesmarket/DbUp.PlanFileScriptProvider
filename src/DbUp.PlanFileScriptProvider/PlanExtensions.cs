using DbUp.Builder;

namespace DbUp.PlanFileScriptProvider
{
    public static class PlanExtensions
    {
        public static UpgradeEngineBuilder WithPlan(this UpgradeEngineBuilder builder,
            string name)
        {
            return builder.WithScripts(new PlanFileScriptProvider(name));
        }
    }
}