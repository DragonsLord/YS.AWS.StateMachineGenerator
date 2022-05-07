using System.Text.Json;
using System.Text.Json.Serialization;
using YS.AWS.StateMachine.Abstractions.Serialization;
using YS.AWS.StateMachine.Abstractions.Values;

namespace YS.AWS.StateMachine.Abstractions.States;

//https://docs.aws.amazon.com/step-functions/latest/dg/amazon-states-language-common-fields.html
[JsonConverter(typeof(StateJsonConverter))]
public abstract class State
{
    public abstract StateType Type { get; }
    public string Next { get; set; }
    public bool? End { get; set; }
    public string Comment { get; set; }

    public JsonPath InputPath { get; set; }
    public JsonPath OutputPath { get; set; }

    internal IEnumerable<(string Key, object Value, bool Pathable)> GetSerializedFieldsInfo()
    {
        IEnumerable<(string Key, object Value, bool Pathable)> GetBaseFields() {
            yield return (nameof(Type), Type, false);
            yield return (nameof(Next), Next, false);
            yield return (nameof(End), End, false);
            yield return (nameof(Comment), Comment, false);
            yield return (nameof(InputPath), InputPath, false);
            yield return (nameof(OutputPath), OutputPath, false);
        }

        return GetBaseFields().Concat(GetSerializedFields());
    }

    protected virtual IEnumerable<(string Key, object Value, bool Pathable)> GetSerializedFields()
    {
        return Enumerable.Empty<(string, object, bool)>();
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this, GetType(), StateMachineSerializerOptions.Default);
    }
}
