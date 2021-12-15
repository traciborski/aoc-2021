namespace aoc_2021.Day6
{
    internal class Solution
    {
        public int Solve()
        {
            var items = File.ReadAllLines("Day6/input")[0].Split(',').Select(x => int.Parse(x)).ToList();

            for (int day = 0; day < 80; day++)
            {
                var len = items.Count;
                for (int i = 0; i < len; i++)
                {
                    var item = items[i];
                    if (item == 0)
                    {
                        items[i] = 6;
                        items.Add(8);
                    }
                    else
                    {
                        items[i]--;
                    }
                }
            }

            return items.Count;
        }
    }
}