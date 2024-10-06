using System.Collections;
using BloomFilter.Hashing;

namespace BloomFilter;

public sealed class InMemoryFilter
{
    private readonly IHashingAlgorithm _hashingAlgorithm;
    private readonly BitArray _hashBucket;

    public InMemoryFilter(int capacity)
    {
        _hashingAlgorithm = new Sha256Hashing();
        _hashBucket = new BitArray(capacity);
    }
    public InMemoryFilter(int capacity, IHashingAlgorithm hashingAlgorithm)
    {
        _hashingAlgorithm = hashingAlgorithm;
        _hashBucket = new BitArray(capacity);
    }

    /// <summary>
    /// Adds the <paramref name="data"/> to the filter.
    /// </summary>
    /// <remarks>No object collision detection is performed.</remarks>
    /// <param name="data">Data to be inserted into the filter.</param>
    public void Add(ReadOnlySpan<byte> data)
    {
        var hash = _hashingAlgorithm.ComputeHash(data);
        _hashBucket[hash] = true;
    }
    /// <summary>
    /// Checks if the data element is present in the filter.
    /// </summary>
    /// <remarks>False positives are possible.</remarks> 
    /// <param name="data">Data to be queried from the filter.</param>
    /// <returns>The value if data is in the filter.</returns>
    public bool Contains(ReadOnlySpan<byte> data)
    {
        var hash = _hashingAlgorithm.ComputeHash(data);
        return _hashBucket[hash];
    }
}