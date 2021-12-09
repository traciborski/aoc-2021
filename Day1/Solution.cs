using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2021.Day1
{
    internal class Solution
    {
        public int Solve()
        {
            var lines = File.ReadAllLines("Day1/input.txt");
            var count=0;
            var previous = int.MaxValue;
            foreach (var line in lines)
            {
                var number = int.Parse(line);
                if(number > previous)
                {
                    count++;
                }
                previous = number;
            }
            return count;
        }
    }
}
