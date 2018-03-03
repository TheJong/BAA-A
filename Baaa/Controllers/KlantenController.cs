using Baaa.Data;
using Baaa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Baaa.Controllers
{
    public class KlantenController : Controller
    {
        // GET: Klanten
        [Authorize(Roles = "Admin")]
        public ActionResult Index(string searchBy, string search, string sortOrder)
        {
            KlantenRepository kr = new KlantenRepository();
            //Viewbags for the filter in Klanten Overzicht
            ViewBag.AchterSort = sortOrder == "achter" ? "achter_desc" : "achter";
            ViewBag.AdresSort = sortOrder == "adres" ? "adres_desc" : "adres";
            ViewBag.PostcodeSort = sortOrder == "postcode" ? "postcode_desc" : "postcode";
            ViewBag.PlaatsNaamSort = sortOrder == "plaatsnaam" ? "plaatsnaam_desc" : "plaatsnaam";
            ViewBag.ProvincieSort = sortOrder == "provincie" ? "provincie_desc" : "provincie";
            ViewBag.OpslagSort = sortOrder == "opslag" ? "opslag_desc" : "opslag";

            var klanten = from s in kr.GetAllKlanten()
                          select s;

            //Return Querys for Klanten overzicht Filter with ORDER BY DESC/ASC
            switch (sortOrder)
            {
                case "achter":
                    return View(kr.GetAllKlanten());
                case "achter_desc":
                    return View(kr.GetAllKlantenDesc());
                case "adres":
                    return View(kr.GetAllKlantenAdres());
                case "adres_desc":
                    return View(kr.GetAllKlantenAdresDesc());
                case "postcode":
                    return View(kr.GetAllKlantenPostcode());
                case "postcode_desc":
                    return View(kr.GetAllKlantenPostcodeDesc());
                case "provincie":
                    return View(kr.GetAllKlantenProvincie());
                case "provincie_desc":
                    return View(kr.GetAllKlantenProvincieDesc());
                case "opslag":
                    return View(kr.GetAllKlantenOpslag());
                case "opslag_desc":
                    return View(kr.GetAllKlantenOpslagDesc());
                case "plaatsnaam":
                    return View(kr.GetAllKlantenPlaatsNaam());
                case "plaatsnaam_desc":
                    return View(kr.GetAllKlantenPlaatsNaamDesc());
                default:
                    break;
            }
            //Search by Names for klanten overzicht searchbar
            if (searchBy == "Achternaam")
            {
                return View(kr.GetAllKlanten().Where(x => x.AchterNaam == search || search == null));
            }
            else if (searchBy == "Adres")
            {
                return View(kr.GetAllKlanten().Where(x => x.Adres == search || search == null));
            }
            else if (searchBy == "Postcode")
            {
                return View(kr.GetAllKlanten().Where(x => x.Postcode == search || search == null));
            }
            else if (searchBy == "PlaatsNaam")
            {
                return View(kr.GetAllKlanten().Where(x => x.PlaatsNaam == search || search == null));
            }
            else if (searchBy == "Provincie")
            {
                return View(kr.GetAllKlanten().Where(x => x.ProvincieName == search || search == null));
            }
            else if (searchBy == "Opslag")
            {
                return View(kr.GetAllKlanten().Where(x => x.Opslag == search || search == null));
            }
            else
            {
                return View(kr.GetAllKlanten());
            }
        }

        // GET: Create
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Create()

        {
            Klanten klant = new Klanten();
            KlantenRepository kr = new KlantenRepository();
            //Viewbags for the dropdownlists
            ViewBag.ProvincieList = new SelectList(kr.GetProvincieList(), "Id", "ProvincieName");
            ViewBag.ObserveerList = new SelectList(kr.GetObserveerList(), "Id", "ObserverenName");
            ViewBag.WeghaalList = new SelectList(kr.GetWeghaalList(), "Id", "WeghaalName");

            return View(klant);
        }

        // POST: Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(Klanten klant)
        {
            try
            {
                KlantenRepository kr = new KlantenRepository();
                bool isCreated = kr.CreateKlant(klant);
                if (isCreated)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(klant);
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
            KlantenRepository kr = new KlantenRepository();
            ViewBag.ProvincieList = new SelectList(kr.GetProvincieList(), "Id", "ProvincieName");
            ViewBag.ObserveerList = new SelectList(kr.GetObserveerList(), "Id", "ObserverenName");
            ViewBag.WeghaalList = new SelectList(kr.GetWeghaalList(), "Id", "WeghaalName");

            return View(kr.GetKlantByIdEdit(id));
        }

        // POST: Edit
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Klanten klant)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    KlantenRepository kr = new KlantenRepository();
                    kr.UpdateKlanten(klant);
                    return RedirectToAction("Index");
                }

                return View(klant);
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
            KlantenRepository kr = new KlantenRepository();
            ViewBag.ProvincieShow = new SelectList(kr.GetProvincieList(), "Id", "ProvincieName");
            return View(kr.GetKlantById(id));
        }

        // POST: Delete
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                KlantenRepository kr = new KlantenRepository();
                kr.DeleteKlantById(id);
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
                KlantenRepository kr = new KlantenRepository();
                return View(kr.GetKlantById(id));
            }
        }
    }
}