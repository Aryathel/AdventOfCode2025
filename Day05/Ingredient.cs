namespace AdventOfCode2025.Day05;

public readonly struct FreshIngredients
{
    public readonly List<Tuple<long, long>> MergedRanges = [];
    
    public FreshIngredients(string values)
    {
        // Read the ranges into a list of tuples, then order by the first item in the list.
        var ranges = values.Split(Environment.NewLine)
            .Select(range =>
            {
                var split = range.Split('-')
                    .Select(long.Parse)
                    .ToArray();
                return new Tuple<long, long>(split[0], split[1]);
            })
            .OrderBy(r => r.Item1);

        // Loop over all ranges to merge any overlapping ranges.
        foreach (var range in ranges)
        {
            // If there are no ranges tracked yet, add it right away
            if (MergedRanges.Count == 0)
                MergedRanges.Add(range);

            // If the range overlaps with the last range in the already merged lise,
            // update it with the larger of the two item 2 values.
            // (since we ordered by Item1 previously, the already merged item is guaranteed to have the lower start
            // value for the range)
            else if (range.Item1 - 1 <= MergedRanges[^1].Item2)
                MergedRanges[^1] = new Tuple<long, long>(MergedRanges[^1].Item1, Math.Max(MergedRanges[^1].Item2, range.Item2));
            
            // If the range does not overlap with an existing range, just add the range to the list.
            else
                MergedRanges.Add(range);
        }
    }

    /// <summary>
    /// Check if a given ingredient ID is in any of the fresh ingredient ranges.
    /// </summary>
    /// <param name="id">The fresh ingredient ID.</param>
    /// <returns>Whether the ID is fresh.</returns>
    public bool IsFresh(long id) => MergedRanges.Any(range => range.Item1 <= id && id <= range.Item2);
    
    /// <summary>
    /// Used for debugging the merged ranges.
    /// </summary>
    public override string ToString() => string.Join('\n', MergedRanges.Select(r => $"{r.Item1}-{r.Item2}"));
}