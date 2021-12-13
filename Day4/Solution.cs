namespace aoc_2021.Day4
{
    internal class Solution
    {
        public int Solve()
        {
            var lines = File.ReadAllLines("Day4/input");

            var draws = lines[0].Split(',').Select(x => int.Parse(x)).ToList();

            var boards = new List<List<List<int>>>();
            var board = new List<List<int>>();
            foreach (var line in lines.Skip(2))
            {
                if (line == "")
                {
                    boards.Add(board);
                    board = new List<List<int>>();
                    continue;
                }

                AddRow(board, line);
            }

            return Solve(draws, boards);
        }

        private int Solve(List<int> draws, List<List<List<int>>> boards)
        {
            var total = boards.Count;
            var won = new HashSet<int>();
            foreach (var draw in draws)
            {
                for (var index = 0; index < boards.Count; index++)
                {
                    var board = boards[index];
                    Mark(board, draw);
                    if (IsWinner(board))
                    {
                        won.Add(index);
                        if (won.Count == total)
                        {
                            return Result(board, draw);
                        }
                    }
                }
            }

            return -1;
        }

        private bool IsWinner(List<List<int>> board)
        {
            for (int row = 0; row < board.Count; row++)
            {
                if (IsRowMarked(board, row)) return true;
            }

            for (int col = 0; col < board[0].Count; col++)
            {
                if (IsColMarked(board, col)) return true;
            }

            return false;
        }

        private bool IsRowMarked(List<List<int>> board, int row)
        {
            return board[row].All(x => x == -1);
        }

        private bool IsColMarked(List<List<int>> board, int col)
        {
            return board.All(x => x[col] == -1);
        }

        private void Mark(List<List<int>> board, int draw)
        {
            for (int row = 0; row < board.Count; row++)
            {
                for (int col = 0; col < board[row].Count; col++)
                {
                    if (board[row][col] == draw)
                    {
                        board[row][col] = -1;
                    }
                }
            }
        }

        private int Result(List<List<int>> board, int draw)
        {
            var sum = 0;
            for (int row = 0; row < board.Count; row++)
            {
                for (int col = 0; col < board[row].Count; col++)
                {
                    if (board[row][col] != -1)
                    {
                        sum += board[row][col];
                    }
                }
            }
            return sum * draw;
        }

        private void AddRow(List<List<int>> board, string line)
        {
            var row = line.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => int.Parse(x)).ToList();
            board.Add(row);
        }
    }
}