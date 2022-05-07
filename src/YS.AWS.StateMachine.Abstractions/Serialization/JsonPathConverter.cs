using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using YS.AWS.StateMachine.Abstractions.Values;

namespace YS.AWS.StateMachine.Abstractions.Serialization;

[JsonConverter(typeof(JsonPathConverter))]
internal class JsonPathConverter : JsonConverter<JsonPath>
{
    public override JsonPath Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return new JsonPath(reader.GetString());
    }

    public override void Write(Utf8JsonWriter writer, JsonPath value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.Path);
    }
}
