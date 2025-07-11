using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ImagenMateria
    {
        public static ML.Result Add(ML.Materia materia)
        {

            ML.Result result = new ML.Result(); //instancia-objeto

            try
            {
                using (DL_EF.JTorresProgramacionNCapasJunioEntities context = new DL_EF.JTorresProgramacionNCapasJunioEntities())
                {
                    DL_EF.ImagenMateria imagenMateriaDB = new DL_EF.ImagenMateria();

                    imagenMateriaDB.IdMateria = materia.IdMateria;
                    imagenMateriaDB.Nombre = materia.ImagenMateria.Nombre;
                    imagenMateriaDB.Descripcion = materia.ImagenMateria.Descripcion;
                    imagenMateriaDB.Imagen = materia.ImagenMateria.Imagen;

                    context.ImagenMaterias.Add(imagenMateriaDB);
                    int FilasAfectadas = context.SaveChanges();


                    if (FilasAfectadas > 0)
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
                result.ErrorMessage = ex.Message;
            }

            return result;
        }


        public static ML.Result GetByIdMateria(int IdMateria)
        {

            ML.Result result = new ML.Result(); //instancia-objeto

            try
            {
                using (DL_EF.JTorresProgramacionNCapasJunioEntities context = new DL_EF.JTorresProgramacionNCapasJunioEntities())
                {

                    //select ____ from Materia //pluralize
                    var resultQuery = (from imagenMateriaDB in context.ImagenMaterias
                                       where imagenMateriaDB.IdMateria == IdMateria
                                       select imagenMateriaDB).ToList();


                    if (resultQuery.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach(DL_EF.ImagenMateria obj in resultQuery)
                        {
                            ML.ImagenMateria imagenMateria = new ML.ImagenMateria();
                            imagenMateria.IdImagenMateria = obj.IdImagenMateria.ToString();
                            imagenMateria.Nombre = obj.Nombre;
                            imagenMateria.Imagen = obj.Imagen;
                            imagenMateria.Descripcion = obj.Descripcion;

                            result.Objects.Add(imagenMateria);

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
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

    }
}
