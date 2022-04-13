using YS.AWS.StateMachine.Abstractions.Values;

namespace YS.AWS.StateMachine.Abstractions.States;

//https://docs.aws.amazon.com/step-functions/latest/dg/amazon-states-language-map-state.html
public class Map : State
{
    public override StateType Type => StateType.Map;

    public StateMachine Iterator { get; set; }
    public string ItemsPath { get; set; }
    public int? MaxConcurrency { get; set; }
    public string ResultPath { get; set; }
    public IDictionary<string, AnyValue> ResultSelector { get; set; }
    public Retry[] Retry { get; set; }
    public Catch[] Catch { get; set; }
}
