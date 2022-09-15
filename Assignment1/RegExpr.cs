namespace Assignment1;
using System.Text.RegularExpressions;
public static class RegExpr {
    public static IEnumerable<string> SplitLine(IEnumerable<string> lines) {
        string pattern = @"[a-zA-Z0-9]+";
        foreach (string s in lines) {
           foreach (Match match in Regex.Matches(s, pattern)) {
                yield return match.ToString();
            }
        }
    }

    public static IEnumerable<(int width, int height)> Resolution(IEnumerable<string> resolutions) {
        string pattern = @"(?<width>[0-9]*)x*(?<height>[0-9]*)";
        foreach (string resolution in resolutions) {
            Match match = Regex.Match(resolution, pattern);
            if (match.Success) {
                yield return (Int32.Parse(match.Groups["width"].Value), Int32.Parse(match.Groups["height"].Value));
            }
        }
    }

    public static IEnumerable<string> InnerText(string html, string tag) => throw new NotImplementedException();
}