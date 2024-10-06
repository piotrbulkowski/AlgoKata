using BenchmarkDotNet.Running;

namespace BloomFilter.PerfTests;

public class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<Sha256HashingPerfTests>();
    }
}