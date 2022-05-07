using YS.AWS.StateMachine.Abstractions.Values;

namespace YS.AWS.StateMachine.Abstractions.States;

//https://docs.aws.amazon.com/step-functions/latest/dg/amazon-states-language-parallel-state.html
public class Parallel : State
{
    public override StateType Type => StateType.Parallel;

    public StateMachine[] Branches { get; set; }
    public JsonPath ResultPath { get; set; }
    public AnyValue ResultSelector { get; set; }
    public Retry[] Retry { get; set; }
    public Catch[] Catch { get; set; }

    protected override IEnumerable<(string Key, object Value, bool Pathable)> GetSerializedFields()
    {
        yield return (nameof(Branches), Branches, false);
        yield return (nameof(ResultPath), ResultPath, false);
        yield return (nameof(ResultSelector), ResultSelector, false);
        yield return (nameof(Retry), Retry, false);
        yield return (nameof(Catch), Catch, false);
    }
}
