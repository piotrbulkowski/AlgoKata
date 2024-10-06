using BloomFilter.Hashing;

namespace BloomFilter.UnitTests.Hashing;

public class Sha256HashingTests
{
    [Fact]
    public void ComputeHash_ShouldReturnDifferentHash_ForDifferentData()
    {
        // Arrange
        var hashingAlgorithm = new Sha256Hashing();
        
        ReadOnlySpan<byte> data1 = [1, 2];
        ReadOnlySpan<byte> data2 = [3, 4];

        // Act
        var firstHash = hashingAlgorithm.ComputeHash(data1);
        var secondHash = hashingAlgorithm.ComputeHash(data2);

        // Assert
        Assert.NotEqual(firstHash, secondHash);
    }

    [Fact]
    public void ComputeHash_ShouldReturnSameHash_ForSameData()
    {
        // Arrange
        var hashingAlgorithm = new Sha256Hashing();
        ReadOnlySpan<byte> data = [1, 2, 3, 4, 5, 6, 7, 8];

        // Act
        var firstHash = hashingAlgorithm.ComputeHash(data);
        var secondHash = hashingAlgorithm.ComputeHash(data);

        // Assert
        Assert.Equal(firstHash, secondHash);
    }
}