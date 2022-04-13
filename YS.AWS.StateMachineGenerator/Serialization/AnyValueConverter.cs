using System.Text.Json;
using System.Text.Json.Serialization;
using YS.AWS.StateMachine.Abstractions.Values;

namespace YS.AWS.StateMachine.Abstractions.Serialization;

internal class AnyValueConverter : JsonConverter<AnyValue>
{
    public override AnyValue Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotSupportedException($"Deserialization of the {nameof(AnyValue)} type is not supported");
    }

    public override void Write(Utf8JsonWriter writer, AnyValue value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Value, value.Value.GetType(), options);
    }
}
