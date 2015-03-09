using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Xamarin.Data.Models;

namespace Xamarin.Data.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Username,Password")] XamarinLogin user)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index", new { success = false });

            Boolean validationResult = (user.Username == "ambassador@xamarin.com") && (user.Password == "Sup4Dup4S4f3P4$$w0rd");
            if (validationResult)
            {
                FormsAuthentication.Initialize();
                FormsAuthentication.SetAuthCookie(user.Username, false);
                return RedirectToAction("Index", "Home");
            }
            else
                return RedirectToAction("Index","Login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}