using System.Text.Json;
using System.Text.Json.Serialization;
using YS.AWS.StateMachine.Abstractions.Values;

namespace YS.AWS.StateMachine.Abstractions.Serialization;

[JsonConverter(typeof(FunctionIntrisincConverter))]
internal class FunctionIntrisincConverter : JsonConverter<IntrisincFunction>
{
    public override IntrisincFunction Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return new IntrisincFunction(reader.GetString());
    }

    public override void Write(Utf8JsonWriter writer, IntrisincFunction value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.Body);
    }
}
