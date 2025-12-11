namespace AdventOfCode2025.Day04;

public class Day4(string input) : Day<int, int>(input, false)
{
    protected override int DayNumber => 4;

    private PaperGrid _grid;
    
    protected override void Parse() => _grid = new PaperGrid(_rawInput);

    protected override void ExecutePart1()
    {
        Part1 = 0;
        
        // Iterate the grid and count the cells that are removable.
        for (var r = 0; r < _grid.Height; r++)
        for (var c = 0; c < _grid.Width; c++)
            if (_grid.IsRemovable(r, c))
                Part1++;
    }

    protected override void ExecutePart2()
    {
        Part2 = 0;
        
        // Iterate the cells repeatedly, removing cells that can be removed,
        // until no more cells can be removed.
        int removed;
        do
        {
            removed = 0;
            for (var r = 0; r < _grid.Height; r++)
            for (var c = 0; c < _grid.Width; c++)
                if (_grid.IsRemovable(r, c))
                {
                    removed++;
                    _grid.Remove(r, c);                    
                }

            Part2 += removed;
        }
        while (removed != 0);
    }
}