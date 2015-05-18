using HolidayPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HolidayPlanner.Controllers
{
    public class BangaloreController : Controller
    {
        // GET: Bangalore

        public ActionResult Bangalore()
        {
            return View();
        }

        public ActionResult LuxuryBangalore()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> abc = (from hot in db.Hotels
                               where hot.HTypeId == "LU" && hot.CityId == "BAN"
                               select hot).ToList();
            return View(abc);
        }

        public ActionResult BeachFacingBangalore()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> bfac = (from hot in db.Hotels
                                where hot.HTypeId == "BF" && hot.CityId == "BAN"
                                select hot).ToList();
            return View(bfac);
        }

        public ActionResult RomanticBangalore()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> rom = (from hot in db.Hotels
                               where hot.HTypeId == "RM" && hot.CityId == "BAN"
                               select hot).ToList();
            return View(rom);
        }

        public ActionResult ValleyViewBangalore()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> valy = (from hot in db.Hotels
                                where hot.HTypeId == "VV" && hot.CityId == "BAN"
                                select hot).ToList();
            return View(valy);
        }

        public ActionResult AdventureBangalore()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> adv = (from hot in db.Hotels
                               where hot.HTypeId == "AV" && hot.CityId == "BAN"
                               select hot).ToList();
            return View(adv);
        }

        public ActionResult RiverSideBangalore()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> rside = (from hot in db.Hotels
                                 where hot.HTypeId == "RS" && hot.CityId == "BAN"
                                 select hot).ToList();
            return View(rside);
        }

        public ActionResult PureVegBangalore()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> pveg = (from hot in db.Hotels
                                where hot.HTypeId == "PV" && hot.CityId == "BAN"
                                select hot).ToList();
            return View(pveg);
        }

        public ActionResult PetFriendlyBangalore()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> pet = (from hot in db.Hotels
                               where hot.HTypeId == "PF" && hot.CityId == "BAN"
                               select hot).ToList();
            return View(pet);
        }

        public ActionResult BeachesBangalore()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> beach = (from hot in db.Hotels
                                 where hot.HTypeId == "BC" && hot.CityId == "BAN"
                                 select hot).ToList();
            return View(beach);
        }

        public ActionResult HillStationsBangalore()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> hill = (from hot in db.Hotels
                                where hot.HTypeId == "HS" && hot.CityId == "BAN"
                                select hot).ToList();
            return View(hill);
        }

        public ActionResult FarmsBangalore()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> far = (from hot in db.Hotels
                               where hot.HTypeId == "FA" && hot.CityId == "BAN"
                               select hot).ToList();
            return View(far);
        }

        public ActionResult HolyPlacesBangalore()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> holy = (from hot in db.Hotels
                                where hot.HTypeId == "HP" && hot.CityId == "BAN"
                                select hot).ToList();
            return View(holy);
        }
    }
}