namespace Milestone_CST_350.Models
{
    public class MinesweeperModel
    {
        public int Id { get; set; }
        public int ButtonState { get; set; }
        public bool IsBomb { get; set; }

        public MinesweeperModel(int id, int buttonState)
        {
            Id = id;
            ButtonState = buttonState;
            IsBomb = false;
        }





        // implement in the next milestone

        //public Cell[,] Cells { get; set; }
        //public GameState GameStatus { get; set; }


    }
}
