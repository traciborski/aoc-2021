namespace aoc_2021.Day3
{
    internal class Solution
    {
        public int Solve()
        {
            var lines = File.ReadAllLines("Day3/input");

            var ogr = lines.ToList();
            var csr = lines.ToList();

            for (int i = 0; i < 12; i++)
            {
                int x = Ones(ogr)[i];
                var total = ogr.Count(x => x != null);
                if (x >= total - x)
                {
                    LeaveOnly(ogr, i, '1');
                }
                else
                {
                    LeaveOnly(ogr, i, '0');
                }
            }

            for (int i = 0; i < 12; i++)
            {
                int ones = Ones(csr)[i];
                var total = csr.Count(x => x != null);

                if (ones >= total - ones)
                {
                    LeaveOnly(csr, i, '0');
                }
                else
                {
                    LeaveOnly(csr, i, '1');
                }
            }

            return Decimal(ogr.First(x => x != null)) * Decimal(csr.First(x => x != null));
        }

        private int Decimal(string s)
        {
            return Convert.ToInt32(s, 2);
        }

        private List<int> Ones(List<string> lines)
        {
            var ones = new List<int>();
            for (var i = 0; i < lines.Count; i++)
            {
                var line = lines[i];
                if (line == null)
                {
                    continue;
                }
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
            return ones;
        }

        private void LeaveOnly(List<string> list, int position, char zeroOrOne)
        {
            for (int j = 0; j < list.Count; j++)
            {
                if (list[j] != null && list[j][position] != zeroOrOne)
                {
                    if (list[j] != null && list.Count(x => x != null) > 1)
                    {
                        list[j] = null;
                    }
                }
            }
        }
    }
}
