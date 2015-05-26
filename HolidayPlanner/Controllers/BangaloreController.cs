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

         private AddressRepository addressRepository;

       
         public BangaloreController() : this(new AddressRepository())
        {
        }


         public BangaloreController(AddressRepository addressRepository)
        {
            
            this.addressRepository = addressRepository;
        }


        [HttpGet]
        public ActionResult Bangalore()
        {
            AddressModel model = new AddressModel();
            model.AvailableStates.Add(new SelectListItem { Text = "-Please select-", Value = "Selects items" });
            model.AvailableCountries.Add(new SelectListItem { Text = "-Please select-", Value = "Selects items" });
            model.AvailableCities.Add(new SelectListItem { Text = "-Please Select-", Value = "Selects items" });
            var countries = addressRepository.GetAllCountries();
            foreach (var country in countries)
            {

                model.AvailableCountries.Add(new SelectListItem()
                {
                    Text = country.CountryName,
                    Value = country.CountryId.ToString()
                });

            }



            return View(model);
        }

        [HttpPost]
        public ActionResult Bangalore(AddressModel model)
        {
            var selectedId = model.CityId;

            return RedirectToAction("Index1", "Main", new { Id = selectedId, clickinfo = "hotels" });

        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetStatesByCountryId(string countryId)
        {
            if (String.IsNullOrEmpty(countryId))
            {
                throw new ArgumentNullException("countryId");
            }
            //int id = 0;
            //bool isValid = Int32.TryParse(countryId, out id);

            AddressModel p = new AddressModel();
            var states = addressRepository.GetAllStatesByCountryId(countryId);

            foreach (var state in states)
            {
                p.AvailableStates.Add(new SelectListItem()
                {
                    Text = state.StateName,
                    Value = state.StateId.ToString()
                });
            }
            var result = (from s in p.AvailableStates
                          select new
                          {
                              countryId = s.Value,
                              name = s.Text,

                          }).ToList();


            return Json(result, JsonRequestBehavior.AllowGet);

        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetCitysByStateId(string stateId)
        {
            if (String.IsNullOrEmpty(stateId))
            {
                throw new ArgumentNullException("stateId");
            }
            //int id = 0;
            //bool isValid = Int32.TryParse(countryId, out id);
            AddressModel c = new AddressModel();
            var citys = addressRepository.GetAllCitysByStateId(stateId);


            var result = (from c1 in citys
                          select new
                          {
                              stateId = c1.CityId,
                              name = c1.CityName
                          }).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);

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