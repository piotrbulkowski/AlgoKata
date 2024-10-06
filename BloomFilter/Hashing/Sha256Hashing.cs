using System.Security.Cryptography;

namespace BloomFilter.Hashing;

internal sealed class Sha256Hashing : IHashingAlgorithm
{
    private static readonly SHA256 _sha256 = SHA256.Create();
    public int ComputeHash(ReadOnlySpan<byte> data)
    {
        Span<byte> digest = stackalloc byte[32];
            
        _sha256.TryComputeHash(data, digest, out _);

        return BitConverter.ToInt32(digest);
    }
    public int ComputeHashFaster(ReadOnlySpan<byte> data)
    {
        Span<byte> digest = stackalloc byte[32];
            
        _sha256.TryComputeHash(data, digest, out _);

        return (digest[0] << 24) | (digest[1] << 16) | (digest[2] << 8) | digest[3];
    }
    public int ComputeHashSlow(ReadOnlySpan<byte> data)
    {
        using var sha256 = SHA256.Create();
        var digest = new byte[sha256.HashSize / 8];
            
        sha256.TryComputeHash(data, digest, out _);

        return BitConverter.ToInt32(digest);
    }
}