namespace AdventOfCode2025.Day06;

public enum OperationType
{
    Unknown,
    Add,
    Multiply,
}

public static class OperationTypeExtensions
{
    public static OperationType ToOperationType(this char ch) => ch switch
    {
        '+' => OperationType.Add,
        '*' => OperationType.Multiply,
        _ => OperationType.Unknown,
    };

    public static char? ToChar(this OperationType op) => op switch
    {
        OperationType.Add => '+',
        OperationType.Multiply => '*',
        _ => null
    };
}