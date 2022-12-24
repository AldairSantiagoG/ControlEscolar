﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiceLayer.Controllers
{
    public class MateriaController : ApiController
    {
        // GET: Materia
        [System.Web.Http.HttpGet]
        [Route("Materia/GetAll")]
        public IHttpActionResult GetAll()
        {
            ModelLayer.Result result = BusinessLayer.Materia.GetAll();
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: Materia/Details/5
        [System.Web.Http.HttpPost]
        [Route("Materia/Add")]

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

        [System.Web.Http.HttpGet]
        [Route("Materia/GetById/{id}")]
        public IHttpActionResult GetById(int id)
        {
            ModelLayer.Result result = BusinessLayer.Materia.GetById(id);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [System.Web.Http.HttpPut]
        [Route("Materia/Update/{id}")]
        public IHttpActionResult Update(int id, [FromBody] ModelLayer.Materia materia)
        {
            ModelLayer.Result result = BusinessLayer.Materia.Update(materia);
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
        [Route("Materia/Delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            ModelLayer.Result result = BusinessLayer.Materia.Delete(id);
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
