using Microsoft.AspNetCore.Mvc;
using Milestone_CST_350.Models;

namespace Milestone_CST_350.Controllers
{
    public class MinesweeperController : Controller
    {

        // create the grid for the minesweeper board 
        static List<MinesweeperModel> ms = new List<MinesweeperModel>();
        Random random = new Random();
        const int GRID_SIZE = 25;

        public IActionResult Index()
        {
           // empty the list when the page loads
           ms = new List<MinesweeperModel>();

            // Generate some new cells. 
            for(int i = 0; i < GRID_SIZE; i++)
            {
                ms.Add(new MinesweeperModel(i, random.Next(4)));
            }

            // send the grid to the Index page
            return View("Index", ms);
        }


        public IActionResult ToggleFlag(string buttonNumber)
        {
            // Convert from string to int
            int bN = int.Parse(buttonNumber);

            // Set the IsBomb property to true for the clicked cell
            ms.ElementAt(bN).IsBomb = true;

            // Re-display the buttons
            return View("Index", ms);
        }


    }
}
