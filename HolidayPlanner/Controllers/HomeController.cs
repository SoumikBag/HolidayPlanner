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
        
        
        public ActionResult Info()
        {

            var db = new HolidayPlanner.Models.InfoData();

            var hotelinfo = db.Hotels.Where(h => h.HotelId == 11);

            var roominfo = (from r in db.Rooms
                            join h in db.Hotels
                                on r.RoomId equals h.RoomId
                            select new { r.Rate, r.RoomDetails, r.RoomCapacity });

            var model = (from p in db.Hotels
                         where p.HotelId == 11
                         select p).ToList();
                       
            return View(hotelinfo);

            
        }
    
        public ActionResult First()
        {
            return View();
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

        //    return View("Index",c);
            
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


    }
}