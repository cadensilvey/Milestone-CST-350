namespace Milestone_CST_350.Models
{
    public class MinesweeperGame
    {
        private int[,] board; // 2D array to represent the game board
        private bool[,] revealed; // 2D array to track revealed cells
        private bool[,] flagged; // 2D array to track flagged cells
        private int numRows;
        private int numCols;
        private int numMines;

        // Constructor to initialize the game
        public MinesweeperGame(int numRows, int numCols, int numMines)
        {
            this.numRows = numRows;
            this.numCols = numCols;
            this.numMines = numMines;

            // Initialize the game board and arrays
            board = new int[numRows, numCols];
            revealed = new bool[numRows, numCols];
            flagged = new bool[numRows, numCols];

            // Initialize the board, place mines, and calculate neighboring mine counts
            InitializeBoard();
            PlaceMines(numMines);
            CalculateNeighborMineCounts();

            // Set all cells to unrevealed and not flagged
            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    revealed[row, col] = false;
                    flagged[row, col] = false;
                }
            }
        }

        public int NumRows => numRows;
        public int NumCols => numCols;

        public bool CheckWinCondition()
        {
            for(int row =0; row < numRows; row++)
            {
                for(int col =0; col < numCols; col++)
                {
                    // if any non-mine cell is not revealed, the game is NOT won
                    if (board[row, col] != -1 && !revealed[row, col])
                    {
                        return false;
                    }
                }
            }

            // if all non-mine cells are revealed, the game is won
            return true;
        }

        public bool RevealCell(int row, int col)
        {
            if (row < 0 || row >= numRows || col < 0 || col >= numCols)
            {
                // Invalid cell coordinates; return false to indicate no game over.
                return false;
            }

            if (revealed[row, col] || flagged[row, col])
            {
                // Cell is already revealed or flagged; return false to indicate no game over.
                return false;
            }

            revealed[row, col] = true;

            if (board[row, col] == -1)
            {
                // The revealed cell contains a mine; this is a game over.
                // You can handle game over logic here.
                return true;
            }

            if (board[row, col] == 0)
            {
                // If the revealed cell is empty (no mines nearby), reveal adjacent cells.
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        RevealCell(row + i, col + j);
                    }
                }
            }

            // Check for a win condition (e.g., all non-mine cells are revealed).
            bool isGameWon = CheckWinCondition();

            // Return whether the game is won; true if won, false if not.
            return isGameWon;
        }

        public void ToggleFlag(int row, int col)
        {
            if (row < 0 || row >= numRows || col < 0 || col >= numCols)
            {
                // Invalid cell coordinates; ignore the action.
                return;
            }

            if (!revealed[row, col])
            {
                // Toggle the flag status of the cell.
                flagged[row, col] = !flagged[row, col];
            }
        }

        private void InitializeBoard()
        {
            // Initialize the game board with all cells set to 0 (no mines).
            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    board[row, col] = 0;
                }
            }
        }

        private void PlaceMines(int numMines)
        {
            // Randomly place mines on the game board.
            Random random = new Random();
            int minesPlaced = 0;

            while (minesPlaced < numMines)
            {
                int row = random.Next(numRows);
                int col = random.Next(numCols);

                if (board[row, col] != -1) // -1 indicates a mine
                {
                    board[row, col] = -1;
                    minesPlaced++;
                }
            }
        }

        private void CalculateNeighborMineCounts()
        {
            // Calculate the number of neighboring mines for each cell.
            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    if (board[row, col] != -1) // Skip cells with mines
                    {
                        int count = 0;

                        // Check adjacent cells for mines
                        for (int i = -1; i <= 1; i++)
                        {
                            for (int j = -1; j <= 1; j++)
                            {
                                int neighborRow = row + i;
                                int neighborCol = col + j;

                                if (neighborRow >= 0 && neighborRow < numRows &&
                                    neighborCol >= 0 && neighborCol < numCols &&
                                    board[neighborRow, neighborCol] == -1)
                                {
                                    count++;
                                }
                            }
                        }

                        board[row, col] = count;
                    }
                }
            }
        }

        public string GetCellDisplay(int row, int col)
        {
            if (revealed[row, col])
            {
                if (board[row, col] == -1)
                {
                    // This cell contains a mine
                    return "💣"; // You can use an emoji, image, or any suitable representation
                }
                else if (board[row, col] == 0)
                {
                    // This cell is empty (no mines nearby)
                    return ""; // Empty cell
                }
                else
                {
                    // This cell has adjacent mines
                    return board[row, col].ToString();
                }
            }
            else if (flagged[row, col])
            {
                // This cell is flagged
                return "🚩"; // Flag emoji or other representation
            }
            else
            {
                // This cell is unrevealed
                return " "; // You might show an empty cell or a question mark (?)
            }
        }

    }

}
