using AutoFixture;
using AutoFixture.Xunit2;

namespace Tests;

public class AutoBigArrayAttribute : AutoDataAttribute
{
    public AutoBigArrayAttribute(int count = 100) : base(() => new Fixture { RepeatCount = count, }) {
        Count = count;
    }

    public int Count { get; }
}