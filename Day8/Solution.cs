namespace aoc_2021.Day8
{
    internal class Solution
    {
        public long Solve()
        {
            var positions = File.ReadAllLines("Day8/input")[0].Split(',').Select(int.Parse).GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
           
            return -1;
        }
    }
}