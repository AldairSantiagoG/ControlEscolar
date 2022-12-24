using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AlumnoMateria
    {
        public static ModelLayer.Result MateriasGetNoAsignadas(int idAlumno)
        {
            ModelLayer.Result result = new ModelLayer.Result();

            try
            {
                using (DataLayer.ControlEscolarEntities context = new DataLayer.ControlEscolarEntities())
                {
                    var getNoAsignadas = context.MateriasGetNoAsignadas(idAlumno);
                    //var getNoAsignadas = context.mate

                    result.Objects = new List<object>();

                    if (getNoAsignadas != null)
                    {
                        foreach (var obj in getNoAsignadas)
                        {
                            ModelLayer.AlumnoMateria alumnoMateria = new ModelLayer.AlumnoMateria();

                            alumnoMateria.Materia = new ModelLayer.Materia();
                            alumnoMateria.Materia.IdMateria = obj.IdMateria;
                            alumnoMateria.Materia.NombreMateria = obj.NombreMateria;
                            alumnoMateria.Materia.Costo = obj.Costo.Value;

                            result.Objects.Add(alumnoMateria);
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

        public static ModelLayer.Result MateriasGetAsignadas(int idAlumno)
        {
            ModelLayer.Result result = new ModelLayer.Result();

            try
            {
                using (DataLayer.ControlEscolarEntities context = new DataLayer.ControlEscolarEntities())
                {
                    var getAsignadas = context.MateriasGetAsignadas(idAlumno).ToList();

                    result.Objects = new List<object>();

                    if (getAsignadas.Count > 0)
                    {
                        foreach (var obj in getAsignadas)
                        {
                            ModelLayer.AlumnoMateria alumnoMateria = new ModelLayer.AlumnoMateria();
                            alumnoMateria.IdAlumnoMateria = obj.IdAlumnoMateria;

                            alumnoMateria.Materia = new ModelLayer.Materia();
                            alumnoMateria.Materia.IdMateria = obj.IdMateria.Value;
                            alumnoMateria.Materia.NombreMateria = obj.NombreMateria;
                            alumnoMateria.Materia.Costo = obj.Costo.Value;

                            result.Objects.Add(alumnoMateria);
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
        public static ModelLayer.Result Add(ModelLayer.AlumnoMateria alumnoMateria)
        {
            ModelLayer.Result result = new ModelLayer.Result();

            try
            {
                using (DataLayer.ControlEscolarEntities context = new DataLayer.ControlEscolarEntities())
                {
                    var add = context.AlumnoMateriasAdd(alumnoMateria.Alumno.IdAlumno, alumnoMateria.Materia.IdMateria);

                    if (add > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se asigno la materia al alumno";
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

        public static ModelLayer.Result Delete(int idAlumnoMateria)
        {
            ModelLayer.Result result = new ModelLayer.Result();

            try
            {
                using (DataLayer.ControlEscolarEntities context = new DataLayer.ControlEscolarEntities())
                {
                    var delete = context.AlumnoMateriaDelete(idAlumnoMateria);

                    if (delete > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
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
