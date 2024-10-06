using BloomFilter.Hashing;

namespace BloomFilter.UnitTests;

public class InMemoryFilterTests
{
    [Fact]
    public void Contains_ShouldReturnTrue_WhenElementExistsInFilter()
    {
        // Arrange
        const int capacity = 16; // Capacity of the BitArray
        ReadOnlySpan<byte> data = [1, 2, 3, 4]; // Data to be hashed

        // Create a mock of the IHashingAlgorithm
        var sha256HashAlgorithm = new Sha256Hashing();
        var filter = new InMemoryFilter(capacity, sha256HashAlgorithm);

        // Act
        filter.Add(data);
        var isContained = filter.Contains(data);

        // Assert
        Assert.True(isContained);
    }

    [Fact]
    public void Contains_ShouldReturnFalse_WhenElementDoesNotExistInFilter()
    {
        // Arrange
        const int capacity = 16; // Capacity of the BitArray
        ReadOnlySpan<byte> data = [1, 2, 3, 4]; // Data to be hashed
        var sha256HashAlgorithm = new Sha256Hashing();
        var filter = new InMemoryFilter(capacity, sha256HashAlgorithm);

        // Act
        
        var isContained = filter.Contains(data);
        
        // Assert
        Assert.False(isContained);
    }
}