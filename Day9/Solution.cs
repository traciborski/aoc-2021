namespace aoc_2021.Day9
{
    internal class Solution
    {
        record Position(int Row, int Col);

        public long Solve()
        {
            var rows = File.ReadAllLines("Day9/input");
            var board = rows.Select(r => r.ToCharArray().Select(x => x - '0').ToList()).ToList();
            var sum = 0;
            var basins = new List<List<Position>>();
            for (var row = 0; row < board.Count; row++)
            {
                for (var col = 0; col < board[row].Count; col++)
                {
                    if (IsLowPoint(board, row, col))
                    {
                        // sum += board[row][col] + 1; // part 1
                        basins.Add(GetBasin(board, row, col));
                    }
                }
            }
            var x = basins.OrderByDescending(x => x.Count).Take(3).Select(x=>x.Count).ToList();
            return x[0] * x[1] * x[2];
        }

        private List<Position> GetBasin(List<List<int>> board, int row, int col)
        {
            var item = new Position(row, col);
            var basin = new List<Position> { item };
            var candidates = new Stack<Position>();
            candidates.Push(item);
            AddToBasin(board, basin, candidates);
            return basin;
        }

        private void AddToBasin(List<List<int>> board, List<Position> basin, Stack<Position> candidates)
        {
            if (!candidates.Any()) return;

            var item = candidates.Pop();
            var value = board[item.Row][item.Col];
            var adjacents = new Position[]
            {
                new(item.Row-1, item.Col),
                new(item.Row+1, item.Col),
                new(item.Row, item.Col-1),
                new(item.Row, item.Col+1),
            };
            foreach (var adjacent in adjacents)
            {
                if (IsLower2(board, value, adjacent.Row, adjacent.Col)) 
                {
                    if (!basin.Contains(adjacent))
                    {
                        basin.Add(adjacent);
                        candidates.Push(adjacent);
                    }
                }
            }
            
            AddToBasin(board, basin, candidates);
        }

        private bool IsLowPoint(List<List<int>> board, int row, int col)
        {
            var value = board[row][col];
            return
                IsLower(board, value, row - 1, col)
                &&
                IsLower(board, value, row + 1, col)
                &&
                IsLower(board, value, row, col - 1)
                &&
                IsLower(board, value, row, col + 1);
        }

        private bool IsLower(List<List<int>> board, int value, int row, int col)
        {
            if (row < 0) return true;
            if (col < 0) return true;
            if (row >= board.Count) return true;
            if (col >= board[row].Count) return true;

            return value < board[row][col];
        }

        private bool IsLower2(List<List<int>> board, int value, int row, int col)
        {
            if (row < 0) return false;
            if (col < 0) return false;
            if (row >= board.Count) return false;
            if (col >= board[row].Count) return false;

            if (board[row][col] == 9) return false;

            return value < board[row][col];
        }
    }
}