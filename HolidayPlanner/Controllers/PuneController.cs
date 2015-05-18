using HolidayPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HolidayPlanner.Controllers
{
    public class PuneController : Controller
    {
        // GET: Pune
        public ActionResult Pune1()
        {
            return View();
        }

        public ActionResult LuxuryPune()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> abc = (from hot in db.Hotels
                               where hot.HTypeId == "LU" && hot.CityId == "PU"
                               select hot).ToList();
            return View(abc);
        }

        public ActionResult BeachFacingPune()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> bfac = (from hot in db.Hotels
                                where hot.HTypeId == "BF" && hot.CityId == "PU"
                                select hot).ToList();
            return View(bfac);
        }

        public ActionResult RomanticPune()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> rom = (from hot in db.Hotels
                               where hot.HTypeId == "RM" && hot.CityId == "PU"
                               select hot).ToList();
            return View(rom);
        }

        public ActionResult ValleyViewPune()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> valy = (from hot in db.Hotels
                                where hot.HTypeId == "VV" && hot.CityId == "PU"
                                select hot).ToList();
            return View(valy);
        }

        public ActionResult AdventurePune()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> adv = (from hot in db.Hotels
                               where hot.HTypeId == "AV" && hot.CityId == "PU"
                               select hot).ToList();
            return View(adv);
        }

        public ActionResult RiverSidePune()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> rside = (from hot in db.Hotels
                                 where hot.HTypeId == "RS" && hot.CityId == "PU"
                                 select hot).ToList();
            return View(rside);
        }

        public ActionResult PureVegPune()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> pveg = (from hot in db.Hotels
                                where hot.HTypeId == "PV" && hot.CityId == "PU"
                                select hot).ToList();
            return View(pveg);
        }

        public ActionResult PetFriendlyPune()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> pet = (from hot in db.Hotels
                               where hot.HTypeId == "PF" && hot.CityId == "PU"
                               select hot).ToList();
            return View(pet);
        }

        public ActionResult BeachesPune()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> beach = (from hot in db.Hotels
                                 where hot.HTypeId == "BC" && hot.CityId == "PU"
                                 select hot).ToList();
            return View(beach);
        }

        public ActionResult HillStationsPune()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> hill = (from hot in db.Hotels
                                where hot.HTypeId == "HS" && hot.CityId == "PU"
                                select hot).ToList();
            return View(hill);
        }

        public ActionResult FarmsPune()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> far = (from hot in db.Hotels
                               where hot.HTypeId == "FA" && hot.CityId == "PU"
                               select hot).ToList();
            return View(far);
        }

        public ActionResult HolyPlacesPune()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> holy = (from hot in db.Hotels
                                where hot.HTypeId == "HP" && hot.CityId == "PU"
                                select hot).ToList();
            return View(holy);
        }
    }
}