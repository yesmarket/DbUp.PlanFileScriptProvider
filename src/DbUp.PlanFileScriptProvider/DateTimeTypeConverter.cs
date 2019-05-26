using System;
using System.Globalization;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace DbUp.PlanFileScriptProvider
{
    internal class DateTimeTypeConverter : IYamlTypeConverter
    {
        public bool Accepts(Type type)
        {
            return type == typeof(DateTime);
        }

        public object ReadYaml(IParser parser, Type type)
        {
            var scalar = parser.Current as Scalar;
            var timestamp = DateTime.Parse(scalar?.Value, null, DateTimeStyles.RoundtripKind);
            parser.MoveNext();
            return timestamp;
        }

        public void WriteYaml(IEmitter emitter, object value, Type type)
        {
            throw new NotImplementedException();
        }
    }
}