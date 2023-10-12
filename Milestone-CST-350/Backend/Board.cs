namespace Milestone_CST_350.Backend
{
    public class Board
    {
       
            public int Size { get; set; }
            public Cell[,] Grid { get; set; }
            public int Difficulty { get; set; }
            public bool GameOver { get; set; }
            public int Click { get; set; }



            public Board(int size = 11, int difficulty = 5)
            {
                // initialize 
                Size = size;
                Difficulty = difficulty;

                // create a new 2D array of type cell
                Grid = new Cell[Size, Size];

                for (int i = 0; i < Size; i++)
                {
                    for (int j = 0; j < Size; j++)
                    {
                        Grid[i, j] = new Cell(i, j);
                    }
                }
            }




            public int CountOpenCells()
            {
                int freeCells = 0;

                for (int i = 0; i < Size; i++)
                {
                    for (int j = 0; j < Size; j++)
                    {
                        if (Grid[i, j].Live == false)
                        {
                            freeCells++;
                        }
                    }
                }

                return freeCells;
            }

            // Need to change to only count un-visited cells.
            public int UpdateClickCounter(int row, int col)
            {
                if (!Grid[row, col].Visited)
                    Click++;

                return Click;
            }

            public int CountVisited()
            {
                int visited = 0;

                for (int i = 0; i < Size; i++)
                {
                    for (int j = 0; j < Size; j++)
                    {
                        if (Grid[i, j].Visited)
                        {
                            visited++;
                        }
                    }
                }
                return visited;
            }

            public void ResetCells()
            {
                for (int i = 0; i < Size; i++)
                {
                    for (int j = 0; j < Size; j++)
                    {
                        Grid[i, j].Visited = false;
                        Grid[i, j].Live = false;
                        Grid[i, j].LiveNeighbors = 0;

                    }
                }
            }

            public void SetupLiveNeighbors()
            {
                int occupiedSpots = 0;

                double percent = Difficulty * .01;

                // calculate bombs to place base on percentage of board size
                int liveSpots = Convert.ToInt32(Size * Size * percent);
                Random random = new();

                // place bombs until all spots available are filled 

                while (occupiedSpots < liveSpots)
                {
                    int ranRow = random.Next(Size - 1);
                    int ranCol = random.Next(Size - 1);

                    if (Grid[ranRow, ranCol].Live == false)
                    {
                        // mark the current cells as live 
                        Grid[ranRow, ranCol].Live = true;
                        occupiedSpots++;
                    }
                }
            }

            public void CalculateLiveNeighbors()
            {
                for (int i = 0; i < Size; i++)
                {
                    for (int j = 0; j < Size; j++)
                    {
                        Cell currentCell = Grid[i, j];

                        // check cells adjcent for bombs if a cell is not live 

                        if (!currentCell.Live)
                        {

                            // cell 0,0
                            if (i == 0 && j == 0)
                            {
                                if (Grid[i, 1].Live)
                                    Grid[i, j].LiveNeighbors++;
                                if (Grid[1, 1].Live)
                                    Grid[i, j].LiveNeighbors++;
                                if (Grid[1, j].Live)
                                    Grid[i, j].LiveNeighbors++;
                            }

                            // cell 0, size - 1
                            if (i == 0 && j == Size - 1)
                            {
                                if (Grid[0, Size - 2].Live)
                                    Grid[i, j].LiveNeighbors++;
                                if (Grid[1, Size - 2].Live)
                                    Grid[i, j].LiveNeighbors++;
                                if (Grid[1, Size - 1].Live)
                                    Grid[i, j].LiveNeighbors++;
                            }

                            // cell Size - 1, ]
                            if (i == Size - 1 && j == 0)
                            {
                                if (Grid[Size - 2, 0].Live)
                                    Grid[i, j].LiveNeighbors++;
                                if (Grid[Size - 2, 1].Live)
                                    Grid[i, j].LiveNeighbors++;
                                if (Grid[Size - 1, 1].Live)
                                    Grid[i, j].LiveNeighbors++;
                            }

                            // cell Size - 1, -1
                            if (i == Size - 1 && j == Size - 1)
                            {
                                if (Grid[Size - 2, Size - 2].Live)
                                    Grid[i, j].LiveNeighbors++;
                                if (Grid[Size - 2, Size - 1].Live)
                                    Grid[i, j].LiveNeighbors++;
                                if (Grid[Size - 1, Size - 2].Live)
                                    Grid[i, j].LiveNeighbors++;
                            }

                            // center cells
                            if (i > 0 && i < Size - 1 && j > 0 && j < Size - 1)
                            {
                                // row above 
                                if (Grid[i + 1, j - 1].Live)
                                    Grid[i, j].LiveNeighbors++;
                                if (Grid[i + 1, j].Live)
                                    Grid[i, j].LiveNeighbors++;
                                if (Grid[i + 1, j + 1].Live)
                                    Grid[i, j].LiveNeighbors++;

                                // current row 
                                if (Grid[i, j - 1].Live)
                                    Grid[i, j].LiveNeighbors++;
                                if (Grid[i, j + 1].Live)
                                    Grid[i, j].LiveNeighbors++;

                                // row below
                                if (Grid[i - 1, j - 1].Live)
                                    Grid[i, j].LiveNeighbors++;
                                if (Grid[i - 1, j].Live)
                                    Grid[i, j].LiveNeighbors++;
                                if (Grid[i - 1, j + 1].Live)
                                    Grid[i, j].LiveNeighbors++;
                            }

                            // top row  > col 0 and < col size -1
                            if (i == 0 && j > 00 && j < Size - 1)
                            {
                                if (Grid[i, j - 1].Live)
                                    Grid[i, j].LiveNeighbors++;
                                if (Grid[i, j + 1].Live)
                                    Grid[i, j].LiveNeighbors++;
                                if (Grid[i + 1, j].Live)
                                    Grid[i, j].LiveNeighbors++;
                                if (Grid[i + 1, j - 1].Live)
                                    Grid[i, j].LiveNeighbors++;
                                if (Grid[i + 1, j + 1].Live)
                                    Grid[i, j].LiveNeighbors++;
                            }

                            // bottom row 
                            if (i == Size - 1 && j > 0 && j < Size - 1)
                            {
                                if (Grid[i, j - 1].Live)
                                    Grid[i, j].LiveNeighbors++;
                                if (Grid[i, j + 1].Live)
                                    Grid[i, j].LiveNeighbors++;
                                if (Grid[i - 1, j].Live)
                                    Grid[i, j].LiveNeighbors++;
                                if (Grid[i - 1, j - 1].Live)
                                    Grid[i, j].LiveNeighbors++;
                                if (Grid[i - 1, j + 1].Live)
                                    Grid[i, j].LiveNeighbors++;
                            }

                            // first col
                            if (j == 0 && i > 0 && i < Size - 1)
                            {
                                if (Grid[i - 1, j].Live)
                                    Grid[i, j].LiveNeighbors++;
                                if (Grid[i + 1, j].Live)
                                    Grid[i, j].LiveNeighbors++;
                                if (Grid[i, j + 1].Live)
                                    Grid[i, j].LiveNeighbors++;
                                if (Grid[i - 1, j + 1].Live)
                                    Grid[i, j].LiveNeighbors++;
                                if (Grid[i + 1, j + 1].Live)
                                    Grid[i, j].LiveNeighbors++;
                            }

                            // last col 
                            if (j == Size - 1 && i > 0 && i < Size - 1)
                            {
                                if (Grid[i - 1, j].Live)
                                    Grid[i, j].LiveNeighbors++;
                                if (Grid[i + 1, j].Live)
                                    Grid[i, j].LiveNeighbors++;
                                if (Grid[i, j - 1].Live)
                                    Grid[i, j].LiveNeighbors++;
                                if (Grid[i - 1, j - 1].Live)
                                    Grid[i, j].LiveNeighbors++;
                                if (Grid[i + 1, j - 1].Live)
                                    Grid[i, j].LiveNeighbors++;
                            }
                        }
                    }
                }
            }

            // this is checking to see if flood fill is able to use this cell spot
            private bool IsValid(int r, int c)
            {
                return (r < Size && r >= 0 && c < Size && c >= 0 && Grid[r, c].Visited == false);
            }

            public bool IsLive(int row, int col)
            {
                if (IsValid(row, col) && Grid[row, col].Live)
                    return true;
                else
                    return false;
            }

            public void FloodFill(int row, int col)
            {
                if (IsValid(row, col) && !Grid[row, col].Live)
                {
                    if (Grid[row, col].LiveNeighbors == 0)
                    {
                        Grid[row, col].Visited = true;

                        // north 
                        FloodFill(row + 1, col);

                        // south 
                        FloodFill(row - 1, col);

                        // east 
                        FloodFill(row, col + 1);

                        // west 
                        FloodFill(row, col - 1);

                        // north east
                        FloodFill(row + 1, col + 1);

                        // south east   
                        FloodFill(row - 1, col + 1);

                        // north east
                        FloodFill(row + 1, col - 1);

                        // south east 
                        FloodFill(row - 1, col - 1);
                    }

                    else
                    {
                        Grid[row, col].Visited = true;
                    }
                }
            }


            // this is a method that will show the board when called 
            public void ShowBoard(string result)
            {
                for (int i = 0; i < Size; i++)
                {
                    for (int j = 0; j < Size; j++)
                    {
                        Cell currentCell = Grid[i, j];

                        // mark all cells as visited 
                        if (result == "lose")
                        {
                            currentCell.Visited = true;
                        }
                        else if (result == "win")
                        {
                            if (!currentCell.Live)
                            {
                                currentCell.Visited = true;
                            }
                        }
                    }
                }
            }

            // this 
            public string GameUpdate(int row, int col)
            {
                string result = "";
                int openCells = CountOpenCells();
                int visitedCells = CountVisited();

                if (!Grid[row, col].Live && openCells == visitedCells)
                    result = "win";
                else if (Grid[row, col].Live)
                    result = "lose";


                return result;
            }

        }
    }

