namespace aoc_2021.Day5
{
    internal class Solution
    {
        record Line
        {
            public int X1;
            public int Y1;
            public int X2;
            public int Y2;

            public bool IsHorizontal => Y1 == Y2;
            public bool IsVertival => X1 == X2;

            public override string ToString()
            {
                return $"{X1},{Y1} -> {X2},{Y2}";
            }
        }

        public int Solve()
        {
            var lines = File.ReadAllLines("Day5/input");

            var lines2 = new List<Line>();

            foreach (var line in lines.Skip(100))
            {
                Line item = ParseLine(line);
                lines2.Add(item);
                Console.WriteLine(item);
            }

            foreach (var line in lines2)
            {
                if (line.IsHorizontal)
                {

                }
                else if (line.IsVertival)
                {

                }
                else
                {

                }

                return -1;
            }

            private Line ParseLine(string line)
            {
                var points = line.Split(" -> ");
                var point1 = points[0].Split(',');
                var point2 = points[1].Split(',');

                return new Line
                {
                    X1 = int.Parse(point1[0]),
                    Y1 = int.Parse(point1[1]),
                    X2 = int.Parse(point2[0]),
                    Y2 = int.Parse(point2[1]),
                };
            }
        }
    }