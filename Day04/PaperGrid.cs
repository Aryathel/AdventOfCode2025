namespace AdventOfCode2025.Day04;


/// <summary>
/// Defined a grid, in which each space may or may not have a paper roll.
/// </summary>
/// <param name="input">The entire grid input as a string.</param>
public readonly struct PaperGrid(string input)
{
    // Read the input grid, splitting into lines and storing spots where paper exists as a boolean value.
    private readonly List<List<bool>> _grid = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
        .Select(row => row.Select(c => c == '@')
            .ToList())
        .ToList();

    /// <summary>
    /// The number of rows in the grid.
    /// </summary>
    public int Height => _grid.Count;
    /// <summary>
    /// The number of columns in a row.
    /// </summary>
    public int Width => _grid[0].Count;
    
    /// <summary>
    /// Indicates whether a paper roll is at a specified location on the grid.
    /// </summary>
    /// <param name="r">The row to check.</param>
    /// <param name="c">The column to check.</param>
    /// <returns>Whether paper is at the location.</returns>
    private bool HasPaperAt(int r, int c) => _grid[r][c];
    
    /// <summary>
    /// Counts the number of adjacent spaces from a target cell that also contain a paper roll.
    /// </summary>
    /// <remarks>Adjacency can be both orthogonal and diagonal.</remarks>
    /// <param name="row">The row to check.</param>
    /// <param name="column">The column to check.</param>
    /// <returns>The number of adjacent paper rolls, excluding the space currently being checked.</returns>
    private int CountAdjacent(int row, int column)
    {
        var rowStart = int.Max(row-1, 0);
        var rowEnd = int.Min(row+1, Height-1);
        var colStart = int.Max(column-1, 0);
        var colEnd = int.Min(column+1, Width-1);

        return _grid[rowStart..(rowEnd+1)]
            .Sum(c => c[colStart..(colEnd+1)]
                .Count(val => val))
            - (HasPaperAt(row, column) ? 1 : 0);
    }
    
    /// <summary>
    /// Combines <see cref="HasPaperAt" /> and <see cref="CountAdjacent"/> to determine if a cell is an accessible
    /// cell that contains a paper roll.
    /// </summary>
    /// <param name="r">The row to check.</param>
    /// <param name="c">The column to check.</param>
    /// <returns>Whether the target cell has a paper roll that can be removed.</returns>
    public bool IsRemovable(int r, int c) => HasPaperAt(r, c) && CountAdjacent(r, c) < 4;
    
    /// <summary>
    /// Removes paper from a target cell.
    /// </summary>
    /// <param name="r">The row to remove.</param>
    /// <param name="c">The column to remove.</param>
    public void Remove(int r, int c) => _grid[r][c] = false;
}