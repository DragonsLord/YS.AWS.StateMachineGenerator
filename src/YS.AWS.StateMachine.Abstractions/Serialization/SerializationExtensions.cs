using System.Collections;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using YS.AWS.StateMachine.Abstractions.Values;

namespace YS.AWS.StateMachine.Abstractions.Serialization;

internal static class SerializationExtensions
{
    public static bool IsIntrisinc(this object obj)
    {
        return
            (obj is IIntrisinc) ||
            (obj is AnyValue any && any.Value is IIntrisinc);
    }

    public static void WriteProperties(this Utf8JsonWriter writer, IEnumerable<(string Key, object Value, bool Pathable)> properties, JsonSerializerOptions options)
    {
        foreach (var field in properties)
        {
            if (field.Value is null)
            {
                if (options.DefaultIgnoreCondition != JsonIgnoreCondition.WhenWritingNull)
                {
                    writer.WriteNull(field.Key);
                }

                continue;
            }

            var propName = field.Key;

            if (field.Pathable && field.Value.IsIntrisinc())
                propName += ".$";

            writer.WritePropertyName(propName);

            JsonSerializer.Serialize(writer, field.Value, field.Value?.GetType(), options);
        }
    }

    public static IEnumerable<(string Key, object Value, bool Pathable)> GetProperties(this AnyValue anyValue)
    {
        if (anyValue.Value is IEnumerable<KeyValuePair<string, AnyValue>> anyDictionary)
        {
            return anyDictionary.Select(kvp => (kvp.Key, (object)kvp.Value, true));
        }
        if (anyValue.Value is IEnumerable<KeyValuePair<string, object>> objDictionary)
        {
            return objDictionary.Select(kvp => (kvp.Key, kvp.Value, true));
        }
        if (anyValue.Value.IsIntrisinc() || anyValue.Value is IEnumerable) // TODO: Arrays can also support intrisincs?
        {
            return Enumerable.Empty<(string Key, object Value, bool Pathable)>();
        }

        return anyValue.Value.GetType()
            .GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty)
            .Select(m => (m.Name, m.GetValue(anyValue.Value), true)); 
    }
}
