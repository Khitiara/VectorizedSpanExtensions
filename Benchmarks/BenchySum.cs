using BenchmarkDotNet.Attributes;
using Naive;
using VectorSpanMath;

namespace Benchmarks;

[MemoryDiagnoser]
public class BenchySum
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
        a.AsSpan().Add(b);
    }

    [Benchmark(Baseline = true)]
    public double Baseline() => NaiveImpl.Dot<double>(a, b);
}