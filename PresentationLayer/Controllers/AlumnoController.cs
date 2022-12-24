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
            return View();
        }
        public ActionResult Form(int? idAlumno)
        {
            if(idAlumno==null)
                idAlumno = 0;
            ViewBag.IdAlumno = idAlumno;
            return View();
        }
        
        public ActionResult Delete(int idAlumno)
        {
            ViewBag.IdAlumno = idAlumno;
            return View();
        }
    }
}