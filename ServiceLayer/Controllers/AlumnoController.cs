using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiceLayer.Controllers
{
    public class AlumnoController : ApiController
    {
        [System.Web.Http.HttpGet]
        [Route("Alumno/GetAll")]
        public IHttpActionResult GetAll()
        {
            ModelLayer.Result result = BusinessLayer.Alumno.GetAll();
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: Alumno/Details/5
        [System.Web.Http.HttpPost]
        [Route("Alumno/Add")]

        public IHttpActionResult Add([FromBody] ModelLayer.Alumno alumno)
        {
            ModelLayer.Result result = BusinessLayer.Alumno.Add(alumno);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [System.Web.Http.HttpGet]
        [Route("Alumno/GetById/{id}")]
        public IHttpActionResult GetById(int id)
        {
            ModelLayer.Result result = BusinessLayer.Alumno.GetById(id);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [System.Web.Http.HttpPost]
        [Route("Alumno/Update/")]
        public IHttpActionResult Update(ModelLayer.Alumno alumno)
        {
            ModelLayer.Result result = BusinessLayer.Alumno.Update(alumno);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
        [System.Web.Http.HttpDelete]
        [Route("Alumno/Delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            ModelLayer.Result result = BusinessLayer.Alumno.Delete(id);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [System.Web.Http.HttpGet]
        [Route("Alumno/Costo/{id}")]
        public IHttpActionResult Costo(int idAlumno)
        {
            ModelLayer.Result result = BusinessLayer.Alumno.SumaCosto(idAlumno);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }


        [System.Web.Http.HttpGet]
        [Route("Alumno/Login")]
        public IHttpActionResult Login([FromBody] ModelLayer.Alumno alumno)
        {
            ModelLayer.Result result = BusinessLayer.Alumno.Login(alumno);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
