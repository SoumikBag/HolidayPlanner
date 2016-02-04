using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HolidayPlanner.Controllers
{
    public class ManageController : Controller
    {
        // GET: Manage
        
        [HttpGet]
        public ActionResult ChangePassword(string name)
        {
            var name1 = name;
            name1 = Regex.Replace(name1, @"@gmail.com", String.Empty);
            TempData["name"] = name1;
            var db = new HolidayPlanner.Models.DataContext();
            var pass = (from p in db.Users
                        where p.UserName == name1
                        select p.Password).SingleOrDefault();
            ViewBag.password = pass;
            return View();
        }

        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(HolidayPlanner.Models.ManageViewModels.ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var ab = TempData.Peek("name");
            var db = new HolidayPlanner.Models.DataContext();
            var update = (from p in db.Users
                          where p.UserName == ab
                        select p).SingleOrDefault();
            update.Password = model.ConfirmPassword;
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}