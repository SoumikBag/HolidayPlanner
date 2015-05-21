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


        public ActionResult FirstPune(string clickinfo)
        {

            var db = new HolidayPlanner.Models.InfoData();


            switch (clickinfo)
            {

                case "Distance100":
                    {

                        List<Hotel> holy = (from hot in db.Hotels
                                            where hot.CityId == "PU" && hot.Distance == 100
                                            select hot).ToList();

                        return View("FirstPune", holy);
                    }

                case "Distance150":
                    {
                        List<Hotel> holy = (from hot in db.Hotels
                                            where hot.CityId == "PU" && hot.Distance == 150
                                            select hot).ToList();
                        return View("FirstPune", holy);
                    }

                case "Distance200":
                    {
                        List<Hotel> holy = (from hot in db.Hotels
                                            where hot.CityId == "PU" && hot.Distance == 200
                                            select hot).ToList();

                        return View("FirstPune", holy);
                    }

                case "Distance300":
                    {
                        List<Hotel> holy = (from hot in db.Hotels
                                            where hot.CityId == "PU" && hot.Distance == 300
                                            select hot).ToList();
                        return View("FirstPune", holy);
                    }

                case "DistanceGreater300":
                    {
                        List<Hotel> holy = (from hot in db.Hotels
                                            where hot.CityId == "PU" && hot.Distance > 300
                                            select hot).ToList();

                        return View("FirstPune", holy);
                    }
                case "CheapHotel":
                    {
                        List<Hotel> holy = (from hot in db.Hotels
                                            where hot.CityId == "PU" && hot.Budget == "Cheap"
                                            select hot).ToList();

                        return View("FirstPune", holy);
                    }
                case "MidRangeHotel":
                    {
                        List<Hotel> holy = (from hot in db.Hotels
                                            where hot.CityId == "PU" && hot.Budget == "Mid Range"
                                            select hot).ToList();

                        return View("FirstPune", holy);
                    }
                case "PremiumHotel":
                    {
                        List<Hotel> holy = (from hot in db.Hotels
                                            where hot.CityId == "PU" && hot.Budget == "Premium"
                                            select hot).ToList();

                        return View("FirstPune", holy);
                    }
                case "LuxuryHotel":
                    {
                        List<Hotel> holy = (from hot in db.Hotels
                                            where hot.CityId == "PU" && hot.Budget == "Luxury"
                                            select hot).ToList();

                        return View("FirstPune", holy);
                    }
               

                case "SwimmingPool":
                    {
            
                        List<Hotel> facilityinfo = (from f in db.Facilities
                                                    join h in db.Hotels
                                                    on f.HotelId equals h.HotelId
                                                    where f.FacilitiesType == "Swimming Pool" && h.CityId == "PU"
                                                    select h).ToList();

                        return View("FirstPune", facilityinfo);
                    }

                case "IndoorGames":
                    {
                        List<Hotel> facilityinfo = (from f in db.Facilities
                                                    join h in db.Hotels
                                                    on f.HotelId equals h.HotelId
                                                    where f.FacilitiesType == "Indoor Games" && h.CityId == "PU"
                                                    select h).ToList();

                        return View("FirstPune", facilityinfo);
                    }

                case "OutdoorGames":
                        {
                            List<Hotel> facilityinfo = (from f in db.Facilities
                                                        join h in db.Hotels
                                                        on f.HotelId equals h.HotelId
                                                        where f.FacilitiesType == "Outdoor Games" && h.CityId == "PU"
                                                        select h).ToList();

                            return View("FirstPune", facilityinfo);
                        }

                case "Spa":
                    {
                        List<Hotel> facilityinfo = (from f in db.Facilities
                                                    join h in db.Hotels
                                                    on f.HotelId equals h.HotelId
                                                    where f.FacilitiesType == "Spa" && h.CityId == "PU"
                                                    select h).ToList();

                        return View("FirstPune", facilityinfo);
                    }

                case "Garden":
                    {
                        List<Hotel> facilityinfo = (from f in db.Facilities
                                                    join h in db.Hotels
                                                    on f.HotelId equals h.HotelId
                                                    where f.FacilitiesType == "Garden" && h.CityId == "PU"
                                                    select h).ToList();

                        return View("FirstPune", facilityinfo);
                    }

                case "PartyHall":
                    {
                        List<Hotel> facilityinfo = (from f in db.Facilities
                                                    join h in db.Hotels
                                                    on f.HotelId equals h.HotelId
                                                    where f.FacilitiesType == "Party Hall" && h.CityId == "PU"
                                                    select h).ToList();

                        return View("FirstPune", facilityinfo);
                    }

                case "Bar":
                    {
                        List<Hotel> facilityinfo = (from f in db.Facilities
                                                    join h in db.Hotels
                                                    on f.HotelId equals h.HotelId
                                                    where f.FacilitiesType == "Bar" && h.CityId == "PU"
                                                    select h).ToList();

                        return View("FirstPune", facilityinfo);
                    }

                case "Lonavala":
                    {
                        List<Hotel> holy = (from hot in db.Hotels
                                            where hot.CityId == "PU" && hot.Address == "Lonavala"
                                            select hot).ToList();
                        return View("FirstPune", holy);
                    }

                case "Mahabaleshwar":
                    {
                        List<Hotel> holy = (from hot in db.Hotels
                                            where hot.CityId == "PU" && hot.Address == "Mahabaleshwar"
                                            select hot).ToList();
                        return View("FirstPune", holy);
                    }

                case "Kolad":
                    {
                        List<Hotel> holy = (from hot in db.Hotels
                                            where hot.CityId == "PU" && hot.Address == "Kolad"
                                            select hot).ToList();
                        return View("FirstPune", holy);
                    }

                case "Panchgani":
                    {
                        List<Hotel> holy = (from hot in db.Hotels
                                            where hot.CityId == "PU" && hot.Address == "Panchgani"
                                            select hot).ToList();
                        return View("FirstPune", holy);
                    }

                case "Saputara":
                    {
                        List<Hotel> holy = (from hot in db.Hotels
                                            where hot.CityId == "PU" && hot.Address == "Saputara"
                                            select hot).ToList();
                        return View("FirstPune", holy);
                    }

            }

            return View();

        }


    }
}