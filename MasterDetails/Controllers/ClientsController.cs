using MasterDetails;
using MasterDetails.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasterDetails.Controllers
{
    public class ClientsController : Controller
    {
        private TravelDbContext db = new TravelDbContext();
        // GET: Clients
        public ActionResult Index()
        {
            return View(db.Clients.ToList());
        }


        public ActionResult AddNewSpot(int? id)
        {
            ViewBag.spots= new SelectList(db.Spots.ToList(),"SpotId","SpotName",(id!=null)?id.ToString():"");
            return PartialView("_addNewSpot");
        }

        public ActionResult Create()
        {
            return View();
        }


    }
}