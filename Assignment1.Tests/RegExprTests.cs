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

    [Fact]
    public void splitline_given_special_characters_return_empty()
    {

        // Arrange
        IEnumerable<string> stream = new[] { " , ", " ? ", " ! ", " . "};

        // Act
        var result = RegExpr.SplitLine(stream);

        // Assert
        Assert.Equal(Array.Empty<string>(), result);
    }

    [Fact]
    public void resolution_when_given_4_resolutions_return_stream_of_4_tuples() {

        // Arrange
        string[] input = new [] {"1920x1080" , "1024x768" , "800x600" , "640x480"};

        // Act
        var result = RegExpr.Resolution(input);

        // Assert
        Assert.Equal(new[] { (1920, 1080), (1024, 768), (800, 600), (640, 480)}, result);
    }
}