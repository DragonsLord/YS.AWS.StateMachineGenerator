using YS.AWS.StateMachine.Abstractions.Values;

namespace YS.AWS.StateMachine.Abstractions.States;

//https://docs.aws.amazon.com/step-functions/latest/dg/amazon-states-language-pass-state.html
public class Pass : State
{
    public override StateType Type => StateType.Pass;

    public AnyValue Result { get; set; }
    public JsonPath ResultPath { get; set; }
    public AnyValue Parameters { get; set; }

    protected override IEnumerable<(string Key, object Value, bool Pathable)> GetSerializedFields()
    {
        yield return (nameof(Result), Result, true);
        yield return (nameof(ResultPath), ResultPath, false);
        yield return (nameof(Parameters), Parameters, true);
    }
}
