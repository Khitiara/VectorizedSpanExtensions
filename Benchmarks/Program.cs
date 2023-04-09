// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Running;

BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).RunAllJoined(
    DefaultConfig.Instance.WithOrderer(new DefaultOrderer(SummaryOrderPolicy.Declared)));