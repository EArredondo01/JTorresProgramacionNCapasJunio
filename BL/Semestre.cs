using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Semestre
    {
        public static ML.Result GetAll() //Lista semestre
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JTorresProgramacionNCapasJunioEntities context = new DL_EF.JTorresProgramacionNCapasJunioEntities())
                {
                    var listSemestres = (from semestreDB in context.Semestres
                                         select semestreDB).ToList();

                    if (listSemestres.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var item in listSemestres)
                        {
                            ML.Semestre semestre = new ML.Semestre();
                            semestre.IdSemestre = item.IdSemestre;
                            semestre.Nombre = item.Nombre;

                            result.Objects.Add(semestre);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registro";
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
