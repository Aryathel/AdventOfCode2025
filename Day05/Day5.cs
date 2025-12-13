namespace AdventOfCode2025.Day05;

public class Day5(string input) : Day<int, long>(input, false)
{
    protected override int DayNumber => 5;

    private List<long> _ingredients;
    private FreshIngredients _freshIngredients;
    
    protected override void Parse()
    {
        // Split the ingredient ranges from the ingredient list
        var split = _rawInput.Split(Environment.NewLine + Environment.NewLine);
        
        // Read the ranges for fresh ingredients
        _freshIngredients = new FreshIngredients(split[0]);
        // Read the list of ingredient IDs
        _ingredients = split[1].Split('\n')
            .Select(long.Parse)
            .ToList();
    }

    protected override void ExecutePart1()
    {
        Part1 = 0;
        
        // Loop through all ingredients and check that they are in one of the fresh ingredient ranges.
        foreach (var ing in _ingredients)
            if (_freshIngredients.IsFresh(ing))
                Part1++;
    }

    protected override void ExecutePart2()
    {
        Part2 = 0;

        // Loop through all ranges and count the number of IDs it encompasses (inclusive)
        foreach (var range in _freshIngredients.MergedRanges)
            Part2 += range.Item2 - range.Item1 + 1;
    }
}