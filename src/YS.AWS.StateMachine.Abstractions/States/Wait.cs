using YS.AWS.StateMachine.Abstractions.Values;

namespace YS.AWS.StateMachine.Abstractions.States;

//https://docs.aws.amazon.com/step-functions/latest/dg/amazon-states-language-wait-state.html
public class Wait : State
{
    public override StateType Type => StateType.Wait;

    public int? Seconds { get; set; }
    public JsonPath SecondsPath { get; set; }

    public DateTime? Timestamp { get; set; }
    public JsonPath TimestampPath { get; set; }

    protected override IEnumerable<(string Key, object Value, bool Pathable)> GetSerializedFields()
    {
        yield return (nameof(Seconds), Seconds, false);
        yield return (nameof(SecondsPath), SecondsPath, false);
        yield return (nameof(Timestamp), Timestamp, false);
        yield return (nameof(TimestampPath), TimestampPath, false);
    }
}
