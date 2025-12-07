namespace AdventOfCode2025.Day01;

public enum Direction
{
    Left,
    Right,
}

public struct RotationStep(string input)
{
    public Direction Direction = input[0].Equals('L') ? Direction.Left : Direction.Right;
    public int Count = int.Parse(input[1..]);
    
    public int SignValue => Direction == Direction.Left ? -1 : 1;
    public int SignedCount => Direction == Direction.Left ? -Count : Count;

    public override string ToString() => $"{Direction.ToString()[0]}{Count}";
}