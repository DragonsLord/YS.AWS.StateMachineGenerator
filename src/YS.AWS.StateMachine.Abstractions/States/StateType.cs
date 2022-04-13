using System.Text.Json.Serialization;

namespace YS.AWS.StateMachine.Abstractions.States;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum StateType
{
    Pass,
    Task,
    Choice,
    Wait,
    Succeed,
    Fail,
    Parallel,
    Map
}
