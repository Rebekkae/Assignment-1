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

    public static IEnumerable<(int width, int height)> Resolution(string resolutions) => throw new NotImplementedException();

    public static IEnumerable<string> InnerText(string html, string tag) => throw new NotImplementedException();
}