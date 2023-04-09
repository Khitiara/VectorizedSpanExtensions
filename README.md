# VectorizedSpanExtensions

Vectorized dot product and elementwise += and *= for generically typed spans using dotnet 7 generic math.

Benchmark results on my machine with 100 items:

|       Type |   Method |     Mean |    Error |   StdDev | Ratio | Allocated | Alloc Ratio |
|----------- |--------- |---------:|---------:|---------:|------:|----------:|------------:|
|  BenchyDot |   Vector | 36.29 ns | 0.432 ns | 0.404 ns |  0.53 |         - |          NA |
|  BenchyDot | Baseline | 68.05 ns | 0.508 ns | 0.476 ns |  1.00 |         - |          NA |
| BenchyProd |   Vector | 23.53 ns | 0.145 ns | 0.113 ns |  0.35 |         - |          NA |
| BenchyProd | Baseline | 57.89 ns | 0.359 ns | 0.300 ns |  0.85 |         - |          NA |
|  BenchySum |   Vector | 23.23 ns | 0.241 ns | 0.201 ns |  0.34 |         - |          NA |
|  BenchySum | Baseline | 68.62 ns | 0.513 ns | 0.455 ns |  1.01 |         - |          NA |
