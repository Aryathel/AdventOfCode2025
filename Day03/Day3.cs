namespace AdventOfCode2025.Day03;

public class Day3(string input) : Day<long, long>(input, true)
{
    protected override int DayNumber => 3;
    
    private readonly List<BatteryBank> _batteries = [];
    
    protected override void Parse()
    {
        foreach (var line in _rawInput.Split(Environment.NewLine))
            _batteries.Add(new BatteryBank(line));
    }

    /// <summary>
    /// Find the maximum value that a battery bank can create with a given number of digits.
    /// </summary>
    /// <param name="bank">The collection of batteries to find the value from.</param>
    /// <param name="numDigits">The number of digits the return value should have.</param>
    /// <returns>The solved maximum value of the battery bank.</returns>
    private static long MaxBankValue(BatteryBank bank, int numDigits)
    {
        long value = 0;
        var index = -1;
        // Iterate over the number of digits there are.
        for (var i = numDigits; i > 0; i--)
        {
            // Find the largest digit and the index the largest digit occurs at, excluding enough values to
            // add the extra digits we need later.
            (var digit, index) = bank.MaxExcludingLastDigits(i-1, index+1);
            // Correct the digit to the place it needs to be in.
            value += digit * (long)Math.Pow(10, i-1);
        }

        return value;
    }
    
    protected override void ExecutePart1()
    {
        Part1 = 0;

        foreach (var bank in _batteries)
            Part1 += MaxBankValue(bank, 2);
    }

    protected override void ExecutePart2()
    {
        Part2 = 0;
        foreach (var bank in _batteries)
            Part2 += MaxBankValue(bank, 12);      
    }
}