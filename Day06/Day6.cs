namespace AdventOfCode2025.Day06;

public class Day6(string input) : Day<ulong, ulong>(input, true)
{
    protected override int DayNumber => 6;

    private readonly List<Operation> _operations = [];
    
    protected override void Parse()
    {
        List<List<ulong>> values = [];
        List<OperationType> operations = [];
        
        foreach (var line in _rawInput.Split(Environment.NewLine, StringSplitOptions.TrimEntries))
            if (!char.IsDigit(line[0]))
                operations.AddRange(line.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .Select(c => c.ToOperationType()));
            else
                values.Add(line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(ulong.Parse).ToList());
        
        for (var i = 0; i < operations.Count; i++)
            _operations.Add(new Operation(values.Select(v => v[i]).ToList(), operations[i]));
    }

    protected override void ExecutePart1()
    {
        Part1 = 0;

        foreach (var operation in _operations)
            Part1 += operation.Solve();
    }

    protected override void ExecutePart2()
    {
        Part2 = 0;
    }
}