using YS.AWS.StateMachine.Abstractions.Values;

namespace YS.AWS.StateMachine.Abstractions.States;

//https://docs.aws.amazon.com/step-functions/latest/dg/amazon-states-language-parallel-state.html
public class Parallel : State
{
    public override StateType Type => StateType.Parallel;

    public StateMachine[] Branches { get; set; }
    public string ResultPath { get; set; }
    public IDictionary<string, AnyValue> ResultSelector { get; set; }
    public Retry[] Retry { get; set; }
    public Catch[] Catch { get; set; }
}
