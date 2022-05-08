using Xunit;

namespace YS.AWS.StateMachine.Abstractions.Tests;
internal static class TestingExtensions
{
    // TODO: Should ignore order?
    public static void ShouldBeJsonString(this string target, string expected)
    {
        Assert.Equal(
            expected.ReplaceLineEndings("").Replace(" ", ""),
            target.ReplaceLineEndings("").Replace(" ", "")
        );
    }
}
