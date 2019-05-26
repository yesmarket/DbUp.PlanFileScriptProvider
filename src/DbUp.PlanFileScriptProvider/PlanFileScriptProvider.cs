using System.Collections.Generic;
using System.IO;
using System.Linq;
using DbUp.Engine;
using DbUp.Engine.Transactions;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace DbUp.PlanFileScriptProvider
{
    public class PlanFileScriptProvider : IScriptProvider
    {
        private readonly string _planFile;

        public PlanFileScriptProvider(string planFile)
        {
            _planFile = planFile;
        }

        public IEnumerable<SqlScript> GetScripts(IConnectionManager connectionManager)
        {
            var deserializer = new DeserializerBuilder()
                .WithTypeConverter(new DateTimeTypeConverter())
                .WithNamingConvention(new CamelCaseNamingConvention())
                .Build();

            var input = new StreamReader(_planFile);
            var plan = deserializer.Deserialize<Plan>(input);
            input.Dispose();

            var scripts = plan.Scripts.Select(script => SqlScript.FromFile(script.Path));

            return scripts;
        }
    }
}