using Corvus.Text.Json;
using StringEnumerations.Models;

// Parse color enum values
string redJson = "\"red\"";
string greenJson = "\"green\"";
string blueJson = "\"blue\"";

using var parsedRed = ParsedJsonDocument<Color>.Parse(redJson);
using var parsedGreen = ParsedJsonDocument<Color>.Parse(greenJson);
using var parsedBlue = ParsedJsonDocument<Color>.Parse(blueJson);

Color red = parsedRed.RootElement;
Color green = parsedGreen.RootElement;
Color blue = parsedBlue.RootElement;

// Pattern matching without context
Console.WriteLine("Color descriptions:");
Console.WriteLine($"  {red}: {DescribeColor(red)}");
Console.WriteLine($"  {green}: {DescribeColor(green)}");
Console.WriteLine($"  {blue}: {DescribeColor(blue)}");
Console.WriteLine();

// Pattern matching WITH context (state parameter)
// Demonstrates converting colors to RGB values using a brightness multiplier
double brightnessFactor = 0.8;
Console.WriteLine($"RGB values at {brightnessFactor:P0} brightness:");
Console.WriteLine($"  {red}: {ConvertToRgb(red, brightnessFactor)}");
Console.WriteLine($"  {green}: {ConvertToRgb(green, brightnessFactor)}");
Console.WriteLine($"  {blue}: {ConvertToRgb(blue, brightnessFactor)}");

// Pattern matching function without context
string DescribeColor(in Color color)
{
    return color.Match(
        matchRed: static () => "The color of fire and passion",
        matchGreen: static () => "The color of nature and growth",
        matchBlue: static () => "The color of sky and ocean",
        defaultMatch: static () => "Unknown color");
}

// Pattern matching function WITH context parameter (avoids closures)
string ConvertToRgb(in Color color, double brightness)
{
    return color.Match(
        brightness,  // context parameter passed to all match functions
        matchRed: static (ctx) => $"RGB({(int)(255 * ctx)}, 0, 0)",
        matchGreen: static (ctx) => $"RGB(0, {(int)(255 * ctx)}, 0)",
        matchBlue: static (ctx) => $"RGB(0, 0, {(int)(255 * ctx)})",
        defaultMatch: static (ctx) => "RGB(0, 0, 0)");
}
