using Microsoft.AspNetCore.Mvc;
using Series.Models;
using Series.Services;

namespace Series.Controllers
{
	public class ActorController : Controller
	{
		private readonly IActoresServices actoresServices;

		public ActorController(IActoresServices actoresServices)
		{
			this.actoresServices = actoresServices;
		}

		public IActionResult Index(int id)
		{
			IEnumerable<ActorViewModel> actor = actoresServices.ObtenerActores(id);
			return View(actor);
		}
        
    }
}
