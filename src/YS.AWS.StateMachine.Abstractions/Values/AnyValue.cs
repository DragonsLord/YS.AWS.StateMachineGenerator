using System.Text.Json.Serialization;
using YS.AWS.StateMachine.Abstractions.Serialization;

namespace YS.AWS.StateMachine.Abstractions.Values;

[JsonConverter(typeof(AnyValueConverter))]
public sealed class AnyValue
{
    public object Value { get; }

    private AnyValue(object value)
    {
        Value = value;
    }

    public static implicit operator AnyValue(char d) => new AnyValue(d);
    public static implicit operator AnyValue(string d) => new AnyValue(d);

    public static implicit operator AnyValue(bool d) => new AnyValue(d);

    public static implicit operator AnyValue(byte d) => new AnyValue(d);
    public static implicit operator AnyValue(short d) => new AnyValue(d);
    public static implicit operator AnyValue(int d) => new AnyValue(d);
    public static implicit operator AnyValue(long d) => new AnyValue(d);

    public static implicit operator AnyValue(float d) => new AnyValue(d);
    public static implicit operator AnyValue(double d) => new AnyValue(d);
    public static implicit operator AnyValue(decimal d) => new AnyValue(d);

    public static implicit operator AnyValue(DateTime d) => new AnyValue(d);

    public static implicit operator AnyValue(Dictionary<string, AnyValue> d) => new AnyValue(d);

    public static AnyValue Create<T>(T value) => new AnyValue(value);
}
