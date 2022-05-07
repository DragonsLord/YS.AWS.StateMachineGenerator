namespace YS.AWS.StateMachine.Abstractions.Values;

public class IntrisincFunction : IIntrisinc
{
    public string Body { get; }

    internal IntrisincFunction(string body)
    {
        Body = body;
    }

    public static implicit operator string(IntrisincFunction f) => f.Body;
    public static implicit operator IntrisincFunction(string body) => new IntrisincFunction(body);

    public override string ToString() => Body;
}

public static class States
{
    public static IntrisincFunction Format(string template, JsonPath value)
    {
        return $"States.Format('{template}', {value.Path})";
    }

    public static IntrisincFunction Format(JsonPath template, JsonPath value)
    {
        return $"States.Format('{template.Path}', {value.Path})";
    }

    public static IntrisincFunction StringToJson(JsonPath stringValuePath)
    {
        return $"States.StringToJson({stringValuePath.Path})";
    }
    public static IntrisincFunction JsonToString(JsonPath jsonValuePath)
    {
        return $"States.JsonToString({jsonValuePath.Path})";
    }

    public static IntrisincFunction Array(params JsonPath[] jsonValuePath)
    {
        return $"States.Array({string.Join<JsonPath>(", ", jsonValuePath)})";
    }
}
