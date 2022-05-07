using System.Text.Json;
using System.Text.Json.Serialization;

namespace YS.AWS.StateMachine.Abstractions.Serialization;

internal static class StateMachineSerializerOptions
{
    public static JsonSerializerOptions Default
    {
        get
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            options.Converters.Add(new JsonPathConverter());
            options.Converters.Add(new FunctionIntrisincConverter());
            options.Converters.Add(new StateJsonConverter());
            options.Converters.Add(new AnyValueConverter());

            return options;
        }
    }
}
