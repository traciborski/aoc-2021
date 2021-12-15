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
            public bool IsVertical => X1 == X2;

            public override string ToString()
            {
                return $"{X1},{Y1} -> {X2},{Y2}";
            }
        }

        public int Solve()
        {
            var lines = File.ReadAllLines("Day5/input");

            var lines2 = new List<Line>();

            foreach (var line in lines)
            {
                lines2.Add(ParseLine(line));
            }

            var board = new List<List<int>>();

            const int size = 1000;
            for (var i = 0; i < size; i++)
            {
                board.Add(Enumerable.Repeat(0, size).ToList());
            }

            foreach (var line in lines2)
            {
                if (line.IsHorizontal)
                {
                    var min = Math.Min(line.X1, line.X2);
                    var max = Math.Max(line.X1, line.X2);
                    for (var x = min; x <= max; x++)
                    {
                        board[line.Y1][x]++;
                    }
                }
                else if (line.IsVertical)
                {
                    var min = Math.Min(line.Y1, line.Y2);
                    var max = Math.Max(line.Y1, line.Y2);
                    for (var y = min; y <= max; y++)
                    {
                        board[y][line.X1]++;
                    }
                }
                else
                {
                    var xStep = line.X2 > line.X1 ? 1 : -1;
                    var yStep = line.Y2 > line.Y1 ? 1 : -1;
                    var x = line.X1;
                    var y = line.Y1;
                    while (x != line.X2)
                    {
                        board[y][x]++;

                        x += xStep;
                        y += yStep;
                    }
                    board[y][x]++;
                }
            }
            
            return board.SelectMany(x => x).Count(x => x > 1);
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