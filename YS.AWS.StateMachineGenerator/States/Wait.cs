namespace YS.AWS.StateMachine.Abstractions.States;

//https://docs.aws.amazon.com/step-functions/latest/dg/amazon-states-language-wait-state.html
public class Wait : State
{
    public override StateType Type => StateType.Wait;

    public int? Seconds { get; set; }
    public string SecondsPath { get; set; }

    public DateTime? Timestamp { get; set; }
    public string TimestampPath { get; set; }
}
