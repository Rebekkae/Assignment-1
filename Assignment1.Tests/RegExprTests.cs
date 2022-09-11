namespace Assignment1.Tests;

public class RegExprTests {

    [Fact]
    public void splitline_given_sentences_only_return_valid_words() {

        // Arrange
        IEnumerable<string> stream = new [] { "this is a sentence", "This Is Also A Sentence", "100 + 100 gives 200"};

        // Act
        var result = RegExpr.SplitLine(stream);

        // Assert
        Assert.Equal(new[] {"this", "is", "a", "sentence", "This", "Is", "Also", "A", "Sentence", "100", "100", "gives", "200"}, result);
    }
}