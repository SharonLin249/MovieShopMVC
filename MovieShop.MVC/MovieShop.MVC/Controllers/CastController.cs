using MovieShop.Entities;
using MovieShop.Sevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieShop.MVC.Controllers
{
    public class CastController : Controller
    {
        private readonly ICastService _castService;

        public CastController()
        {
            _castService = new CastService();
        }
        // GET: Cast
        public ActionResult Index()
        {
            return View();
        }

        //cast/creaTE HTTP GET
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cast cast) //(object in parameter), must pass with cshtml "name". ex: castname != name
        {
            _castService.AddCast(cast);
            return View();
        }

        //step 1: create a action method that returns empty view to enter cast info
    }
}