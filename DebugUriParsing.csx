using System;
using System.Text;
using Corvus.Text.Json;

var refBytes = Encoding.UTF8.GetBytes("//g");
var uriRef = Utf8UriReference.CreateUriReference(refBytes);

Console.WriteLine($"Original: //g");
Console.WriteLine($"IsRelative: {uriRef.IsRelative}");
Console.WriteLine($"HasScheme: {uriRef.HasScheme}");
Console.WriteLine($"HasAuthority: {uriRef.HasAuthority}");
Console.WriteLine($"HasPath: {uriRef.HasPath}");
Console.WriteLine($"Scheme: '{Encoding.UTF8.GetString(uriRef.Scheme)}'");
Console.WriteLine($"Authority (User-Path): offset {uriRef._offsets.User} to {uriRef._offsets.Path}");
Console.WriteLine($"Path: '{Encoding.UTF8.GetString(uriRef.Path)}'");
