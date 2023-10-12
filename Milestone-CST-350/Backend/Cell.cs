namespace Milestone_CST_350.Backend
{
    public class Cell
    {
        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }
        public int LiveNeighbors { get; set; }
        public bool Visited { get; set; }
        public bool Live {  get; set; }

        public Cell(int x, int y) 
        {
            RowNumber = x; 
            ColumnNumber = y;
        }
    }
}
