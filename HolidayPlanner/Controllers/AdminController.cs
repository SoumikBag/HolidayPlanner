using HolidayPlanner.DAL;
using HolidayPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace HolidayPlanner.Controllers
{
    [CustomAuthorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult HotelDetail()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<HolidayPlanner.Models.Hotel> Hdetail = (from hot in db.Hotels
                                select hot).ToList();
            return PartialView("HotelDetailPartial", Hdetail);
        }


        private DDLOperationDataContext context = new DDLOperationDataContext();

        private void PrepareHotelType(HotelModel model)
        {
            model.HotelTypes = context.HotelTypes.AsQueryable<HolidayPlanner.DAL.HotelType>().Select(x =>
                                                            new SelectListItem()
                                                            {
                                                                Text = x.HotelType1,
                                                                Value = x.HTypeId.ToString()
                                                            });

        }

        private void PrepareCity(HotelModel model)
        {
            model.Cities = context.Cities.AsQueryable<HolidayPlanner.DAL.City>().Select(x =>
                                                            new SelectListItem()
                                                            {
                                                                Text = x.CityName,
                                                                Value = x.CityId.ToString()
                                                            });

        }

        private void PrepareHotel(FacilityModel model)
        {
            model.Hotels = context.Hotels.AsQueryable<HolidayPlanner.DAL.Hotel>().Select(x =>
                                                            new SelectListItem()
                                                            {
                                                                Text = x.HotelName,
                                                                Value = x.HotelId.ToString()
                                                            });

        }

        private void PrepareHotel1(RoomModel model)
        {
            model.Hotels = context.Hotels.AsQueryable<HolidayPlanner.DAL.Hotel>().Select(x =>
                                                            new SelectListItem()
                                                            {
                                                                Text = x.HotelName,
                                                                Value = x.HotelId.ToString()
                                                            });

        }

        private void PrepareHotel2(LocationModel model)
        {
            model.Hotels = context.Hotels.AsQueryable<HolidayPlanner.DAL.Hotel>().Select(x =>
                                                            new SelectListItem()
                                                            {
                                                                Text = x.HotelName,
                                                                Value = x.HotelId.ToString()
                                                            });

        }
        private void PrepareCountry(StateModel model)
        {
            model.Countries = context.Countries.AsQueryable<HolidayPlanner.DAL.Country>().Select(x =>
                                                            new SelectListItem()
                                                            {
                                                                Text = x.CountryName,
                                                                Value = x.CountryId.ToString()
                                                            });

        }

        private void PrepareState(CityModel model)
        {
            model.States = context.States.AsQueryable<HolidayPlanner.DAL.State>().Select(x =>
                                                            new SelectListItem()
                                                            {
                                                                Text = x.StateName,
                                                                Value = x.StateId.ToString()
                                                            });

        }
        [HttpGet]
        public ActionResult AddHotel()
        {
            HotelModel model = new HotelModel();
            PrepareHotelType(model);
            PrepareCity(model);

            int Hno = context.Hotels.Max(x => x.HotelId);
            int Hno1 = Hno + 1;
            ViewData["Id"] = Hno1;
            return View(model);
        }

        [HttpGet]
        public ActionResult AddFacility()
        {
            FacilityModel model = new FacilityModel();
            PrepareHotel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult AddFacility(FacilityModel fmodel)
        {
            try
            {
                HolidayPlanner.DAL.Facility ft = new HolidayPlanner.DAL.Facility()
                {
                    FacilityId = fmodel.FacilityId,
                    FacilitiesType = fmodel.FacilitiesType,
                    HotelId = fmodel.HotelId
                };
                context.Facilities.InsertOnSubmit(ft);
                context.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(fmodel);
            }
        }


        [HttpGet]
        public ActionResult AddRoom()
        {
            RoomModel model = new RoomModel();
            PrepareHotel1(model);
            return View(model);
        }


        [HttpPost]
        public ActionResult AddRoom(RoomModel rmodel)
        {
            try
            {
                HolidayPlanner.DAL.Room rt = new HolidayPlanner.DAL.Room()
                {
                    RoomId = rmodel.RoomId,
                    RoomType = rmodel.RoomType,
                    RoomDetails = rmodel.RoomDetails,
                    RoomCapacity=rmodel.RoomCapacity,
                    Rate=rmodel.Rate,
                    HotelId=rmodel.HotelId
                };
                context.Rooms.InsertOnSubmit(rt);
                context.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(rmodel);
            }
        }

        [HttpGet]
        public ActionResult AddLocation()
        {
            CountryModel cmodel = new CountryModel();
            return View(cmodel);
        }

        [HttpPost]
        public ActionResult AddLocation(CountryModel cmodel)
        {
            try
            {
                HolidayPlanner.DAL.Country ct = new HolidayPlanner.DAL.Country()
                {
                    CountryId = cmodel.CountryId,
                    CountryName = cmodel.CountryName
                };
                context.Countries.InsertOnSubmit(ct);
                context.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(cmodel);
            }
        }

        [HttpGet]
        public ActionResult AddState()
        {
            StateModel smodel = new StateModel();
            PrepareCountry(smodel);
            return View(smodel);
        }

        [HttpPost]
        public ActionResult AddState(StateModel smodel)
        {
            try
            {
                HolidayPlanner.DAL.State st = new HolidayPlanner.DAL.State()
                {
                    StateId = smodel.StateId,
                    StateName = smodel.StateName,
                    CountryId=smodel.CountryId
                };
                context.States.InsertOnSubmit(st);
                context.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(smodel);
            }
        }

        [HttpGet]
        public ActionResult AddCity()
        {
            CityModel cmodel = new CityModel();
            PrepareState(cmodel);
            return View(cmodel);
        }


        [HttpPost]
        public ActionResult AddCity(CityModel ctmodel)
        {
            try
            {
                HolidayPlanner.DAL.City city = new HolidayPlanner.DAL.City()
                {
                    CityId = ctmodel.CityId,
                    CityName = ctmodel.CityName,
                    StateId = ctmodel.StateId
                };
                context.Cities.InsertOnSubmit(city);
                context.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(ctmodel);
            }
        }

        [HttpGet]
        public ActionResult AddMapLoc()
        {
            LocationModel model = new LocationModel();
            PrepareHotel2(model);

            int Lno = context.Locations.Max(x => x.LocationId);
            int Lno1 = Lno + 1;
            ViewData["LId"] = Lno1;

            return View(model);
        }

        [HttpPost]
        public ActionResult AddMapLoc(LocationModel lmodel)
        {
            try
            {
                HolidayPlanner.DAL.Location lc = new HolidayPlanner.DAL.Location()
                {
                    LocationId = lmodel.LocationId,
                    LocationName=lmodel.LocationName,
                    Latitude=lmodel.Latitude,
                    Longitude=lmodel.Longitude,
                    HotelId=lmodel.HotelId
                };
                context.Locations.InsertOnSubmit(lc);
                context.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(lmodel);
            }
        }

    }
}