using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Alumno
    {
        public static ModelLayer.Result GetAll()
        {
            ModelLayer.Result result = new ModelLayer.Result();

            try
            {
                using (DataLayer.ControlEscolarEntities context = new DataLayer.ControlEscolarEntities())
                {
                    
                    var query = context.AlumnoGetAll().ToList();
                     
                    if(query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            ModelLayer.Alumno alumno = new ModelLayer.Alumno();
                            alumno.IdAlumno = item.IdAlumno;
                            alumno.NombreAlumno = item.NombreAlumno;
                            alumno.ApellidoPaterno = item.ApellidoPaterno;
                            alumno.ApellidoMaterno = item.ApellidoMaterno;
                            result.Objects.Add(alumno);

                           

                        }
                        result.Correct = true;
                    }                   
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se encontraron registros";
                        }
                    
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
            }

            return result;
        }
        public static ModelLayer.Result Add(ModelLayer.Alumno alumno)
        {
            ModelLayer.Result result = new ModelLayer.Result();

            try
            {
                using (DataLayer.ControlEscolarEntities context = new DataLayer.ControlEscolarEntities())
                {
                    var query = context.AlumnoAdd(alumno.NombreAlumno, alumno.ApellidoPaterno, alumno.ApellidoMaterno);
                    if(query>0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct=false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
            }

            return result;
        }
        public static ModelLayer.Result GetById(int idAlumno)
        {
            ModelLayer.Result result = new ModelLayer.Result();

            try
            {
                using (DataLayer.ControlEscolarEntities context = new DataLayer.ControlEscolarEntities())
                {
                    var query = context.AlumnoGetById(idAlumno).FirstOrDefault();

                    if (query != null)
                    {
                        ModelLayer.Alumno alumno = new ModelLayer.Alumno();
                        alumno.IdAlumno = query.IdAlumno;
                        alumno.NombreAlumno = query.NombreAlumno;
                        alumno.ApellidoPaterno = query.ApellidoPaterno;
                        alumno.ApellidoMaterno = query.ApellidoMaterno;
                        result.Object = alumno;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro el registro";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
            }

            return result;
        }

        public static ModelLayer.Result Update(ModelLayer.Alumno alumno)
        {
            ModelLayer.Result result = new ModelLayer.Result();

            try
            {
                using (DataLayer.ControlEscolarEntities context = new DataLayer.ControlEscolarEntities())
                {
                    var query = context.AlumnoUpdate(alumno.IdAlumno, alumno.NombreAlumno, alumno.ApellidoPaterno, alumno.ApellidoMaterno);
                    if(query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error al actualizar el alumno " + alumno.NombreAlumno;
                    }                    
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
            }

            return result;
        }

        public static ModelLayer.Result Delete(int idAlumno)
        {
            ModelLayer.Result result = new ModelLayer.Result();

            try
            {
                using (DataLayer.ControlEscolarEntities context = new DataLayer.ControlEscolarEntities())
                {
                    var query = context.AlumnoDelete(idAlumno);


                        if (query > 0)
                        {
                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrio un error al eliminar el registro";
                        }
                    
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
            }

            return result;
        }


        public static ModelLayer.Result Login(ModelLayer.Alumno alumno)
        {
            ModelLayer.Result result = new ModelLayer.Result();

            try
            {
                using (DataLayer.ControlEscolarEntities context = new DataLayer.ControlEscolarEntities())
                {
                    var query = context.AlumnoLogin(alumno.NombreAlumno, alumno.ApellidoPaterno).ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            alumno = new ModelLayer.Alumno();
                            alumno.IdAlumno = item.IdAlumno;
                            alumno.NombreAlumno = item.NombreAlumno;
                            alumno.ApellidoPaterno = item.ApellidoPaterno;
                            alumno.ApellidoMaterno = item.ApellidoMaterno;
                            result.Object = alumno;

                            result.Correct = true;

                        }
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
            }

            return result;
        }


        public static ModelLayer.Result SumaCosto(int idAlumno)
        {
            ModelLayer.Result result = new ModelLayer.Result();

            try
            {
                using (DataLayer.ControlEscolarEntities context = new DataLayer.ControlEscolarEntities())
                {
                    var query = context.SumaCostoMaterias(idAlumno).FirstOrDefault();

                    if (query != null)
                    {
                        var costo = query.Value;
                        result.Object= costo;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro el registro";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
            }

            return result;
        }
    }
}
