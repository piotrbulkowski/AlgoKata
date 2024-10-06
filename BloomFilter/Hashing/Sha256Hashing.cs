using System.Security.Cryptography;

namespace BloomFilter.Hashing;

internal sealed class Sha256Hashing : IHashingAlgorithm
{
    public int ComputeHash(ReadOnlySpan<byte> data)
    {
        using var sha256 = SHA256.Create();
        var digest = new byte[sha256.HashSize / 8];
            
        sha256.TryComputeHash(data, digest, out _);

        return BitConverter.ToInt32(digest);
    }
}