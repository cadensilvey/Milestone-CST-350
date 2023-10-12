using Microsoft.AspNetCore.Mvc;
using Milestone_CST_350.Models;

namespace Milestone_CST_350.Controllers
{
    public class MinesweeperController : Controller
    {
        private MinesweeperGame minesweeper;

        public MinesweeperController()
        {
            // initialize the minesweeper game
            minesweeper = new MinesweeperGame(10, 10, 20);
        }
        public IActionResult Index()
        {
            return View(minesweeper);
        }

        [HttpPost]
        [Route("RevealCell")]
        public IActionResult RevealCell(int row, int col)
        {
            minesweeper.RevealCell(row, col);
            return PartialView("_GameBoardPartial", minesweeper);
        }
        [HttpPost]
        [Route("ToggleFlag")]
        public IActionResult ToggleFlag(int row, int col)
        {
            minesweeper.ToggleFlag(row, col);
            return PartialView("_GameBoardPartial",minesweeper);

        }


    }
}
