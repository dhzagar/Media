using Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Series.Models;
using Series.Services;
using System.Web;

namespace Series.Controllers
{
	[Authorize]
	public class AdminController : Controller
	{
        private readonly ISeriesServices seriesServices;
        private readonly IActoresServices actoresServices;
        private readonly IWebHostEnvironment environment;

        public AdminController(ISeriesServices seriesServices, IWebHostEnvironment environment, IActoresServices actoresServices)
        {
            this.seriesServices = seriesServices;
            this.environment = environment;
            this.actoresServices = actoresServices;
        }
        [HttpPut]
        public IActionResult EditShow(int id)
        {

            SerieViewModel serie = seriesServices.ObtenerSerie(id);
            if (serie != null)
            {
                ViewBag.mode = "EDIT";
                return View("SerieForm", serie);
            }
            else
            {
                return View("NotFound", "Home");
            }
        }
        [HttpPut]
        public IActionResult EditarActor(int id)
        {
            ActorViewModel actor = actoresServices.ObtenerActor(id);
            if (actor != null)
            {
                ViewBag.mode = "EDIT";
                return View("ActorForm", actor);
            }
            return View("AddCast");

        }
        [HttpPut]
        public IActionResult EditCast(int id)
        {
            ActorViewModel actor = new()
            {
                SerieId = id
            };
            if (actor != null)
            {
                return View("ActorForm", actor);
            }
            return View("AddCast");
            
        }
        [HttpDelete]
        public IActionResult DeleteShow(int id)
        {
            seriesServices.BorrarSerie(id);
            return RedirectToAction("Index", "Home");
        }
        [HttpDelete]
        public IActionResult DeleteActor(int id)
        {
            actoresServices.BorrarActor(id);
            return RedirectToAction("Index", "Actor");
        }
        public IActionResult Add()
        {
            ViewBag.mode = "ADD";
            return View("SerieForm");
        }
        public IActionResult AddCast()
        {
            ViewBag.mode = "ADD";
            return View("ActorForm");
        }
        [HttpPost]
        public IActionResult Save(SerieViewModel serie)
        {
            if (Request.Form.Files.Count == 1)
            {
                IFormFile file = Request.Form.Files[0];

                String fileName = environment.WebRootPath + "/images/" + file.FileName;
                String pureFileName = file.FileName;

                int numero = 1;

                while (System.IO.File.Exists(fileName))
                {
                    fileName = environment.WebRootPath + "/images/" + numero + file.FileName ;
                    pureFileName = numero +file.FileName ;
                    numero++;
                }

                Stream createFileStream = System.IO.File.Create(fileName);
                file.CopyTo(createFileStream);
                createFileStream.Close();

                serie.ImagenURL = pureFileName;
            }

            if (serie.Id == 0)
            {
                seriesServices.AgregarSerie(serie);
            }
            else
            {
                seriesServices.ActualizarSerie(serie);
            }

            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult SaveActores(ActorViewModel actor)
        {
            if (actor.ActorId == 0)
            {
                actoresServices.AgregarActor(actor);
            }
            else
            {
                actoresServices.ActualizarActor(actor);
            }
            return View("ActorForm");
        }
    }
}
