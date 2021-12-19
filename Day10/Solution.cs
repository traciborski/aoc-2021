namespace aoc_2021.Day10
{
    internal class Solution
    {
        record Position(int Row, int Col);

        public long Solve()
        {
            var lines = File.ReadAllLines("Day10/input");
            var scores = new List<long>();
            foreach (var line in lines)
            {
                var score = Score(line.ToCharArray());
                if(score > 0)
                    scores.Add(score);
            }
            return scores.OrderBy(x => x).ToArray()[scores.Count / 2];
        }

        private long Score(char[] line)
        {
            var stack = new Stack<char>();
            foreach (var c in line)
            {
                if (IsStart(c))
                {
                    stack.Push(c);
                }
                else
                {
                    var start = Map(c);
                    var expected = stack.Pop();
                    if (expected != start)
                    {
                        return 0;
                        //continue;
                        //return Mulitplier(c);
                    }
                }
            }

            var result = 0L;
            foreach (var c in stack)
            {
                result = result * 5L + MulitplierIncomplete(c);
            }
            return result;
        }

        private char Map(char c)
        {
            switch (c)
            {
                case ')': return '(';
                case ']': return '[';
                case '}': return '{';
                case '>': return '<';
                default: throw new Exception();
            }
        }

        private int MulitplierIncomplete(char c)
        {
            switch (c)
            {
                case '(': return 1;
                case '[': return 2;
                case '{': return 3;
                case '<': return 4;
                default: throw new Exception();
            }
        }

        private int MulitplierInvalid(char c)
        {
            switch (c)
            {
                case ')': return 3;
                case ']': return 57;
                case '}': return 1197;
                case '>': return 25137;
                default: throw new Exception();
            }
        }

        private bool IsStart(char c)
        {
            return new[] { '[', '(', '{', '<' }.Contains(c);
        }
    }
}