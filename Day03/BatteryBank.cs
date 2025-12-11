using System.Collections;

namespace AdventOfCode2025.Day03;

/// <summary>
/// Contain information about a collection of batteries, stored as ushort values 1-9.
/// </summary>
/// <param name="input">The raw string of battery value digits.</param>
public readonly struct BatteryBank(string input)
{
    public string Raw => input;
    
    // Read the battery collection into a list of individual values.
    private readonly List<ushort> _values = input.ToArray()
        .Select(x => ushort.Parse(new ReadOnlySpan<char>(ref x)))
        .ToList();

    /// <summary>
    /// Find the maximum value between a given starting index and a number of values to exclude from the end.
    /// </summary>
    /// <param name="startIndex">The index to start searching from.</param>
    /// <param name="numToExclude">The number of digits to exclude from the end of the string
    /// when looking for the max value.</param>
    /// <returns>The value found and the index it was found at.</returns>
    public (ushort, int) MaxInRange(int startIndex, int numToExclude)
    {
        var max = _values[startIndex..^numToExclude].Max();
        // Return the identified maximum value as well as the first index of that value after
        // the indicated starting index.
        return (max, _values.IndexOf(max, startIndex));
    }
}