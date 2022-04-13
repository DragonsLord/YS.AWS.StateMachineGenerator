using System.Text.Json;
using System.Text.Json.Serialization;
using YS.AWS.StateMachine.Abstractions.Serialization;

namespace YS.AWS.StateMachine.Abstractions.States;

//https://docs.aws.amazon.com/step-functions/latest/dg/amazon-states-language-common-fields.html
[JsonConverter(typeof(StateJsonConverter))]
public abstract class State
{
    public abstract StateType Type { get; }
    public string Next { get; set; }
    public bool? End { get; set; }
    public string Comment { get; set; }

    // TODO: create special class Path
    public string InputPath { get; set; }
    public string OutputPath { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this, GetType(), StatesJsonContext.Formatted);
    }
}
