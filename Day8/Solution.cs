namespace aoc_2021.Day8
{
    internal class Solution
    {
        public long Solve()
        {
            var positions = File.ReadAllLines("Day8/input").Select(x => x.Split(" | "));

            var digits = new[]
            {
                2,
                3,
                4,
                7
            };
            var count = 0;
            foreach (var position in positions)
            {
                var left = Normalize(position[0]);
                var right = Normalize(position[1]);
                foreach (var digit in digits)
                {
                    if (right.Count(x => x.Length == digit) >= 1 && left.Count(x => x.Length == digit) >= 1)
                    {
                        count += right.Count(x => x.Length == digit);
                    }
                }
            }
            return count;
        }

        private List<string> Normalize(string words)
        {
            return words.Split(" ").Select(x => new string(x.ToCharArray().OrderBy(x => x).ToArray())).ToList();
        }
    }
}