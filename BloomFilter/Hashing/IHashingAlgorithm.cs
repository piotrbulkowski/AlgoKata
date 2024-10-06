namespace BloomFilter.Hashing;

public interface IHashingAlgorithm
{
    public int ComputeHash(ReadOnlySpan<byte> data);
}