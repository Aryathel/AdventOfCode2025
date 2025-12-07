namespace AdventOfCode2025.Day01;

public class Day1(string input) : Day<int, int>(input, false)
{
    protected override int DayNumber => 1;
    
    private readonly List<RotationStep> _steps = [];
    private int _start = 50;
    private int _target = 0;
    private readonly int _min = 0;
    private readonly int _max = 99;


    protected override void Parse()
    {
        foreach (var line in _rawInput.Split('\n'))
            _steps.Add(new RotationStep(line.Trim()));
    }

    protected override void ExecutePart1()
    {
        Part1 = 0;
        
        var val = _start;

        foreach (var step in _steps)
        {
            // Find the number to move ignoring excess
            var move = step.Count % (_max + 1);
            // Apply the direction to the movement
            move *= step.SignValue;
            
            // Do the raw value shift
            var shifted = val + move;
            
            // Adjust that shifted value to within the bounds of the dial
            var adjusted = shifted % (_max + 1);
            // C# does not perform the modulo operation correctly, so negative values have to be manually adjusted for.
            // (e.g. -18 % 100 = -18, not 82)
            if (adjusted < _min)
                adjusted = _max + adjusted + 1;
            
            // If the target value is reached, increment the counter.
            if (adjusted == _target)
                Part1++;
            
            Debug("Strt: {0} -> Step: {1} -> Shft: {2} -> Adj: {3} -> ZCnt: {4}", val, step, shifted, adjusted, Part1);
            val = adjusted;
        }
    }

    protected override void ExecutePart2()
    {
        Part2 = 0;

        var val = _start;
        foreach (var step in _steps)
        {
            /**** See Part 1 ****/
            var move = step.Count % (_max + 1);
            move *= step.SignValue;
            
            var shifted = val + move;
            
            var adjusted = shifted % (_max + 1);
            if (adjusted < _min)
                adjusted = _max + adjusted + 1;
            /*********************/
            
            // Get the number of complete laps that the dial turns (e.g. R478 moves 4 complete laps)
            Part2 += step.Count / (_max + 1);
            
            // If the dial did not start at 0 and is now either ending on a 0 or
            // outside the bounds of the dial, add another to the counter 
            // (e.g. Start = 3, L140 = 1 lap, then moving past 0 to get a second count.) 
            if (val != _min && (shifted <= _min || shifted > _max))
                Part2++;
            
            Debug("Strt: {0} -> Step: {1} -> Shft: {2} -> Adj: {3} -> ZCnt: {4}", val, step, shifted, adjusted, Part2);
            val = adjusted;
        }
    }
}