using MasterDetails;
using MasterDetails.Models;
using MasterDetails.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
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
            var clients = db.Clients.Include(c => c.BookingEntries.Select(b => b.Spot)).OrderByDescending(x => x.ClientId).ToList();
            return View(clients);
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
        [HttpPost]
        public ActionResult Create(ClientVM clientVM, int[] spotId)
        {
            if (ModelState.IsValid)
            {
                Client client = new Client()
                {
                    ClientName = clientVM.ClientName,
                    BirthDate = clientVM.BirthDate,
                    Age = clientVM.Age,
                    MaritalStatus = clientVM.MaritalStatus,
                };

                HttpPostedFileBase file = clientVM.PictureFile;
                if (file != null)
                {
                    string filePath = Path.Combine("/Images/", Guid.NewGuid().ToString() + Path.GetExtension(file.FileName));
                    file.SaveAs(Server.MapPath(filePath));
                    client.Picture = filePath;
                }

                foreach (var item in spotId)
                {
                    BookingEntry bookingEntry = new BookingEntry()
                    {
                        Client = client,
                        CliendId = client.ClientId,
                        SpotId = item
                    };
                    db.BookingEntries.Add(bookingEntry);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


    }
}