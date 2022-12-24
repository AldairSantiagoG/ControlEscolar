using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Materia
    {
        public static ModelLayer.Result GetAll()
        {
            ModelLayer.Result result = new ModelLayer.Result();

            try
            {
                using (DataLayer.ControlEscolarEntities context = new DataLayer.ControlEscolarEntities())
                {
                    var materiaGetAll = context.MateriaGetAll();

                    result.Objects = new List<object>();

                    if (materiaGetAll != null)
                    {
                        foreach (var obj in materiaGetAll)
                        {
                            ModelLayer.Materia materia = new ModelLayer.Materia();

                            materia.IdMateria = obj.IdMateria;
                            materia.NombreMateria = obj.NombreMateria;
                            materia.Costo = obj.Costo.Value;

                            result.Objects.Add(materia);
                        }
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
        public static ModelLayer.Result Add(ModelLayer.Materia materia)
        {
            ModelLayer.Result result = new ModelLayer.Result();

            try
            {
                using (DataLayer.ControlEscolarEntities context = new DataLayer.ControlEscolarEntities())
                {
                    var materiaAdd = context.MateriaAdd(materia.NombreMateria, materia.Costo);

                    if (materiaAdd > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se inserto la materia";
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
        public static ModelLayer.Result GetById(int idMateria)
        {
            ModelLayer.Result result = new ModelLayer.Result();

            try
            {
                using (DataLayer.ControlEscolarEntities context = new DataLayer.ControlEscolarEntities())
                {
                    var materiaGetById = context.MateriaGetById(idMateria).FirstOrDefault();

                    result.Objects = new List<object>();

                    if (materiaGetById != null)
                    {
                        ModelLayer.Materia materia = new ModelLayer.Materia();

                        materia.IdMateria = materiaGetById.IdMateria;
                        materia.NombreMateria = materiaGetById.NombreMateria;
                        materia.Costo = materiaGetById.Costo.Value;

                        result.Object = materia;

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

        public static ModelLayer.Result Update(ModelLayer.Materia materia)
        {
            ModelLayer.Result result = new ModelLayer.Result();

            try
            {
                using (DataLayer.ControlEscolarEntities context = new DataLayer.ControlEscolarEntities())
                {
                    var materiaAdd = context.MateriaUpdate(materia.IdMateria, materia.NombreMateria, materia.Costo);

                    if (materiaAdd > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizo la materia";
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

        public static ModelLayer.Result Delete(int idMateria)
        {
            ModelLayer.Result result = new ModelLayer.Result();

            try
            {
                using (DataLayer.ControlEscolarEntities context = new DataLayer.ControlEscolarEntities())
                {
                    var materiaAdd = context.MateriaDelete(idMateria);

                    if (materiaAdd > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se elimino la materia";
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
