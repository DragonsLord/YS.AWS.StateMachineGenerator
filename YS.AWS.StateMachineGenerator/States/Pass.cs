using YS.AWS.StateMachine.Abstractions.Values;

namespace YS.AWS.StateMachine.Abstractions.States;

//https://docs.aws.amazon.com/step-functions/latest/dg/amazon-states-language-pass-state.html
public class Pass : State
{
    public override StateType Type => StateType.Pass;

    public AnyValue Result { get; set; }
    public string ResultPath { get; set; }
    public IDictionary<string, AnyValue> Parameters { get; set; }
}
