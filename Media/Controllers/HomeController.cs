using Microsoft.AspNetCore.Mvc;
using Series.Models;
using Series.Services;
using System.Diagnostics;

namespace Series.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly ISeriesServices seriesServices;
		public HomeController(ILogger<HomeController> logger, ISeriesServices seriesServices)
        {
            _logger = logger;
            this.seriesServices = seriesServices;

        }

        public IActionResult Index()
        {
            IEnumerable<SerieViewModel> seriePortada = seriesServices.ObtenerSeriesPortada(); 
            return View(seriePortada);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}