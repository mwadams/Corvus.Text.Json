using System;
using System.Text;
using Corvus.Text.Json;

byte[] uriBytes = Encoding.UTF8.GetBytes("g:h");
Console.WriteLine($"Trying to parse: g:h");
try
{
    var uri = Utf8Uri.CreateUri(uriBytes);
    Console.WriteLine($"Success: {uri}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
    Console.WriteLine($"Type: {ex.GetType().Name}");
}
