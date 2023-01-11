using BusinessLayer;
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
        [HttpPost]
        [Route("AlumnoMateria/Add/")]
        public IHttpActionResult Add([FromBody] ModelLayer.AlumnoMateria alumnoMateria)
        {
            ModelLayer.Result result = BusinessLayer.AlumnoMateria.Add(alumnoMateria);
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
        [Route("AlumnoMateria/Delete/{id}")]
        public IHttpActionResult Delete(int idAlumnoMateria)
        {
            ModelLayer.Result result = BusinessLayer.AlumnoMateria.Delete(idAlumnoMateria);
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
        public IHttpActionResult MateriasAsignadas(int id)
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
        [Route("AlumnoMateria/MateriasNoAsignadas/{id}")]
        public IHttpActionResult MateriasNoAsignadas(int id)
        {
            ModelLayer.Result result = BusinessLayer.AlumnoMateria.MateriasGetNoAsignadas(id);
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
        [Route("AlumnoMateria/Ejemplo/")]
        public IHttpActionResult Ejemplo()
        {
            List<ModelLayer.Alumno> alumnoM = new List<ModelLayer.Alumno>();

            ModelLayer.Result result = BusinessLayer.AlumnoMateria.Ejemplo(alumnoM);
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
