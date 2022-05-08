using Xunit;
using YS.AWS.StateMachine.Abstractions.States;
using YS.AWS.StateMachine.Abstractions.Tests;
using YS.AWS.StateMachine.Abstractions.Values;

namespace YS.AWS.StateMachine.Abstractions;

public class PassTests
{
    [Fact]
    public void ConstantResult()
    {
        var passState = new Pass
        {
            Result = AnyValue.Create(123),
            Next = "NextState"
        };

        var result = passState.ToString();

        result.ShouldBeJsonString("{" +
            "\"Type\": \"Pass\"," +
            "\"Result\": 123," +
            "\"Next\": \"NextState\"" +
        "}");
    }

    [Fact]
    public void JsonPathResult()
    {
        var passState = new Pass
        {
            Result = new JsonPath("$.result"),
            End = true
        };

        var result = passState.ToString();

        result.ShouldBeJsonString("{" +
            "\"Type\": \"Pass\"," +
            "\"Result.$\": \"$.result\"," +
            "\"End\": true" +
        "}");
    }

    [Fact]
    public void ResultPath()
    {
        var passState = new Pass
        {
            ResultPath = new JsonPath("$.output"),
            End = true
        };

        var result = passState.ToString();

        result.ShouldBeJsonString("{" +
            "\"Type\": \"Pass\"," +
            "\"ResultPath\": \"$.output\"," +
            "\"End\": true" +
        "}");
    }

    [Fact]
    public void ConstantParameters()
    {
        var passState = new Pass
        {
            Parameters = AnyValue.Create(123),
            Next = "NextState"
        };

        var result = passState.ToString();

        result.ShouldBeJsonString("{" +
            "\"Type\": \"Pass\"," +
            "\"Parameters\": 123," +
            "\"Next\": \"NextState\"" +
        "}");
    }

    [Fact]
    public void JsonPathParameters()
    {
        var passState = new Pass
        {
            Parameters = new JsonPath("$$"),
            End = true
        };

        var result = passState.ToString();

        result.ShouldBeJsonString("{" +
            "\"Type\": \"Pass\"," +
            "\"Parameters.$\": \"$$\"," +
            "\"End\": true" +
        "}");
    }
}
