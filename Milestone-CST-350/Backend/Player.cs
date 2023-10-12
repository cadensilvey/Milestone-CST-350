namespace Milestone_CST_350.Backend
{
    public class Player
    {
        public String id { get; set; }
        public String PlayerName { get; set; }
        public double Score { get; set; }


        // player constructor with 0 params
        public Player()
        {
            PlayerName = "Nothing yet";
            Score = 0;
        }

        public string Display
        {
            get
            {
                return string.Format("{0} {1}", PlayerName, Score);
            }
        }
    }
}
