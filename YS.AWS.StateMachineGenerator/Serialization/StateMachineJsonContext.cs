using System.Text.Json.Serialization;

namespace YS.AWS.StateMachine.Abstractions.Serialization;

[JsonSerializable(typeof(StateMachine))]
internal partial class StateMachineJsonContext : JsonSerializerContext
{
    private static StateMachineJsonContext _instance = new StateMachineJsonContext(StateMachineSerializerOptions.Default);
    public static StateMachineJsonContext Formatted => _instance;
}
