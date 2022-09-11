namespace Assignment1.Tests;

public class IteratorsTests {

    [Fact]

    public void flatten_from_lists_1_2_and_3_4_return_list_of_1_2_3_4() {

        // Arrange
        IEnumerable<IEnumerable<int>> streamOfStream = new [] { new[] {1, 2}, new[] {3, 4} };

        // Act
        var result = Iterators.Flatten(streamOfStream);

        // Assert
        Assert.Equal(new[] {1, 2, 3, 4}, result);

    }
}