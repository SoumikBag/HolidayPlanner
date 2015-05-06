﻿using HolidayPlanner.Models;
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
                using (var db = new HolidayPlanner.Models.Register1())
                {
                    
                    var newUser = db.Users.Create();
                    int lastUserId = db.Users.Max(item => item.UserId); //added by Sandy for ID Auto-Increment 
                    user.UserId = lastUserId + 1; 
                    newUser.UserId = user.UserId;
                    
                    newUser.UserName = user.UserName;
                    newUser.EmailId = user.EmailId;
                    newUser.ContactNo = user.ContactNo;
                   
                    newUser.Password = user.Password;
                   

                    db.Users.Add(newUser);
                    db.SaveChanges();
                  
                  
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

        public ActionResult Info()
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