using Corvus.Text.Json;
using NumericEnumerations.Models;

// Parse numeric enum values
string statusActiveJson = "1";
string statusInactiveJson = "2";
string statusPendingJson = "3";

using var parsedActive = ParsedJsonDocument<Status>.Parse(statusActiveJson);
using var parsedInactive = ParsedJsonDocument<Status>.Parse(statusInactiveJson);
using var parsedPending = ParsedJsonDocument<Status>.Parse(statusPendingJson);

Status active = parsedActive.RootElement;
Status inactive = parsedInactive.RootElement;
Status pending = parsedPending.RootElement;

Console.WriteLine("Status values:");
Console.WriteLine($"  {active}: {DescribeStatus(active)}");
Console.WriteLine($"  {inactive}: {DescribeStatus(inactive)}");
Console.WriteLine($"  {pending}: {DescribeStatus(pending)}");
Console.WriteLine();

// Demonstrate handling invalid values
Console.WriteLine("Testing validation:");
using var invalidDoc = ParsedJsonDocument<Status>.Parse("99");
Status invalid = invalidDoc.RootElement;
Console.WriteLine($"  Status {invalid} is valid: {invalid.EvaluateSchema()}");
Console.WriteLine();

// Pattern matching with context (state parameter)
Console.WriteLine("Pattern matching with context:");
int requestCount = 5;
Console.WriteLine($"  {active} with {requestCount} requests: {ProcessStatus(active, requestCount)}");
Console.WriteLine($"  {inactive} with {requestCount} requests: {ProcessStatus(inactive, requestCount)}");
Console.WriteLine($"  {pending} with {requestCount} requests: {ProcessStatus(pending, requestCount)}");

// Try to process invalid status - will hit default match
try
{
    Console.WriteLine($"  {invalid} with {requestCount} requests: {ProcessStatus(invalid, requestCount)}");
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"  Error: {ex.Message}");
}

// Pattern matching function without context
string DescribeStatus(in Status status)
{
    return status.Match(
        matchNumberOne: static () => "Active - system is running",
        matchNumberTwo: static () => "Inactive - system is stopped",
        matchNumberThree: static () => "Pending - system is starting",
        defaultMatch: static () => "Unknown status");
}

// Pattern matching function WITH context parameter
string ProcessStatus(in Status status, int requestCount)
{
    return status.Match(
        requestCount,  // context parameter passed to all match functions
        matchNumberOne: static (count) => $"Processing {count} requests on active system",
        matchNumberTwo: static (count) => $"Cannot process {count} requests - system inactive",
        matchNumberThree: static (count) => $"Queued {count} requests - system pending",
        defaultMatch: static (count) => throw new InvalidOperationException($"Unknown status cannot process {count} requests"));
}
