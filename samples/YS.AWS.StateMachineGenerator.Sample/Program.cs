using YS.AWS.StateMachine.Abstractions;
using YS.AWS.StateMachine.Abstractions.States;
using YS.AWS.StateMachine.Abstractions.Values;
using YS.AWS.StateMachine.DataContext;
using Parallel = YS.AWS.StateMachine.Abstractions.States.Parallel;
using Task = YS.AWS.StateMachine.Abstractions.States.Task;

var stateMachine = new StateMachine
{
    StartAt = "Hello",
    Comment = "A Hello World example of the Amazon States Language using Pass states",
    States = new Dictionary<string, State>
    {
        ["Hello"] = new Pass
        {
            Result = new JsonPath("$.hello"), //"Hello",
            Next = "Choose"
        },
        ["Choose"] = new Choice
        {
            Choices = new[]
            {
                new ChoiceRule
                {
                    Variable = "$.complex",
                    BooleanEquals = true,
                    Next = "Complex"
                },
                new ChoiceRule
                {
                    And = new[]
                    {
                        new ChoiceRule
                        {
                            Variable = "$.first",
                            StringEqualsPath = "$.expectFirst"
                        },
                        new ChoiceRule
                        {
                            Variable = "$.second",
                            NumericGreaterThan = 10
                        }
                    },
                    Next = "AndTrue"
                }
            },
            Default = "Fail"
        },
        ["Complex"] = new Parallel
        {
            Branches = new[]
            {
                new StateMachine
                {
                    StartAt = "Execute Task",
                    States = new Dictionary<string, State>
                    {
                        ["Execute Task"] = new Task
                        {
                            Resource = "arn:aws:states:::glue:startJobRun.sync",
                            Parameters = new Dictionary<string, AnyValue>
                            {
                                ["JobName"] = "MyGlueJob"
                            },
                            TimeoutSeconds = 300,
                            HeartbeatSeconds = 60,
                            End = true
                        }
                    }
                },
                new StateMachine
                {
                    StartAt = "Setup",
                    States = new Dictionary<string, State>
                    {
                        ["Setup"] = new Pass
                        {
                            Result = AnyValue.Create(new
                            {
                                Items = new int[] { 1, 2, 3 },
                                AnotherItems = States.Array("$.one", "$.two", "$.three")
                            }),
                            Next = "Map"
                        },
                        ["Map"] = new Map
                        {
                            ItemsPath = "$.Items",
                            Iterator = new StateMachine
                            {
                                StartAt = "Iterate",
                                States = new Dictionary<string, State>
                                {
                                    ["Iterate"] = new Task
                                    {
                                        Resource = "arn:aws:lambda:us-east-1:123456789012:function:HelloWorld",
                                        End = true
                                    }
                                }
                            }
                        }
                    }
                }
            },
            Next = "World"
        },
        ["AndTrue"] = new Pass
        {
            Result = new Dictionary<string, AnyValue?>
            {
                ["Text"] = new JsonPath("$.Input"),
                ["Null"] = AnyValue.Null()
            },
            Next = "Wait",
        },
        ["Wait"] = new Wait
        {
            Seconds = 10,
            Next = "World"
        },
        ["World"] = new Pass
        {
            Result = AnyValue.Create(new
            {
                AnynimousClass = true,
                Path = new JsonPath("$.Path")
            }),
            Next = "Success"
        },
        ["Success"] = new Succeed(),
        ["Fail"] = new Fail
        {
            Error = "Error Message"
        }
    }
};

Console.WriteLine(stateMachine);
