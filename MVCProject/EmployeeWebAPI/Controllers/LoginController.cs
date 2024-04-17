using EmployeeWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace EmployeeWebAPI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user, string ReturnUrl)
        {

            Console.WriteLine(user.UName + " " + user.Password);
            if (ValidateUserInDB(user))
            {
                FormsAuthentication.SetAuthCookie(user.UName, false);

                if (ReturnUrl != null)
                {
                    return Redirect(ReturnUrl);
                }
                else
                {
                    //Take user to landing page
                    return Redirect("/Home/Index");
                }
            }
            else
            {
                ViewBag.message = "Login Failed!!";
                return View("Login", user);
            }
        }

        private bool ValidateUserInDB(User user)
        {
            return (user.UName == "admin" && user.Password == "admin123");
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Login/Login");
        }


    }
}   