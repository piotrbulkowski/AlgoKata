using BenchmarkDotNet.Attributes;
using BloomFilter.Hashing;

namespace BloomFilter.PerfTests;

public class Sha256HashingPerfTests
{
    private Sha256Hashing _hashingAlgorithm;
    private byte[] _testData;

    [GlobalSetup]
    public void Setup()
    {
        _hashingAlgorithm = new Sha256Hashing();
        
        _testData = new byte[512];
        new Random().NextBytes(_testData);
    }
    
    [Benchmark]
    public int ComputeHash_TestData()
    {
        return _hashingAlgorithm.ComputeHash(_testData);
    }
}