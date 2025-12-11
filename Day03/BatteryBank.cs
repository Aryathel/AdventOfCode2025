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
    /// Find the maximum value excluding the last battery value - since we require 2 digits for part 1,
    /// this can find the first digit.
    /// </summary>
    /// <param name="numToExclude">The number of digits to exclude from the end of the string
    /// when looking for the max value.</param>
    /// <param name="startIndex">The location in the string to start searching from.</param>
    /// <returns>The value found and the index it was found at.</returns>
    public (ushort, int) MaxExcludingLastDigits(int numToExclude, int startIndex = 0)
    {
        var max = _values[startIndex..^numToExclude].Max();
        // Return the identified maximum value as well as the first index of that value after
        // the indicated starting index.
        return (max, _values.IndexOf(max, startIndex));
    }
}