using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        
        public ActionResult Index()
        {
            bool redict = Convert.ToBoolean(Session["Alumno"]);
            if (redict)
            {
               return View();
            }
            return RedirectToAction("Login", "Login");
           
        }
        public ActionResult Form(int? idAlumno)
        {

            bool redict = Convert.ToBoolean(Session["Alumno"]);
            if (redict)
            {
                if (idAlumno == null)
                    idAlumno = 0;
                ViewBag.IdAlumno = idAlumno;
                return View();
            }
            return RedirectToAction("Login", "Login");
           
        }
        
        //public ActionResult Delete(int idAlumno)
        //{
        //    ViewBag.IdAlumno = idAlumno;
        //    return View();
        //}
    }
}