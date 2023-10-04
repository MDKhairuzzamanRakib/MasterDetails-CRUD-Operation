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
    }
}