namespace aoc_2021.Day1
{
    internal class Solution
    {
        public int Solve()
        {
            var lines = File.ReadAllLines("Day1/input");
            var count = 0;
            for (var i = 0; i < lines.Length - 3; i++)
            {
                var number0 = int.Parse(lines[i]);
                var number1 = int.Parse(lines[i + 1]);
                var number2 = int.Parse(lines[i + 2]);
                var number3 = int.Parse(lines[i + 3]);
                var sum1 = number0 + number1 + number2;
                var sum2 = number1 + number2 + number3;
                if (sum2 > sum1)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
