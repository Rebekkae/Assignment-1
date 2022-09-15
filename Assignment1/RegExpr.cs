namespace Assignment1;

using System.Collections;
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
        string pattern = @"(?<width>[0-9]*)x(?<height>[0-9]*)";
        foreach (string resolution in resolutions) {
            Match match = Regex.Match(resolution, pattern);
            if (match.Success) {
                yield return (int.Parse(match.Groups["width"].Value), int.Parse(match.Groups["height"].Value));
            }
        }
    }

    public static IEnumerable<string> InnerText(string html, string tag){
        Console.WriteLine(html);
        var pattern = $"<({tag})" + @"([^>]+)*>(.+?)<\/\1>";
        var regex = new Regex(pattern);   
        foreach (Match match in regex.Matches(html)){
            yield return string.Join("", removeNestedTags(match.Value, tag)); 
        } 

    }

    public static IEnumerable<string> removeNestedTags(string html, string tag){
        var pattern = @"([\w ,()-.\/""]+(?![^<>]*>))";
        var regex = new Regex(pattern);
        foreach (Match match in regex.Matches(html)){
            yield return match.Value; 
        }
    }

    public static IEnumerable<(Uri url, string title)> Urls(string html){
        var masterPattern = @"(?<everything><(a)(?<attributes>[^>]+)*>(.+?)<\/\2>)";
        var pattern = @"([""'])(?<url>.*?)\1(\stitle=\1(?<title>.*?)\1)?";
        var regex = new Regex(masterPattern);
        var url_regex = new Regex(pattern);
        var matches = Regex.Match(html, masterPattern);
        if (matches.Success){
            foreach(Match match in regex.Matches(html)){
                foreach (Match url in url_regex.Matches(match.Groups["attributes"].Value)){
                    if (url.Groups["url"].Success){
                        Console.WriteLine("url match");
                        if (url.Groups["title"].Success){
                            yield return (new Uri(url.Groups["url"].Value), url.Groups["title"].Value);
                        }
                        else{
                            Console.WriteLine("no title match");
                            string inner = InnerText(match.Groups["everything"].Value, "a").First<string>();
                            yield return (new Uri(url.Groups["url"].Value), inner);
                        }
                    }
                }
                
            }
        }
        else{
            throw new ArgumentException("URL not found");
        }  
    }
}