using System.Security.Cryptography;

namespace BloomFilter.Hashing;

internal sealed class Sha256Hashing : IHashingAlgorithm, IDisposable
{
    private static readonly SHA256 Sha256 = SHA256.Create();
    public int ComputeHash(ReadOnlySpan<byte> data)
    {
        Span<byte> digest = stackalloc byte[32];
            
        Sha256.TryComputeHash(data, digest, out _);

        return BitConverter.ToInt32(digest);
    }

    public void Dispose()
        => Sha256.Dispose();
}