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
        
        public ActionResult Index()
        {
            return View();
        }

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




        //public int GetLastInsertedId()
        //{
        //    return Context.
        //}


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
        
                    //using (var db1 = new HolidayPlanner.Models.RoleContext())
                    //{
                    //    var role = db1.Roles.Create();
                    //    {
                    //        role.RoleId = 1;
                    //        role.RoleName = "Client";
                    //        //db1.Roles.Add(role);
                    //        //db1.SaveChanges();
                    //    }
                    //}



                    
                    using (var db2 = new HolidayPlanner.Models.UserRolecontext())
                    {
                        var userrole = db2.UserInRoles.Create();
                        //var role = db1.Roles.Create();
                        {
                            //var newUser1 = db.Users.Create();
                            //int lastUserID = db.Users.Max(item => item.UserId); //added by Sandy for ID Auto-Increment 
                            //user.UserId = lastUserID + 1;
                            //newUser1.UserId = user.UserId;




                            //var user1 = new User { UserId = test, roles = new List<Role>()};
                            //var role = new Role { RoleId = 1 };

                            //db2.Users.Attach(user);
                            //db2.Roles.Attach(role);

                            //user..Add(role);

                            //db2.SaveChanges();





                            //userrole.UserId = test;

                            //userrole.RoleId = 1;
                            //db2.UserInRoles.Add(userrole);
                            //db2.SaveChanges();
                            //role.RoleId = 1;
                            //role.RoleName = "Client";
                            //db1.Roles.Add(role);

                            //db1.SaveChanges();

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

        [HttpGet]
        public ActionResult First()
        {

            //var db = new HolidayPlanner.Models.InfoData();
                       
            //var hotelinfo = db.Hotels.Where(h=>h.HotelId==11);

            //var model = (from p in db.Hotels
            //             where p.HotelId == 11
            //             select p).ToList();

            return View();

            
        }

       

    }
}