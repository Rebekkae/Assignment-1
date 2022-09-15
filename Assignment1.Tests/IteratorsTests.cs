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

    [Fact]
    public void flatten_from_lists_1_2_3_and_1_2_3_return_list_of_1_2_3_1_2_3() {

        // Arrange
        IEnumerable<IEnumerable<int>> streamOfStream = new [] { new[] {1, 2, 3}, new[] {1, 2, 3} };

        // Act
        var result = Iterators.Flatten(streamOfStream);

        // Assert
        Assert.Equal(new[] {1, 2, 3, 1, 2, 3}, result);

    }

    [Fact]
    public void filter_with_even_predicate_given_1_to_5_returns_2_and_4() {

        // Arrange
        IEnumerable<int> stream = new [] {1, 2, 3, 4, 5};
        Predicate<int> even = Even;
        bool Even(int i) => i % 2 == 0;

        // Act
        var result = Iterators.Filter(stream, even);

        // Assert
        Assert.Equal(new[] {2, 4}, result);
    }
    
    [Fact]
    public void filter_with_odd_predicate_given_1_to_5_returns_1_3_5() {

        // Arrange
        IEnumerable<int> stream = new [] {1, 2, 3, 4, 5};
        Predicate<int> odd = Odd;
        bool Odd(int i) => i % 2 != 0;

        // Act
        var result = Iterators.Filter(stream, odd);

        // Assert
        Assert.Equal(new[] {1, 3, 5}, result);
    }

    [Fact]
    public void filter_with_greater_than_5_predicate_given_1_to_10_returns_6_7_8_9_10() {

        // Arrange
        IEnumerable<int> stream = new [] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        Predicate<int> greaterThanFive = GreaterThanFive;
        bool GreaterThanFive(int i) => i > 5;

        // Act
        var result = Iterators.Filter(stream, greaterThanFive);

        // Assert
        Assert.Equal(new[] {6, 7, 8, 9, 10}, result);
    }
}