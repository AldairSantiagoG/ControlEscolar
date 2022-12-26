using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index(bool? Autenticar)
        {
            if(Autenticar.HasValue == null)
            {
                Autenticar=false;
            }
            if(Autenticar.HasValue)
            {
                Session["Alumno"] = true;
                return View();
            }

            return RedirectToAction("Login","Login");
        }

        public ActionResult About()
        {
            bool redict = Convert.ToBoolean( Session["Alumno"]);
            if (redict)
            {
                ViewBag.Message = "Your application description page.";

                return View();
            }
            return RedirectToAction("Login", "Login");
        }

        public ActionResult Contact()
        {
            bool redict = Convert.ToBoolean(Session["Alumno"]);
            if (redict)
            {
                ViewBag.Message = "Your contact page.";

                return View();
            }
            return RedirectToAction("Login", "Login");
            
        }
    }
}