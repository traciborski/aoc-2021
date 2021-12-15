namespace aoc_2021.Day7
{
    internal class Solution
    {
        public long Solve()
        {
            var positions = File.ReadAllLines("Day7/input")[0].Split(',').Select(int.Parse).GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

            var min = positions.Select(x => x.Key).Min();
            var max = positions.Select(x => x.Key).Max();

            var result = int.MaxValue;
            for (var position = min; position <= max; position++)
            {
                var fuel = Fuel(position, positions);
                if (fuel < result)
                {
                    result = fuel;
                }
            }
           
            return result;
        }

        private int Fuel(int current, Dictionary<int, int> positions)
        {
            var fuel = 0;
            foreach (var position in positions)
            {

                fuel += position.Value * (Math.Abs(position.Key - current));
            }
            return fuel;
        }
    }
}