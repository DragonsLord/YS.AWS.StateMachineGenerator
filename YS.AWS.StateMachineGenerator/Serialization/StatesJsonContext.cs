using System.Text.Json;
using System.Text.Json.Serialization;
using YS.AWS.StateMachine.Abstractions.States;

namespace YS.AWS.StateMachine.Abstractions.Serialization;

[JsonSerializable(typeof(Pass))]
[JsonSerializable(typeof(Choice))]
[JsonSerializable(typeof(Fail))]
[JsonSerializable(typeof(Map))]
[JsonSerializable(typeof(States.Parallel))]
[JsonSerializable(typeof(Succeed))]
[JsonSerializable(typeof(States.Task))]
[JsonSerializable(typeof(Wait))]
[JsonSerializable(typeof(State))]
internal partial class StatesJsonContext : JsonSerializerContext
{
    private static StatesJsonContext _instance = new StatesJsonContext(new JsonSerializerOptions
    {
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    });

    public static StatesJsonContext Formatted => _instance;
}
