using BenchmarkDotNet.Attributes;
using Naive;
using VectorSpanMath;

namespace Benchmarks;

[MemoryDiagnoser]
public class BenchyProd
{
    double[] a    = new double[100];
    double[] b    = new double[100];

    [GlobalSetup]
    public void Init() {
        for (int i = 0; i < 100; i++) {
            a[i] = Random.Shared.NextDouble();
            b[i] = Random.Shared.NextDouble();
        }
    }

    [Benchmark]
    public void Vector() {
        a.AsSpan().Multiply(b);
    }

    [Benchmark(Baseline = true)]
    public void Baseline() {
        NaiveImpl.Multiply<double>(a, b);
    }
}