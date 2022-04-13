This repository contains package for AWS State Machine definition generation using .Net.

## YS.AWS.StateMachine.Abstractions

This pacakge counts abstraction for state machine defintion like states.
It also provide a low level api for generating definitions.

Here how the simple [hello world state machine](https://docs.aws.amazon.com/step-functions/latest/dg/getting-started.html) will look like:

```csharp
var stateMachine = new StateMachine
{
    StartAt = "Hello",
    Comment = "A Hello World example of the Amazon States Language using Pass states",
    States = new Dictionary<string, State>
    {
        ["Hello"] = new Pass
        {
            Next = "World"
        },
        ["World"] = new Pass
        {
            Result = "World",
            End = true
        }
    }
};
```
