using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiceLayer.Controllers
{
    public class AlumnoMateriaController : ApiController
    {
        [HttpGet]
        [Route("AlumnoMateria/GetAll")]
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

        // GET: api/AlumnoMateria/5
        [HttpGet]
        [Route("AlumnoMateria/MateriasAsignadas/{id}")]
        public IHttpActionResult Get(int id)
        {
            ModelLayer.Result result = BusinessLayer.AlumnoMateria.MateriasGetAsignadas(id);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet]
        [Route("AlumnoMateria/Alumno/{id}")]
        public IHttpActionResult GetAlumno(int id)
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
    }
}
