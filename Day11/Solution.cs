namespace aoc_2021.Day11
{
    internal class Solution
    {
        public long Solve()
        {
            var lines = File.ReadAllLines("Day11/input");
            var board = lines.Select(l => l.ToCharArray().Select(x => x - '0').ToList()).ToList();
            var score = 0;
            for (var step = 0; step < 100000; step++)
            {
                for (var row = 0; row < board.Count; row++)
                {
                    for (var col = 0; col < board[row].Count; col++)
                    {
                        board[row][col]++;
                    }
                }

                score = Flash(board, score);
                if (AllFlash(board))
                    return step+1;
            }

            return -1;
            //return score;
        }

        private bool AllFlash(List<List<int>> board)
        {
            for (var row = 0; row < board.Count; row++)
            {
                for (var col = 0; col < board[row].Count; col++)
                {
                    if (board[row][col] != 0)
                        return false;
                }
            }
            return true;
        }

        private int Flash(List<List<int>> board, int score)
        {
            var initial = score;
            for (var row = 0; row < board.Count; row++)
            {
                for (var col = 0; col < board[row].Count; col++)
                {
                    if (board[row][col] > 9)
                    {
                        score++;
                        board[row][col] = 0;
                        AddEnergy(board, row - 1, col - 1);
                        AddEnergy(board, row - 1, col);
                        AddEnergy(board, row - 1, col + 1);
                        AddEnergy(board, row, col - 1);
                        AddEnergy(board, row, col + 1);
                        AddEnergy(board, row + 1, col - 1);
                        AddEnergy(board, row + 1, col);
                        AddEnergy(board, row + 1, col + 1);
                    }
                }
            }

            if (score > initial)
            {
                return Flash(board, score);
            }
            return score;
        }

        private void AddEnergy(List<List<int>> board, int row, int col)
        {
            if (row < 0) return;
            if (col < 0) return;
            if (row >= board.Count) return;
            if (col >= board[row].Count) return;
            var value = board[row][col];
            if (value == 0) return;
            if (value > 9) return;
            board[row][col]++;
        }
    }
}