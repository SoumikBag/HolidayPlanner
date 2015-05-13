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
        //started by sandy
        public ActionResult Index()
        {
            Country c = new Country();
            c.CountryList = new SelectList(Ccon.GetCountryList(), "CountryId", "CountryName");
            return View(c);
        }
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



        public ActionResult Info(string clickinfo, int Hid)
        {

            var db = new HolidayPlanner.Models.InfoData();
 

            switch(clickinfo)
            {
                case "overview":
                    {
                        var Odetail = (from p in db.Hotels
                                       where p.HotelId == Hid
                                       select p.HotelDetails).SingleOrDefault();
                        return View("Overview", Odetail);
                    }

                case "room":
                    {
                        var roominfo = from r in db.Rooms
                                       where r.HotelId == Hid
                                       select new InfoViewModel { Rate = r.Rate, RoomDetails = r.RoomDetails, RoomCapacity = r.RoomCapacity };

                        return View("RoomInfo", roominfo);
                    }

            //    case "facility":
            //    {
            //        var facilityinfo = from f in db.Facilities
            //                           join h0 in db.Hotels
            //                           on f.FId equals h0.FId into f0

            //                            from h1 in db.Hotels
                                                                                                                        
            //                           select new InfoViewModel { FacilityType = f.FacilitiesType, FacilityDetails = f.FacilitiesDetails, FoodDetails = h1.FoodDetails, Policies = h1.HotelPolices};

            //        return View("FacilityInfo", facilityinfo);
            //    }

                case "review":
                    {
                        var review = from r in db.Reviews
                                     join h in db.Hotels
                                     on r.HotelId equals h.HotelId
                                     select new InfoViewModel { ReviewDetails = r.ReviewDetails, Rating = r.Rating };

                        return View("ReviewInfo", review);
                    }

            }

            return View();

        }



        public ActionResult First()
        {
            var db = new HolidayPlanner.Models.InfoData();
            List<Hotel> abc = (from hot in db.Hotels
                               where hot.HTypeId=="LU"
                               select hot).ToList();
            return View(abc);
        }

        public ActionResult BeachFacing()
        {
            return View();
        }
                       
        public ActionResult Romantic()
        {
            return View();
        }

        public ActionResult ValleyView()
        {
            return View();
        }
            
        public ActionResult Adventure()
        {
            return View();
        }

        public ActionResult RiverSide()
        {
            return View();
        }

        public ActionResult PureVeg()
        {
            return View();
        }

        public ActionResult PetFriendly()
        {
            return View();
        }

        public ActionResult Beaches()
        {
            return View();
        }

        public ActionResult HillStations()
        {
            return View();
        }

        public ActionResult Farms()
        {
            return View();
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
        public ActionResult Search()
        {
            return View("First");
        }
        //ended by sandy


            

        public ActionResult Tents()
        {
            return View();
        }

        public ActionResult Pune()
        {
            return View();
        }

        public ActionResult Banglore()
        {
            return View();
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
        public ActionResult bookingform(int id)
        {
            
            return RedirectToAction("Id",id);
        }

        public ActionResult Id(int id)
        {
            TempData["Id"] = id;
            return View("bookingform");
        }
        

}
}