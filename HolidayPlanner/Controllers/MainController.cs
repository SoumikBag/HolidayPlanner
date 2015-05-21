using HolidayPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HolidayPlanner.Controllers
{
    public class MainController : Controller
    {

        public ActionResult Index1(string Id, string clickinfo)
        {
            var db = new HolidayPlanner.Models.InfoData();

            TempData["Data"] = Id;
            switch (clickinfo)
            {

                case "hotels":
                    {
                        List<Hotel> abc = (from hot in db.Hotels
                                           where hot.CityId == Id
                                           select hot).ToList();
                        return View("Index1",abc);
                    }
    
            }
            return View();
        }
        
        public ActionResult Demo(string clickinfo)
        {
            var db = new HolidayPlanner.Models.InfoData();

            var dt=TempData.Peek("Data");
            
            switch (clickinfo)
            {
                
                case "Distance100":
                    {

                        List<Hotel> holy = (from hot in db.Hotels
                                            where hot.CityId == dt && hot.Distance == 100
                                            select hot).ToList();

                        return View("Index1", holy);
                    }

                case "Distance150":
                    {
                        List<Hotel> holy = (from hot in db.Hotels
                                            where hot.CityId == dt && hot.Distance == 150
                                            select hot).ToList();
                        return View("Index1", holy);
                    }

                case "Distance200":
                    {
                        List<Hotel> holy = (from hot in db.Hotels
                                            where hot.CityId == dt && hot.Distance == 200
                                            select hot).ToList();

                        return View("Index1", holy);
                    }

                case "Distance300":
                    {
                        List<Hotel> holy = (from hot in db.Hotels
                                            where hot.CityId == dt && hot.Distance == 300
                                            select hot).ToList();
                        return View("Index1", holy);
                    }

                case "DistanceGreater300":
                    {
                        List<Hotel> holy = (from hot in db.Hotels
                                            where hot.CityId == dt && hot.Distance > 300
                                            select hot).ToList();

                        return View("Index1", holy);
                    }
                case "CheapHotel":
                    {
                        List<Hotel> holy = (from hot in db.Hotels
                                            where hot.CityId == dt && hot.Budget == "Cheap"
                                            select hot).ToList();

                        return View("Index1", holy);
                    }
                case "MidRangeHotel":
                    {
                        List<Hotel> holy = (from hot in db.Hotels
                                            where hot.CityId == dt && hot.Budget == "Mid Range"
                                            select hot).ToList();

                        return View("Index1", holy);
                    }
                case "PremiumHotel":
                    {
                        List<Hotel> holy = (from hot in db.Hotels
                                            where hot.CityId == dt && hot.Budget == "Premium"
                                            select hot).ToList();

                        return View("Index1", holy);
                    }
                case "LuxuryHotel":
                    {
                        List<Hotel> holy = (from hot in db.Hotels
                                            where hot.CityId == dt && hot.Budget == "Luxury"
                                            select hot).ToList();

                        return View("Index1", holy);
                    }


                case "SwimmingPool":
                    {

                        List<Hotel> facilityinfo = (from f in db.Facilities
                                                    join h in db.Hotels
                                                    on f.HotelId equals h.HotelId
                                                    where f.FacilitiesType == "Swimming Pool" && h.CityId == dt
                                                    select h).ToList();

                        return View("Index1", facilityinfo);
                    }

                case "IndoorGames":
                    {
                        List<Hotel> facilityinfo = (from f in db.Facilities
                                                    join h in db.Hotels
                                                    on f.HotelId equals h.HotelId
                                                    where f.FacilitiesType == "Indoor Games" && h.CityId == dt
                                                    select h).ToList();

                        return View("Index1", facilityinfo);
                    }

                case "OutdoorGames":
                    {
                        List<Hotel> facilityinfo = (from f in db.Facilities
                                                    join h in db.Hotels
                                                    on f.HotelId equals h.HotelId
                                                    where f.FacilitiesType == "Outdoor Games" && h.CityId == dt
                                                    select h).ToList();

                        return View("Index1", facilityinfo);
                    }

                case "Spa":
                    {
                        List<Hotel> facilityinfo = (from f in db.Facilities
                                                    join h in db.Hotels
                                                    on f.HotelId equals h.HotelId
                                                    where f.FacilitiesType == "Spa" && h.CityId == dt
                                                    select h).ToList();

                        return View("Index1", facilityinfo);
                    }

                case "Garden":
                    {
                        List<Hotel> facilityinfo = (from f in db.Facilities
                                                    join h in db.Hotels
                                                    on f.HotelId equals h.HotelId
                                                    where f.FacilitiesType == "Garden" && h.CityId == dt
                                                    select h).ToList();

                        return View("Index1", facilityinfo);
                    }

                case "PartyHall":
                    {
                        List<Hotel> facilityinfo = (from f in db.Facilities
                                                    join h in db.Hotels
                                                    on f.HotelId equals h.HotelId
                                                    where f.FacilitiesType == "Party Hall" && h.CityId == dt
                                                    select h).ToList();

                        return View("Index1", facilityinfo);
                    }

                case "Bar":
                    {
                        List<Hotel> facilityinfo = (from f in db.Facilities
                                                    join h in db.Hotels
                                                    on f.HotelId equals h.HotelId
                                                    where f.FacilitiesType == "Bar" && h.CityId == dt
                                                    select h).ToList();

                        return View("Index1", facilityinfo);
                    }

                case "Ooty":
                    {
                        List<Hotel> holy = (from hot in db.Hotels
                                            where hot.CityId == dt && hot.Address == "Ooty"
                                            select hot).ToList();
                        return View("Index1", holy);
                    }

                case "Mysore":
                    {
                        List<Hotel> holy = (from hot in db.Hotels
                                            where hot.CityId == dt && hot.Address == "Mysore"
                                            select hot).ToList();
                        return View("Index1", holy);
                    }

                case "Sakleshpur":
                    {
                        List<Hotel> holy = (from hot in db.Hotels
                                            where hot.CityId == dt && hot.Address == "Sakleshpur"
                                            select hot).ToList();
                        return View("Index1", holy);
                    }

                case "Coorg":
                    {
                        List<Hotel> holy = (from hot in db.Hotels
                                            where hot.CityId == dt && hot.Address == "Coorg"
                                            select hot).ToList();
                        return View("Index1", holy);
                    }

                case "Coonoor":
                    {
                        List<Hotel> holy = (from hot in db.Hotels
                                            where hot.CityId == dt && hot.Address == "Coonoor"
                                            select hot).ToList();
                        return View("Index1", holy);
                    }

                case "Luxury":
                    {
                        List<Hotel> abc = (from hot in db.Hotels
                                           where hot.HTypeId == "LU" && hot.CityId == dt
                                           select hot).ToList();
                        return View("Index1", abc);
                    }

                case "BeachFacing":
                    {
                        List<Hotel> bfac = (from hot in db.Hotels
                                            where hot.HTypeId == "BF" && hot.CityId == dt
                                            select hot).ToList();
                        return View("Index1", bfac);
                    }

                case "Romantic":
                    {
                        List<Hotel> rom = (from hot in db.Hotels
                                           where hot.HTypeId == "RM" && hot.CityId == dt
                                           select hot).ToList();
                        return View("Index1", rom);
                    }

                case "ValleyView":
                    {
                        List<Hotel> valy = (from hot in db.Hotels
                                            where hot.HTypeId == "VV" && hot.CityId == dt
                                            select hot).ToList();
                        return View("Index1", valy);
                    }

                case "Adventure":
                    {
                        List<Hotel> adv = (from hot in db.Hotels
                                           where hot.HTypeId == "AV" && hot.CityId == dt
                                           select hot).ToList();
                        return View("Index1", adv);
                    }

                case "RiverSide":
                    {
                        List<Hotel> rside = (from hot in db.Hotels
                                             where hot.HTypeId == "RS" && hot.CityId == dt
                                             select hot).ToList();
                        return View("Index1", rside);
                    }

                case "PureVeg":
                    {
                        List<Hotel> pveg = (from hot in db.Hotels
                                            where hot.HTypeId == "PV" && hot.CityId == dt
                                            select hot).ToList();
                        return View("Index1", pveg);
                    }

                case "PetFriendly":
                    {
                        List<Hotel> pet = (from hot in db.Hotels
                                           where hot.HTypeId == "PF" && hot.CityId == dt
                                           select hot).ToList();
                        return View("Index1", pet);
                    }

                case "Beaches":
                    {
                        List<Hotel> beach = (from hot in db.Hotels
                                             where hot.HTypeId == "BC" && hot.CityId == dt
                                             select hot).ToList();
                        return View("Index1", beach);
                    }

                case "HillStations":
                    {
                        List<Hotel> hill = (from hot in db.Hotels
                                            where hot.HTypeId == "HS" && hot.CityId == dt
                                            select hot).ToList();
                        return View("Index1", hill);
                    }

                case "Farms":
                    {
                        List<Hotel> far = (from hot in db.Hotels
                                           where hot.HTypeId == "FA" && hot.CityId == dt
                                           select hot).ToList();
                        return View("Index1", far);
                    }

                case "HolyPlaces":
                    {
                        List<Hotel> holy = (from hot in db.Hotels
                                            where hot.HTypeId == "HP" && hot.CityId == dt
                                            select hot).ToList();
                        return View("Index1", holy);
                    }
            }
            return View();
        }
    }
}