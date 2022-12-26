using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    public class AlumnoMateriaController : Controller
    {
        // GET: AlumnoMateria
        public ActionResult Index()
        {
            bool redict = Convert.ToBoolean(Session["Alumno"]);
            if (redict)
            {
                return View();
            }
            return RedirectToAction("Login", "Login");
           
        }

        public ActionResult Asignar(int? idAlumno)
        {
            bool redict = Convert.ToBoolean(Session["Alumno"]);
            if (redict)
            {
                ViewBag.IdAlumno = idAlumno;
                return View();
            }
            return RedirectToAction("Login", "Login");
            
        }
    }
}