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

    [Fact]
    public void innerText_given_tag_p_should_return(){
        //Arrange
        string lines = "<div>\n<p>The phrase <i>regular expressions</i> (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing <u>patterns</u> that matching <em>text</em> need to conform to.</p>\n</div>";

        //Act
        var expected = new List<string>(){"The phrase regular expressions (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing patterns that matching text need to conform to."};
        var result = RegExpr.InnerText(lines, "p");
        //Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void innerText_given_tag_a_should_return(){
        //Arrange
        string lines = @"<div>\n<p>A <b>regular expression</b>, 
        <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) 
        is, in <a href=""https://en.wikipedia.org/wiki/Theoretical_computer_science"" 
        title=""Theoretical computer science"">theoretical computer science</a> and 
        <a href=""https://en.wikipedia.org/wiki/Formal_language"" 
        title=""Formal language"">formal language</a> theory, a sequence of 
        <a href=""https://en.wikipedia.org/wiki/Character_(computing)"" 
        title=""Character (computing)"">characters</a> that define a <i>search 
        <a href=""https://en.wikipedia.org/wiki/Pattern_matching"" 
        title=""Pattern matching"">pattern</a></i>. Usually this pattern is then 
        used by <a href=""https://en.wikipedia.org/wiki/String_searching_algorithm"" 
        title=""String searching algorithm"">string searching algorithms</a> for 
        ""find"" or ""find and replace"" operations on 
        <a href=""https://en.wikipedia.org/wiki/String_(computer_science)"" 
        title=""String (computer science)"">strings</a>.</p>\n</div>";

        //Act
        var expected = new List<string>(){"theoretical computer science", 
        "formal language", "characters", "pattern", "string searching algorithms", "strings"};
        var result = RegExpr.InnerText(lines, "a");
        //Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void url_test_given_title_returns_title()
    {
        //Arrange
        string html = "<div>\r\n\t<h2>\r\n\t\t<a href=\"https://www.w3schools.com\" title=\"HTML Tutorial\"> Go to W3Schools </a>\r\n\t</h2>\r\n</div>";

        //Act
        var expected = new[]{(new Uri("https://www.w3schools.com"), "HTML Tutorial") };

        var result = RegExpr.Urls(html);

        //Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void url_test_given_notitle_returns_innertext()
    {
        //Arrange
        string html = "<div>\r\n\t<h2>\r\n\t\t<a href=\"https://www.w3schools.com\"> Go to W3Schools </a>\r\n\t</h2>\r\n</div>";

        //Act
        var expected = new []{(new Uri("https://www.w3schools.com"), "Go to W3Schools") };

        var result = RegExpr.Urls(html);

        //Assert
        Assert.Equal(expected, result);
    }
}