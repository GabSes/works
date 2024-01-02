using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TicTacToe.Interfaces;
using TicTacToe.Models;

namespace TicTacToe.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

        [HttpPost]
        public IActionResult GetBoard(int size)
        {
            AbstractGameBoard gameBoard;
            if (size == 9)
            {
                gameBoard = new MegaBoard(new HtmlRenderer());
            }
			else if (size == 4)
			{
                gameBoard = new NormalBoardFour(new HtmlRenderer());
            }
            else
            {
                gameBoard = new NormalBoardThree(new HtmlRenderer());
            }
            return Content(gameBoard.Display());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}