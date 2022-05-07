using YS.AWS.StateMachine.Abstractions.Values;

namespace YS.AWS.StateMachine.Abstractions.States;

//https://docs.aws.amazon.com/step-functions/latest/dg/amazon-states-language-task-state.html
public class Task : State
{
    public override StateType Type => StateType.Task;

    public string Resource { get; set; }
    public AnyValue Parameters { get; set; }
    public JsonPath ResultPath { get; set; }
    public AnyValue ResultSelector { get; set; }
    public Retry[] Retry { get; set; }
    public Catch[] Catch { get; set; }
    public int? TimeoutSeconds { get; set; }
    public JsonPath TimeoutSecondsPath { get; set; }
    public int? HeartbeatSeconds { get; set; }
    public JsonPath HeartbeatSecondsPath { get; set; }

    protected override IEnumerable<(string Key, object Value, bool Pathable)> GetSerializedFields()
    {
        yield return (nameof(Resource), Resource, false);
        yield return (nameof(Parameters), Parameters, true);
        yield return (nameof(ResultPath), ResultPath, false);
        yield return (nameof(ResultSelector), ResultSelector, true); //TODO: check if pathable
        yield return (nameof(Retry), Retry, false);
        yield return (nameof(Catch), Catch, false);
        yield return (nameof(TimeoutSeconds), TimeoutSeconds, false);
        yield return (nameof(TimeoutSecondsPath), TimeoutSecondsPath, false);
        yield return (nameof(HeartbeatSeconds), HeartbeatSeconds, false);
        yield return (nameof(HeartbeatSecondsPath), HeartbeatSecondsPath, false);
    }
}