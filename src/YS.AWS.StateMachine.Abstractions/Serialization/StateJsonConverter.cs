using System.Text.Json;
using System.Text.Json.Serialization;
using YS.AWS.StateMachine.Abstractions.States;

namespace YS.AWS.StateMachine.Abstractions.Serialization;

internal class StateJsonConverter : JsonConverter<State>
{
    public override State Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // TODO: implement ?
        throw new NotSupportedException($"Deserialization of the {nameof(State)} type is not supported");
    }

    public override void Write(Utf8JsonWriter writer, State value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WriteProperties(value.GetSerializedFieldsInfo(), options);
        writer.WriteEndObject();
    }
}
