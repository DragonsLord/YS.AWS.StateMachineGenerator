using YS.AWS.StateMachine.Abstractions.Values;

namespace YS.AWS.StateMachine.Abstractions.States;

//https://docs.aws.amazon.com/step-functions/latest/dg/amazon-states-language-map-state.html
public class Map : State
{
    public override StateType Type => StateType.Map;

    public StateMachine Iterator { get; set; }
    public JsonPath ItemsPath { get; set; }
    public int? MaxConcurrency { get; set; }
    public JsonPath ResultPath { get; set; }
    public AnyValue ResultSelector { get; set; }
    public Retry[] Retry { get; set; }
    public Catch[] Catch { get; set; }

    protected override IEnumerable<(string Key, object Value, bool Pathable)> GetSerializedFields()
    {
        yield return (nameof(Iterator), Iterator, false);
        yield return (nameof(ItemsPath), ItemsPath, false);
        yield return (nameof(MaxConcurrency), MaxConcurrency, false);
        yield return (nameof(ResultPath), ResultPath, false);
        yield return (nameof(ResultSelector), ResultSelector, false);
        yield return (nameof(Retry), Retry, false);
        yield return (nameof(Catch), Catch, false);
    }
}
