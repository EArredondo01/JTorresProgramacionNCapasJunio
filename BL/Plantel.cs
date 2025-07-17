using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Plantel
    {
        public static ML.Result GetAll()
        {

            ML.Result result = new ML.Result(); //instancia-objeto

            try
            {
                using (DL_EF.JTorresProgramacionNCapasJunioEntities context = new DL_EF.JTorresProgramacionNCapasJunioEntities())
                {

                    //select ____ from Materia //pluralize
                    var resultQuery = (from plantelDB in context.Plantels
                                       select new
                                       {
                                           plantelDB.IdPlantel,
                                           plantelDB.Nombre,
                                       }).ToList();


                    if (resultQuery.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var plantelDB in resultQuery)
                        {
                            ML.Plantel plantel = new ML.Plantel();
                            plantel.IdPlantel= plantelDB.IdPlantel;
                            plantel.Nombre = plantelDB.Nombre;
                            result.Objects.Add(plantel);
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
