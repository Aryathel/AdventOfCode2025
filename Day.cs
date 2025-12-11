using System.Diagnostics;

namespace AdventOfCode2025;

/// <summary>
/// Base class for use with all AoC Days.
/// </summary>
/// <typeparam name="T1">The type of the answer for Part 1.</typeparam>
/// <typeparam name="T2">The type of the answer for Part 2.</typeparam>
public abstract class Day<T1, T2>
{   
    protected readonly string _rawInput;
    private readonly bool _debug;
    private TimeSpan _executionTime;
    
    /// <param name="rawInput">The raw input string to parse for the problem.</param>
    /// <param name="debug">Whether to print debug statements to the console.</param>
    protected Day(string rawInput, bool debug = false)
    {
        _rawInput = rawInput;
        _debug = debug;
        Part1 = default;
        Part2 = default;
    }
    
    /// <summary>
    /// The number of the day for a class inheriting from this.
    /// </summary>
    protected abstract int DayNumber { get; }
    
    /// <summary>
    /// The Part 1 answer.
    /// </summary>
    protected T1 Part1 { get; set; }
    /// <summary>
    /// The Part 2 answer.
    /// </summary>
    protected T2 Part2 { get; set; }
    
    /// <summary>
    /// Parse the raw input string into a usable format.
    /// </summary>
    protected abstract void Parse();
    /// <summary>
    /// Solve for Part 1.
    /// </summary>
    protected abstract void ExecutePart1();
    /// <summary>
    /// Solve for Part 2.
    /// </summary>
    protected abstract void ExecutePart2();

    /// <summary>
    /// Show the results of solving for the days.
    /// </summary>
    public virtual Day<T1, T2> Display()
    {
        Console.Write("Day {0}:", DayNumber);
        if (_executionTime != default)
            Console.Write("\t{0}ms", _executionTime.TotalMilliseconds);
        Console.WriteLine("\n\tPart 1: {0}", Part1);
        Console.WriteLine("\tPart 2: {0}", Part2);
        return this;
    }

    /// <summary>
    /// Print a line to the console if debug is enabled.
    /// </summary>
    protected virtual void Debug(string format, params object?[]? args)
    {
        if (_debug)
            Console.WriteLine(format, args);
    }
    
    /// <summary>
    /// Parse the raw input and execute both Parts 1 & 2.
    /// </summary>
    public virtual Day<T1, T2> Execute()
    {
        var sw = Stopwatch.StartNew();
        Debug("Parsing Day {0} Input...", DayNumber);
        Parse();
        
        Debug("\nSolving Day {0} Part 1...", DayNumber);
        ExecutePart1();
        
        Debug("\nSolving Day {0} Part 2...", DayNumber);
        ExecutePart2();
        
        sw.Stop();
        _executionTime = sw.Elapsed;
        
        Debug(string.Empty);
        
        return this;
    }
}