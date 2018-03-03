using Baaa.Data;
using Baaa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Baaa.Controllers
{
    public class PortierController : Controller
    {
        // GET: Portier
        [Authorize(Roles = "Admin")]
        public ActionResult Index(string searchBy, string search, string sortOrder)
        {
            PortierRepository pr = new PortierRepository();
            //Viewbags for the filter in Portier Overzicht
            ViewBag.AchterSort = sortOrder == "achter" ? "achter_desc" : "achter";
            ViewBag.AdresSort = sortOrder == "adres" ? "adres_desc" : "adres";
            ViewBag.PostcodeSort = sortOrder == "postcode" ? "postcode_desc" : "postcode";
            ViewBag.ProvincieSort = sortOrder == "provincie" ? "provincie_desc" : "provincie";
            ViewBag.PlaatsNaamSort = sortOrder == "plaatsnaam" ? "plaatsnaam_desc" : "plaatsnaam";

            var portier = from s in pr.GetAllPortier()
                          select s;

            //Return Querys for Klanten overzicht Filter with ORDER BY DESC/ASC
            switch (sortOrder)
            {
                case "achter":
                    return View(pr.GetAllPortier());
                case "achter_desc":
                    return View(pr.GetAllPortierDesc());
                case "adres":
                    return View(pr.GetAllPortierAdres());
                case "adres_desc":
                    return View(pr.GetAllPortierAdresDesc());
                case "postcode":
                    return View(pr.GetAllPortierPostcode());
                case "postcode_desc":
                    return View(pr.GetAllPortierPostcodeDesc());
                case "provincie":
                    return View(pr.GetAllPortierProvincie());
                case "provincie_desc":
                    return View(pr.GetAllPortierProvincieDesc());
                case "plaatsnaam":
                    return View(pr.GetAllPortierPlaatsNaam());
                case "plaatsnaam_desc":
                    return View(pr.GetAllPortierPlaatsNaamDesc());
                default:
                    break;
            }
            //Search by Names for klanten overzicht searchbar
            if (searchBy == "PortierAchternaam")
            {
                return View(pr.GetAllPortier().Where(x => x.PortierAchternaam == search || search == null));
            }
            else if (searchBy == "Adres")
            {
                return View(pr.GetAllPortier().Where(x => x.Adres == search || search == null));
            }
            else if (searchBy == "Postcode")
            {
                return View(pr.GetAllPortier().Where(x => x.Postcode == search || search == null));
            }
            else if (searchBy == "Provincie")
            {
                return View(pr.GetAllPortier().Where(x => x.ProvincieName == search || search == null));
            }
            else if (searchBy == "Plaats")
            {
                return View(pr.GetAllPortier().Where(x => x.PlaatsNaam == search || search == null));
            }
            else
            {
                return View(pr.GetAllPortier());
            }
        }

        // GET: Create
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Create()

        {
            Portier portier = new Portier();
            PortierRepository pr = new PortierRepository();
            //Viewbags for the dropdownlists
            ViewBag.ProvincieList = new SelectList(pr.GetProvincieList(), "Id", "ProvincieName");

            return View(portier);
        }

        // POST: Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(Portier portier)
        {
            try
            {
                PortierRepository pr = new PortierRepository();
                bool isCreated = pr.CreatePortier(portier);
                if (isCreated)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(portier);
                }

            }
            catch
            {
                return View("Create");
            }

        }

        // GET: Edit
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            PortierRepository pr = new PortierRepository();
            ViewBag.ProvincieList = new SelectList(pr.GetProvincieList(), "Id", "ProvincieName");

            return View(pr.GetPortierByIdEdit(id));
        }

        // POST: Edit
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Portier portier)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    PortierRepository pr = new PortierRepository();
                    pr.UpdatePortier(portier);
                    return RedirectToAction("Index");
                }

                return View(portier);
            }
            catch
            {

                return View("Index");
            }

        }

        // GET: Delete
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Delete(int id)

        {
            PortierRepository pr = new PortierRepository();
            ViewBag.ProvincieShow = new SelectList(pr.GetProvincieList(), "Id", "ProvincieName");
            return View(pr.GetPortierById(id));
        }

        // POST: Delete
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                PortierRepository pr = new PortierRepository();
                pr.DeletePortierById(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }

        // GET: Details
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Details(int id)
        {
            {
                PortierRepository pr = new PortierRepository();
                return View(pr.GetPortierById(id));
            }
        }
    }
}