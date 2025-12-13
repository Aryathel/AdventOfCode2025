namespace AdventOfCode2025.Day06;

public readonly struct Operation(List<ulong> values, OperationType operationType)
{
    public ulong Solve() => operationType switch
    {
        OperationType.Add => values.Aggregate((a, b) => a + b),
        OperationType.Multiply => values.Aggregate((a, b) => a * b),
        _ => throw new NotImplementedException("That operation type is not implemented."),
    };

    public override string ToString() => string.Join($" {operationType.ToChar() ?? '?'} ", values) + $" = {Solve()}";
}