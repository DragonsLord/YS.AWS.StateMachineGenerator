using System.Text.Json;
using System.Text.Json.Serialization;

namespace YS.AWS.StateMachine.Abstractions.Serialization;

internal static class StateMachineSerializerOptions
{
    public static JsonSerializerOptions Default => new JsonSerializerOptions
    {
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };
}
