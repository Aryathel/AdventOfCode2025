using System.Collections;

namespace AdventOfCode2025.Day02;

/// <summary>
/// Maintains a range of values input as a string like "100-451" and allows
/// iterating over all number values in that range.
/// </summary>
/// <param name="range">The input range in the format "#-#".</param>
public class Range(string range) : IEnumerable<string>
{
    private readonly string _start = range.Split('-')[0];
    private readonly string _end = range.Split('-')[1];

    public IEnumerator<string> GetEnumerator()
    {
        for (var i = long.Parse(_start); i <= long.Parse(_end); i++)
            yield return i.ToString();
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}