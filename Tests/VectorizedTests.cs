using FluentAssertions;
using Naive;
using VectorSpanMath;

namespace Tests;

public class VectorizedTests
{
    [Theory, AutoBigArray,]
    public void AdditionTest(float[] a, float[] b) {
        float[] sum = new float[a.Length];
        a.CopyTo(sum.AsSpan());
        NaiveImpl.Add<float>(sum, b);
        a.AsSpan().Add(b);
        a.Should().BeEquivalentTo(sum);
    }
    
    [Theory, AutoBigArray,]
    public void ProductTest(float[] a, float[] b) {
        float[] prod = new float[a.Length];
        a.CopyTo(prod.AsSpan());
        NaiveImpl.Multiply<float>(prod, b);
        a.AsSpan().Multiply(b);
        a.Should().BeEquivalentTo(prod);
    }
    
    [Theory, AutoBigArray,]
    public void DotTest(float[] a, float[] b) {
        float dot = NaiveImpl.Dot<float>(a, b);
        SpanVectorExtensions.Dot<float>(a, b).Should().Be(dot);
    }
}