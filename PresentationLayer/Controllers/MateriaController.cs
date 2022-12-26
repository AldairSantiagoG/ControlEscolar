using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia
        public ActionResult Index()
        {
            bool redict = Convert.ToBoolean(Session["Alumno"]);
            if (redict)
            {

                return View();
            }
            return RedirectToAction("Login", "Login");
            
        }
        public ActionResult Form(int? idMateria)
        {
            bool redict = Convert.ToBoolean(Session["Alumno"]);
            if (redict)
            {
                if (idMateria == null)
                    idMateria = 0;
                ViewBag.IdMateria = idMateria;
                return View();
            }
            return RedirectToAction("Login", "Login");
            
        }
    }
}