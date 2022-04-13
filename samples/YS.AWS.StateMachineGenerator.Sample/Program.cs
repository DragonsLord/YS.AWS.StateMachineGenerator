// See https://aka.ms/new-console-template for more information
using YS.AWS.StateMachine.Abstractions;
using YS.AWS.StateMachine.Abstractions.States;
using YS.AWS.StateMachine.Abstractions.Values;

var stateMachine = new StateMachine
{
    StartAt = "Hello",
    Comment = "A Hello World example of the Amazon States Language using Pass states",
    States = new Dictionary<string, State>
    {
        ["Hello"] = new Pass
        {
            Result = "Hello",
            Next = "Dear"
        },
        ["Choose"] = new Choice
        {
            Choices = new[]
            {
                new ChoiceRule
                {
                    Variable = "$.complex",
                    BooleanEquals = true,
                    Next = "Dear"
                }
            },
            Default = "World"
        },
        ["Dear"] = new Pass
        {
            Result = new Dictionary<string, AnyValue?>
            {
                ["Text"] = "World has been updates!",
                ["Null"] = null
            },
            Next = "World",
        },
        ["World"] = new Pass
        {
            Result = AnyValue.Create(new {
                AnynimousClass = true
            }),
            End = true
        }
    }
};
Console.WriteLine(stateMachine);
