using FluentAssertions;

namespace KataNetHack.Tests
{
    public static class RendererAssertions
    {
        private static readonly string EMPTY_ROW = new string(' ', 10);

        public static void AssertRowEmpty(this RendererBuilder builder, int row)
        {
            builder.OutputLines[row].Should().Be(EMPTY_ROW);
        }
    }
}