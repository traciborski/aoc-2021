namespace aoc_2021.Day6
{
    internal class Solution
    {
        public long Solve()
        {
            var items = File.ReadAllLines("Day6/input")[0].Split(',').Select(int.Parse).GroupBy(x => x).ToDictionary(x => x.Key, x => x.LongCount());
            for (var i = 0; i < 9; i++)
            {
                if (!items.ContainsKey(i))
                {
                    items[i] = 0;
                }
            }

            for (var day = 0; day < 256; day++)
            {
                var zeros = items[0];
                for (var i = 0; i < 9; i++)
                {
                    if (i == 6)
                        items[i] = items[i + 1] + zeros;
                    else if (i == 8)
                        items[i] = zeros;
                    else
                        items[i] = items[i + 1];
                }
            }

            return Sum(items);
        }

        private long Sum(Dictionary<int, long> items)
        {
            var sum = 0L;
            for (var i = 0; i < 9; i++)
            {
                sum += items[i];
            }
            return sum;
        }
    }
}