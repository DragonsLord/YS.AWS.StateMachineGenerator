namespace YS.AWS.StateMachine.Abstractions.States;

//https://docs.aws.amazon.com/step-functions/latest/dg/amazon-states-language-succeed-state.html
public class Succeed : State
{
    public override StateType Type => StateType.Succeed;
}
