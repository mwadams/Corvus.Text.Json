var baseUri = new Uri("http://example.com/path/file?query#frag");
var relativeRef = new Uri("", UriKind.Relative);
var result = new Uri(baseUri, relativeRef);
Console.WriteLine($"Base: {baseUri}");
Console.WriteLine($"Reference: (empty)");
Console.WriteLine($"Result: {result}");
Console.WriteLine($"Has fragment: {!string.IsNullOrEmpty(result.Fragment)}");
