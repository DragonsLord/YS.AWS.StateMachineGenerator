using System.Text.Json;
using YS.AWS.StateMachine.Abstractions.Serialization;
using YS.AWS.StateMachine.Abstractions.States;

namespace YS.AWS.StateMachine.Abstractions;

public class StateMachine
{
    public string Comment { get; set; }

    public string StartAt { get; set; }

    public int? TimeoutSeconds { get; set; }

    public string Version { get; set; }

    public IDictionary<string, State> States { get; set; }

    public override string ToString() => JsonSerializer.Serialize(this, StateMachineJsonContext.Formatted.StateMachine);
}
