using YS.AWS.StateMachine.Abstractions.Values;

namespace YS.AWS.StateMachine.Abstractions.States;

//https://docs.aws.amazon.com/step-functions/latest/dg/amazon-states-language-task-state.html
public class Task : State
{
    public override StateType Type => StateType.Task;

    public string Resource { get; set; }
    public IDictionary<string, AnyValue> Parameters { get; set; }
    public string ResultPath { get; set; }
    public IDictionary<string, AnyValue> ResultSelector { get; set; }
    public Retry[] Retry { get; set; }
    public Catch[] Catch { get; set; }
    public int? TimeoutSeconds { get; set; }
    public string TimeoutSecondsPath{ get; set; }
    public int? HeartbeatSeconds { get; set; }
    public string HeartbeatSecondsPath { get; set; }
}