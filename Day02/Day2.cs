namespace AdventOfCode2025.Day02;

public class Day2(string input) : Day<long, long>(input, false)
{
    protected override int DayNumber => 2;
    
    private readonly List<Range> _ranges = [];
    
    protected override void Parse()
    {
        foreach (var line in _rawInput.Trim().Split(','))
            _ranges.Add(new Range(line));
    }

    /// <summary>
    /// Checks if a string value is a single value repeating twice.
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <returns>Whether the input string is a couplet.</returns>
    private static bool IsCouplet(string value)
    {
        // If the value is an odd number of characters,
        // it cannot be split in half to be repeating twice.
        if (value.Length % 2 == 1)
            return false;
        
        // Find if the first half of the string matches the second half.
        var mid = value.Length / 2;
        return value[..mid] == value[mid..];
    }
    
    protected override void ExecutePart1()
    {
        Part1 = 0;
        
        // Iterate over input ranges
        foreach (var range in _ranges)
            // Iterate over values in range where the value is a couplet.
            foreach (var val in range)
                if (IsCouplet(val))
                    Part1 += long.Parse(val);
    }

    /// <summary>
    /// Checks if any string is made up of only repeating substrings.
    /// </summary>
    /// <param name="value">The string to check for repeating substrings.</param>
    /// <returns>Whether the string is repeating.</returns>
    private static bool IsRepeating(string value)
    {
        // If there is 1 character, or empty string, the string cannot be repeating.
        if (value.Length < 2)
            return false;
        
        // Find the midpoint of the string (floored) to cap iteration,
        // since substrings longer than half the string cannot be repeating.
        var mid = value.Length / 2;

        // Iterate substring lengths from the first character.
        for (var i = 1; i <= mid; i++)
        {
            // If the string cannot have an even number of substrings of the length,
            // skip (e.g. 12345 with substring (i) of 2 would have to have 2.5 repeating terms, an impossible value)
            if (value.Length % i != 0)
                continue;
            
            // Get the segment we are referencing.
            var segment = value[..i];
            
            // Iterate over the other substrings of equal length in the value to check if
            // they match the sample segment.
            bool isRepeating = true;
            for (var j = i; j < value.Length; j += segment.Length)
                // If segment does not match, we know immediately that the string is not repeating.
                if (segment != value[j..(j + segment.Length)])
                {
                    isRepeating = false;
                    break;
                }
            
            // If the segment is marked as repeating,
            // exit the process now and stop checking the next segments.
            if (isRepeating)
                return true;
        }
        
        // Only reaches this if no repeating segments were found
        return false;
    }
    
    protected override void ExecutePart2()
    {
        Part2 = 0;

        // Iterate over input ranges
        foreach (var range in _ranges)
            // Iterate over values in range where that value is a repeating substring value.
            foreach (var val in range)
                if (IsRepeating(val))
                    Part2 += long.Parse(val);   
    }
}