using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;

public class MethodBenchmarks
{
    private readonly InstanceCalculator instance = new();

    [Benchmark]
    public int StaticMethodCall() => StaticCalculator.Add(5, 10);

    [Benchmark]
    public int InstanceMethodCall() => instance.Add(5, 10);
}

public static class StaticCalculator
{
    public static int Add(int a, int b) => a + b;
}

public class InstanceCalculator
{
    public int Add(int a, int b) => a + b;
}

public class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<MethodBenchmarks>();
    }
}
