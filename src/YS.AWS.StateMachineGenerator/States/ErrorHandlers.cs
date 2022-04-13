namespace YS.AWS.StateMachine.Abstractions.States;

//https://docs.aws.amazon.com/step-functions/latest/dg/concepts-error-handling.html#error-handling-examples
public class Retry
{
    public string[] ErrorEquals { get; set; }
    public int IntervalSeconds { get; set; }
    public int MaxAttemps { get; set; }
    public decimal BackoffRate { get; set; }
}

public class Catch
{
    public string[] ErrorEquals { get; set; }
    public string Next { get; set; }
    public string ResultPath { get; set; }
}
