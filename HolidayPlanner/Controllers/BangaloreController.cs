﻿using HolidayPlanner.Models;
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

        public ActionResult FirstBangalore(string clickinfo)
        {

            var db = new HolidayPlanner.Models.InfoData();


            switch (clickinfo)
            {

                case "Distance100":
                    {

                        List<Hotel> holy = (from hot in db.Hotels
                                            where hot.CityId == "BAN" && hot.Distance == 100
                                            select hot).ToList();

                        return View("FirstBangalore", holy);
                    }

                case "Distance150":
                    {
                        List<Hotel> holy = (from hot in db.Hotels
                                            where hot.CityId == "BAN" && hot.Distance == 150
                                            select hot).ToList();
                        return View("FirstBangalore", holy);
                    }

                case "Distance200":
                    {
                        List<Hotel> holy = (from hot in db.Hotels
                                            where hot.CityId == "BAN" && hot.Distance == 200
                                            select hot).ToList();

                        return View("FirstBangalore", holy);
                    }

                case "Distance300":
                    {
                        List<Hotel> holy = (from hot in db.Hotels
                                            where hot.CityId == "BAN" && hot.Distance == 300
                                            select hot).ToList();
                        return View("FirstBangalore", holy);
                    }

                case "DistanceGreater300":
                    {
                        List<Hotel> holy = (from hot in db.Hotels
                                            where hot.CityId == "BAN" && hot.Distance > 300
                                            select hot).ToList();

                        return View("FirstBangalore", holy);
                    }
                case "CheapHotel":
                    {
                        List<Hotel> holy = (from hot in db.Hotels
                                            where hot.CityId == "BAN" && hot.Budget == "Cheap"
                                            select hot).ToList();

                        return View("FirstBangalore", holy);
                    }
                case "MidRangeHotel":
                    {
                        List<Hotel> holy = (from hot in db.Hotels
                                            where hot.CityId == "BAN" && hot.Budget == "Mid Range"
                                            select hot).ToList();

                        return View("FirstBangalore", holy);
                    }
                case "PremiumHotel":
                    {
                        List<Hotel> holy = (from hot in db.Hotels
                                            where hot.CityId == "BAN" && hot.Budget == "Premium"
                                            select hot).ToList();

                        return View("FirstBangalore", holy);
                    }
                case "LuxuryHotel":
                    {
                        List<Hotel> holy = (from hot in db.Hotels
                                            where hot.CityId == "BAN" && hot.Budget == "Luxury"
                                            select hot).ToList();

                        return View("FirstBangalore", holy);
                    }


                case "SwimmingPool":
                    {

                        List<Hotel> facilityinfo = (from f in db.Facilities
                                                    join h in db.Hotels
                                                    on f.HotelId equals h.HotelId
                                                    where f.FacilitiesType == "Swimming Pool" && h.CityId == "BAN"
                                                    select h).ToList();

                        return View("FirstBangalore", facilityinfo);
                    }

                case "IndoorGames":
                    {
                        List<Hotel> facilityinfo = (from f in db.Facilities
                                                    join h in db.Hotels
                                                    on f.HotelId equals h.HotelId
                                                    where f.FacilitiesType == "Indoor Games" && h.CityId == "BAN"
                                                    select h).ToList();

                        return View("FirstBangalore", facilityinfo);
                    }

                case "OutdoorGames":
                    {
                        List<Hotel> facilityinfo = (from f in db.Facilities
                                                    join h in db.Hotels
                                                    on f.HotelId equals h.HotelId
                                                    where f.FacilitiesType == "Outdoor Games" && h.CityId == "BAN"
                                                    select h).ToList();

                        return View("FirstBangalore", facilityinfo);
                    }

                case "Spa":
                    {
                        List<Hotel> facilityinfo = (from f in db.Facilities
                                                    join h in db.Hotels
                                                    on f.HotelId equals h.HotelId
                                                    where f.FacilitiesType == "Spa" && h.CityId == "BAN"
                                                    select h).ToList();

                        return View("FirstBangalore", facilityinfo);
                    }

                case "Garden":
                    {
                        List<Hotel> facilityinfo = (from f in db.Facilities
                                                    join h in db.Hotels
                                                    on f.HotelId equals h.HotelId
                                                    where f.FacilitiesType == "Garden" && h.CityId == "BAN"
                                                    select h).ToList();

                        return View("FirstBangalore", facilityinfo);
                    }

                case "PartyHall":
                    {
                        List<Hotel> facilityinfo = (from f in db.Facilities
                                                    join h in db.Hotels
                                                    on f.HotelId equals h.HotelId
                                                    where f.FacilitiesType == "Party Hall" && h.CityId == "BAN"
                                                    select h).ToList();

                        return View("FirstBangalore", facilityinfo);
                    }

                case "Bar":
                    {
                        List<Hotel> facilityinfo = (from f in db.Facilities
                                                    join h in db.Hotels
                                                    on f.HotelId equals h.HotelId
                                                    where f.FacilitiesType == "Bar" && h.CityId == "BAN"
                                                    select h).ToList();

                        return View("FirstBangalore", facilityinfo);
                    }

                case "Ooty":
                    {
                        List<Hotel> holy = (from hot in db.Hotels
                                            where hot.CityId == "BAN" && hot.Address == "Ooty"
                                            select hot).ToList();
                        return View("FirstBangalore", holy);
                    }

                case "Mysore":
                    {
                        List<Hotel> holy = (from hot in db.Hotels
                                            where hot.CityId == "BAN" && hot.Address == "Mysore"
                                            select hot).ToList();
                        return View("FirstBangalore", holy);
                    }

                case "Sakleshpur":
                    {
                        List<Hotel> holy = (from hot in db.Hotels
                                            where hot.CityId == "BAN" && hot.Address == "Sakleshpur"
                                            select hot).ToList();
                        return View("FirstBangalore", holy);
                    }

                case "Coorg":
                    {
                        List<Hotel> holy = (from hot in db.Hotels
                                            where hot.CityId == "BAN" && hot.Address == "Coorg"
                                            select hot).ToList();
                        return View("FirstBangalore", holy);
                    }

                case "Coonoor":
                    {
                        List<Hotel> holy = (from hot in db.Hotels
                                            where hot.CityId == "BAN" && hot.Address == "Coonoor"
                                            select hot).ToList();
                        return View("FirstBangalore", holy);
                    }

            }

            return View();

        }

    }
}