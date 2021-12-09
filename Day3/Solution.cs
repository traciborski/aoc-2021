namespace aoc_2021.Day3
{
    internal class Solution
    {
        public int Solve()
        {
            var lines = File.ReadAllLines("Day3/input");
            var epsilon = 0;
            var gamma = 0;

            var ones = new List<int>();
            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                for (int j = 0; j < line.Length; j++)
                {
                    char character = line[j];
                    if (ones.Count < j + 1)
                    {
                        ones.Add(0);
                    }
                    if (character == '1')
                    {
                        ones[j]++;
                    }
                }
            }

            //01011010010111
            // two numbers
            var total = lines.Length;
            var multiplier = 1;
            ones.Reverse();
            foreach (var x in ones)
            {
                if (x > total - x)
                {
                    //1
                    epsilon += multiplier;
                }
                else
                {
                    // 0
                    gamma += multiplier;
                }
                Console.WriteLine(x);
                multiplier *= 2;
            }

            Console.WriteLine();
            Console.WriteLine(epsilon);
            Console.WriteLine(gamma);

            return epsilon * gamma;
        }
    }
}
