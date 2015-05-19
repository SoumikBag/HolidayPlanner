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

                                           //from h in db.Hotels

                                           select new InfoViewModel { FacilityType = f.FacilitiesType, FoodDetails = h.FoodDetails, Policies = h.HotelPolices };

                        return View("FacilityInfo", facilityinfo);
                    }

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
        public ActionResult Search()
        {
            return View("First");
        }
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