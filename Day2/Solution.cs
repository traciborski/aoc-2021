namespace aoc_2021.Day2
{
    internal class Solution
    {
        public int Solve()
        {
            var lines = File.ReadAllLines("Day2/input");
            var horizontal = 0;
            var depth = 0;
            var aim = 0;
            for (var i = 0; i < lines.Length; i++)
            {
                var parts = lines[i].Split(' ');
                var command = parts[0];
                var value = int.Parse(parts[1]);
                if (command == "forward")
                {
                    horizontal += value;
                    depth += value * aim;
                }
                else if (command == "down")
                {
                    aim += value;
                }
                else if (command == "up")
                {
                    aim -= value;
                }
                else
                {
                    throw new Exception();
                }
            }
            return horizontal * depth;
        }
    }
}
