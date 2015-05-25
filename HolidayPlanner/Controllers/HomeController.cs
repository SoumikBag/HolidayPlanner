using HolidayPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace HolidayPlanner.Controllers
{
    [CustomAuthorize(Roles = "Client")]
    public class HomeController : Controller
    {
        
        private AddressRepository addressRepository;
        
        public HomeController() : this(new AddressRepository())
        {
        }


        public HomeController(AddressRepository addressRepository)
        {
            
            this.addressRepository = addressRepository;
        }

        [HttpGet]
        public ActionResult Index()
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
        public ActionResult Index(AddressModel model)
        {
            var selectedId = model.CityId;

            return RedirectToAction("Index1", "Main", new { Id = selectedId, clickinfo="hotels" });

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
        
        //started by sandy
        //public ActionResult Index()
        //{
        //    //AddressModel model = new AddressModel();
        //    //model.AvailableStates.Add(new SelectListItem { Text = "-Please select-", Value = "Selects items" });
        //    //model.AvailableCountries.Add(new SelectListItem { Text = "-Please select-", Value = "Selects items" });

        //    //var countries = _repository.GetAllCountries();
        //    //foreach (var country in countries)
        //    //{

        //    //    model.AvailableCountries.Add(new SelectListItem()
        //    //    {
        //    //        Text = country.CountryName,
        //    //        Value = country.CountryId.ToString()
        //    //    });

        //    //}



        //    return View();
        //    //AddressModel adress = new AddressModel();
        //    //return View();
        //    //InfoViewModel c = new InfoViewModel();
        //    //c.CountryList = new SelectList(Ccon.GetCountryList(), "CountryId", "CountryName");
        //    //InfoViewModel ivm = new InfoViewModel();
        //    //return View(ivm);
        //}
        //ended by sandy


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Living()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Feedback1()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Feedback1(Models.Feedback feed)
        {
            if (ModelState.IsValid)
            {
                using (var db = new HolidayPlanner.Models.FeedbackContext())
                {
                    var newUser = db.Feedbacks.Create();
                    newUser.Name = feed.Name;
                    newUser.EmailId = feed.EmailId;
                    newUser.Subject = feed.Subject;
                    newUser.Message = feed.Message;

                    db.Feedbacks.Add(newUser);
                    db.SaveChanges();
                    ViewBag.Message = "Feedback send successfully ";
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Data is not correct");
            }
            return View();
        }

        //started by sandy
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {

            if (ModelState.IsValid)
            {
                using (var db = new HolidayPlanner.Models.Register())

                {
                    var newUser = db.Users.Create();
                    int lastUserId = db.Users.Max(item => item.UserId); //added by Sandy for ID Auto-Increment 
                    user.UserId = lastUserId + 1; 
                    newUser.UserId = user.UserId;
                    var test = (newUser.UserId);
                    newUser.UserName = user.UserName;
                    newUser.EmailId = user.EmailId;
                    newUser.ContactNo = user.ContactNo;
                   
                    newUser.Password = user.Password;
                   

                    db.Users.Add(newUser);
                    db.SaveChanges();
        


                    using (var db2 = new HolidayPlanner.Models.UserInRoleContext())
                    {
                        var userrole = db2.UserInRoles.Create();

                    {

                            userrole.UserId = test;
                            userrole.RoleId = 1;
                            db2.UserInRoles.Add(userrole);
                            db2.SaveChanges();

                        }
                    }

                   
                    ViewBag.Message = "Registration Successfully Done ";
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Data is not correct");
            }
            ViewBag.Message = "Please register yourself";
            return View();
        }

        //ended by sandy



        public ActionResult Info(string clickinfo, int? HId)
        {

            var db = new HolidayPlanner.Models.InfoData();
 

            switch(clickinfo)
            {

                case "hoteldetails":
                    {

                        var Hdetail = (from p in db.Hotels
                                         where p.HotelId == HId
                                        select p ).SingleOrDefault();
                                                
                        return View("Info", Hdetail);
                    }

                case "overview":
                    {
                        var Odetail = from p in db.Hotels
                                       where p.HotelId == HId
                                       select new InfoViewModel { HotelDetails = p.HotelDetails };
                        return View("Overview", Odetail);
                    }

                case "room":
                    {
                        var roominfo = from r in db.Rooms
                                       where r.HotelId == HId
                                       select new InfoViewModel { RoomType = r.RoomType, Rate = r.Rate, RoomDetails = r.RoomDetails, RoomCapacity = r.RoomCapacity };

                        return View("RoomInfo", roominfo);
                    }

                case "facility":
                    {
                        var facilityinfo = from f in db.Facilities
                                           join h in db.Hotels
                                           on f.HotelId equals h.HotelId
                                           where f.HotelId == HId
                                           select new InfoViewModel { FacilityType = f.FacilitiesType, FoodDetails = h.FoodDetails, Policies = h.HotelPolices };

                        return View("FacilityInfo", facilityinfo);
                    }

                case "review":
                    {
                        var review = from r in db.Reviews
                                        where r.HotelId == HId
                                        select new InfoViewModel { ReviewDetails = r.ReviewDetails, Rating = r.Rating };

                        return View("ReviewInfo", review);
                    }


                case "Image":
                    {
                        var hname = (from p in db.Hotels
                                     where p.HotelId == HId
                                     select p.HotelName).SingleOrDefault();

                        string[] src = new string[5]; 
                        src[0] = "~/Images/" + hname + "/19011.jpeg";
                        src[1] = "~/Images/" + hname + "/19013.jpeg";
                        src[2] = "~/Images/" + hname + "/19015.jpeg";
                        src[3] = "~/Images/" + hname + "/19016.jpeg";
                        src[4] = "~/Images/" + hname + "/19019.jpeg";


                        for (int i = 0; i < 5; i++)
                        {
                            string path = Server.MapPath(src[i]);
                            byte[] imageByteData = System.IO.File.ReadAllBytes(path);
                            string imageBase64Data = Convert.ToBase64String(imageByteData);
                            string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                            //ViewBag.ImageData[i] = imageDataURL;
                            src[i] = imageDataURL;
                        }
                            ViewBag.ImageData = src;
                            return View("ImageInfo");

                        
            }

            }

            return View();

        }
         


        public ActionResult First()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> abc = (from hot in db.Hotels
                               where hot.HTypeId == "LU" && hot.CityId == "MU"
                               select hot).ToList();
            return View(abc);
        }

        public ActionResult BeachFacing()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> bfac = (from hot in db.Hotels
                                where hot.HTypeId == "BF" && hot.CityId == "MU"
                               select hot).ToList();
            return View(bfac);
        }
                       
        public ActionResult Romantic()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> rom = (from hot in db.Hotels
                               where hot.HTypeId == "RM" && hot.CityId == "MU"
                                select hot).ToList();
            return View(rom);
        }

        public ActionResult ValleyView()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> valy = (from hot in db.Hotels
                                where hot.HTypeId == "VV" && hot.CityId == "MU"
                                select hot).ToList();
            return View(valy);
        }
            
        public ActionResult Adventure()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> adv = (from hot in db.Hotels
                               where hot.HTypeId == "AV" && hot.CityId == "MU"
                                select hot).ToList();
            return View(adv);
        }

        public ActionResult RiverSide()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> rside = (from hot in db.Hotels
                                 where hot.HTypeId == "RS" && hot.CityId == "MU"
                                select hot).ToList();
            return View(rside);
        }

        public ActionResult PureVeg()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> pveg = (from hot in db.Hotels
                                where hot.HTypeId == "PV" && hot.CityId == "MU"
                                select hot).ToList();
            return View(pveg);
        }

        public ActionResult PetFriendly()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> pet = (from hot in db.Hotels
                               where hot.HTypeId == "PF" && hot.CityId == "MU"
                                select hot).ToList();
            return View(pet);
        }

        public ActionResult Beaches()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> beach = (from hot in db.Hotels
                                 where hot.HTypeId == "BC" && hot.CityId == "MU"
                                select hot).ToList();
            return View(beach);
        }

        public ActionResult HillStations()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> hill = (from hot in db.Hotels
                                where hot.HTypeId == "HS" && hot.CityId == "MU"
                                select hot).ToList();
            return View(hill);
        }

        public ActionResult Farms()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> far = (from hot in db.Hotels
                               where hot.HTypeId == "FA" && hot.CityId == "MU"
                                select hot).ToList();
            return View(far);
        }






        //added by sandy for dropdown
        CountryContext Ccon = new CountryContext();
    
        //public ActionResult DropDown1()
        //{
        //    Country c = new Country();
        //    c.CountryList = new SelectList(Ccon.GetCountryList(), "CountryId", "CountryName");

        //    return View("Index", c);
            
        //}


       //added by sandy
        //public ActionResult Search(string CId)
        //{
        //    var db = new HolidayPlanner.Models.InfoData();

        //    var Hdetail = (from p in db.Hotels
        //                   where p.CityId == CId
        //                   select p).SingleOrDefault();


        //    return View("First", Hdetail);
        //}
        //ended by sandy

        public ActionResult HolyPlaces()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> holy = (from hot in db.Hotels
                                where hot.HTypeId == "HP" && hot.CityId == "MU"
                               select hot).ToList();
            return View(holy);
        }

       



        public ActionResult GetId(string name)
        {
            var db = new HolidayPlanner.Models.InfoData();

            var id = from item in db.Hotels
                      where item.HotelName.Equals(name)
                      select item;

            ViewData["Id"] = id;

            return RedirectToAction("First");

        }

        [HttpGet]
        public ActionResult bookingform(int? id)
        {
            ViewData["Id"] = id;
            return View();
        }

        [HttpPost]
        public ActionResult bookingform(FormCollection Collection)
        {
            Random ran= new Random();

            var db= new HolidayPlanner.Models.InfoData();
            Booking buk= new Booking();

            buk.BookingId="B"+ran.Next();
            buk.UserId = Convert.ToInt32(Collection[1]);
            buk.ClientMobileNumber = Collection[2];
            buk.ClientEmailId = Collection[3];
            buk.HotelId = Convert.ToInt32(Collection[4]);
            buk.CheckInDate = Convert.ToDateTime(Collection[5]);
            buk.CheckOutDate = Convert.ToDateTime(Collection[6]);
            buk.NoOfAdults = Convert.ToInt32(Collection[7]);
            buk.NoOfChildren = Convert.ToInt32(Collection[8]);
            buk.Message = Collection[9];
            buk.TotalAmount = Convert.ToDecimal(Collection[10]);

            db.Bookings.Add(buk);


            //var newrec = from c in db.Bookings
            //             select c;

            


            //buk.UserId= Collection[0];

            return View();
        }

        public ActionResult Distance100()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> holy = (from hot in db.Hotels
                                where hot.CityId == "MU" && hot.Distance==100  
                                select hot).ToList();
            return View(holy);
        }

        public ActionResult Distance150()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> holy = (from hot in db.Hotels
                                where hot.CityId == "MU" && hot.Distance == 150
                                select hot).ToList();
            return View(holy);
        }
        
        public ActionResult Distance200()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> holy = (from hot in db.Hotels
                                where hot.CityId == "MU" && hot.Distance == 200
                                select hot).ToList();
            return View(holy);
        }

        public ActionResult Distance300()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> holy = (from hot in db.Hotels
                                where hot.CityId == "MU" && hot.Distance == 300
                                select hot).ToList();
            return View(holy);
        }

        public ActionResult DistanceGreater300()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> holy = (from hot in db.Hotels
                                where hot.CityId == "MU" && hot.Distance > 300
                                select hot).ToList();
            return View(holy);
        }

        public ActionResult Lonavala()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> holy = (from hot in db.Hotels
                                where hot.CityId == "MU" && hot.Address=="Lonavala"
                                select hot).ToList();
            return View(holy);
        }

        public ActionResult Silvassa()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> holy = (from hot in db.Hotels
                                where hot.CityId == "MU" && hot.Address == "Silvassa"
                                select hot).ToList();
            return View(holy);
        }

        public ActionResult Alibag()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> holy = (from hot in db.Hotels
                                where hot.CityId == "MU" && hot.Address == "Alibag"
                                select hot).ToList();
            return View(holy);
        }

        public ActionResult Lavasa()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> holy = (from hot in db.Hotels
                                where hot.CityId == "MU" && hot.Address == "Lavasa"
                                select hot).ToList();
            return View(holy);
        }

        public ActionResult Karjet()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> holy = (from hot in db.Hotels
                                where hot.CityId == "MU" && hot.Address == "Karjet"
                                select hot).ToList();
            return View(holy);
        }

        public ActionResult CheapHotel()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> holy = (from hot in db.Hotels
                                where hot.CityId == "MU" && hot.Budget=="Cheap"
                                select hot).ToList();
            return View(holy);
        }

        public ActionResult MidRangeHotel()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> holy = (from hot in db.Hotels
                                where hot.CityId == "MU" && hot.Budget == "Mid Range"
                                select hot).ToList();
            return View(holy);
        }

        public ActionResult PremiumHotel()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> holy = (from hot in db.Hotels
                                where hot.CityId == "MU" && hot.Budget == "Premium"
                                select hot).ToList();
            return View(holy);
        }

        public ActionResult LuxuryHotel()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> holy = (from hot in db.Hotels
                                where hot.CityId == "MU" && hot.Budget == "Luxury"
                                select hot).ToList();
            return View(holy);
        }

        //public ActionResult AllPriceHotel()
        //{
        //    var list = new List<string>();
        //    list.Add("Cheap");
        //    list.Add("Luxury");
        //    list.Add("Premium");
        //    list.Add("Mid Range");


        //    var db = new HolidayPlanner.Models.InfoData();
        //    List<Hotel> holy = (from hot in db.Hotels
        //                        where hot.CityId == "MU" && hot.Budget.Contains(list)
        //                        select hot).ToList();
        //    return View(holy);
        //}

       public ActionResult SwimmingPool()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> facilityinfo = (from f in db.Facilities
                               join h in db.Hotels
                               on f.HotelId equals h.HotelId
                               where f.FacilitiesType == "Swimming Pool" && h.CityId=="MU"
                                        select h).ToList(); 

            return View(facilityinfo);
        }

       public ActionResult IndoorGames()
       {
           var db = new HolidayPlanner.Models.InfoData();
           List<Hotel> facilityinfo = (from f in db.Facilities
                                       join h in db.Hotels
                                       on f.HotelId equals h.HotelId
                                       where f.FacilitiesType == "Indoor Games" && h.CityId == "MU"
                                       select h).ToList();

           return View(facilityinfo);
       }

       public ActionResult OutdoorGames()
       {
           var db = new HolidayPlanner.Models.InfoData();
           List<Hotel> facilityinfo = (from f in db.Facilities
                                       join h in db.Hotels
                                       on f.HotelId equals h.HotelId
                                       where f.FacilitiesType == "Outdoor Games" && h.CityId == "MU"
                                       select h).ToList();

           return View(facilityinfo);
       }

       public ActionResult Spa()
       {
           var db = new HolidayPlanner.Models.InfoData();
           List<Hotel> facilityinfo = (from f in db.Facilities
                                       join h in db.Hotels
                                       on f.HotelId equals h.HotelId
                                       where f.FacilitiesType == "Spa" && h.CityId == "MU"
                                       select h).ToList();

           return View(facilityinfo);
       }

       public ActionResult Garden()
       {
           var db = new HolidayPlanner.Models.InfoData();
           List<Hotel> facilityinfo = (from f in db.Facilities
                                       join h in db.Hotels
                                       on f.HotelId equals h.HotelId
                                       where f.FacilitiesType == "Garden" && h.CityId == "MU"
                                       select h).ToList();

           return View(facilityinfo);
       }

        public ActionResult PartyHall()
       {
           var db = new HolidayPlanner.Models.InfoData();
           List<Hotel> facilityinfo = (from f in db.Facilities
                                       join h in db.Hotels
                                       on f.HotelId equals h.HotelId
                                       where f.FacilitiesType == "Party Hall" && h.CityId == "MU"
                                       select h).ToList();

           return View(facilityinfo);
       }

           public ActionResult Bar()
           {
               var db = new HolidayPlanner.Models.InfoData();
               List<Hotel> facilityinfo = (from f in db.Facilities
                                           join h in db.Hotels
                                           on f.HotelId equals h.HotelId
                                           where f.FacilitiesType == "Bar" && h.CityId == "MU"
                                           select h).ToList();

               return View(facilityinfo);
           }

}
}