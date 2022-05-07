namespace YS.AWS.StateMachine.Abstractions.States;

//https://docs.aws.amazon.com/step-functions/latest/dg/amazon-states-language-fail-state.html
public class Fail : State
{
    public override StateType Type => StateType.Fail;

    public string Cause { get; set; }
    public string Error { get; set; }

    protected override IEnumerable<(string Key, object Value, bool Pathable)> GetSerializedFields()
    {
        yield return (nameof(Cause), Cause, false);
        yield return (nameof(Error), Error, false); // Maybe pathable
    }
}
