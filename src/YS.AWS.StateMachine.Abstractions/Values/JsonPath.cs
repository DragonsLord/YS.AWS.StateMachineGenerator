namespace YS.AWS.StateMachine.Abstractions.Values;

public class JsonPath 
{
    public string Path { get; }

    public JsonPath(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            throw new ArgumentNullException(nameof(path));
        }

        if (!path.StartsWith("$"))
        {
            throw new ArgumentException("path should start with $ or $$");
        }

        Path = path;
    }

    public static implicit operator JsonPath(string path) => new JsonPath(path);
    public static implicit operator string(JsonPath path) => path.Path;
}
