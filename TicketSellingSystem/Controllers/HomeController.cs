﻿using System.Web.Mvc;

namespace TicketSellingSystem.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}