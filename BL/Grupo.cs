﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Grupo
    {
        public static ML.Result GetByIdPlantel(int IdPlantel)
        {

            ML.Result result = new ML.Result(); //instancia-objeto

            try
            {
                using (DL_EF.JTorresProgramacionNCapasJunioEntities context = new DL_EF.JTorresProgramacionNCapasJunioEntities())
                {

                    //select ____ from Materia //pluralize
                    var resultQuery = (from grupoDB in context.Grupoes
                                       where grupoDB.IdPlantel == IdPlantel
                                       select new
                                       {
                                           grupoDB.IdGrupo,
                                           grupoDB.Nombre,
                                       }).ToList();


                    if (resultQuery.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var grupoDB in resultQuery)
                        {
                            ML.Grupo grupo = new ML.Grupo();
                            grupo.IdGrupo = grupoDB.IdGrupo;
                            grupo.Nombre = grupoDB.Nombre;
                            result.Objects.Add(grupo);
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
