using Microsoft.AspNetCore.Mvc;
using Series.Models;
using Series.Services;
using System;

namespace Series.Controllers
{
    public class SeriesController : Controller
    {
        private readonly ISeriesServices seriesServices;
        
		
		public SeriesController(ISeriesServices seriesServices)
		{
			this.seriesServices = seriesServices;
		}
		public IActionResult Index(int id)
        {
			SerieViewModel serie = seriesServices.ObtenerSerie(id);
			if (serie != null)
			{
				return View(serie);
			}
			else
			{
				return View("NotFound", "Home");
			}
        }
		
	}
}
