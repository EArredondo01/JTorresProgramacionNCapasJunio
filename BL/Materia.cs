using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Odbc;//EXCEL
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ML;
using DL_EF;

namespace BL
{
    public class Materia
    {

        //GetAll
        //GetBy___Id,Nombre, 
        public static ML.Result GetAll()
        {

            ML.Result result = new ML.Result(); //instancia-objeto

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Connnection.Get()))
                {

                    string Query = "MateriaGetAll";

                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = Query;
                    cmd.Connection = context;

                    DataTable tableMateria = new DataTable();

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    context.Open();
                    adapter.Fill(tableMateria);


                    if (tableMateria.Rows.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (DataRow row in tableMateria.Rows)
                        {
                            ML.Materia materia = new ML.Materia();

                            materia.IdMateria = Convert.ToInt32(row[0].ToString());
                            materia.Nombre = row[1].ToString();
                            materia.Creditos = Convert.ToByte(row[2].ToString());
                            materia.Costo = Convert.ToDecimal(row[3].ToString());

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
                result.ErrorMessage = ex.Message;

            }

            return result;
        }



        public static ML.Result GetById(int IdMateria)
        {

            ML.Result result = new ML.Result(); //instancia-objeto

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Connnection.Get()))
                {

                    string Query = "MateriaGetById";

                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = Query;
                    cmd.Connection = context;

                    cmd.Parameters.AddWithValue("@IdMateria", IdMateria);

                    DataTable tableMateria = new DataTable();

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    context.Open();
                    adapter.Fill(tableMateria);


                    if (tableMateria.Rows.Count > 0)
                    {
                        result.Objects = new List<object>();


                        ML.Materia materia = new ML.Materia();

                        DataRow row = tableMateria.Rows[0]; //obten el primer registro de la tabla

                        materia.IdMateria = Convert.ToInt32(row[0]);
                        materia.Nombre = row[1].ToString();
                        materia.Creditos = Convert.ToByte(row[2].ToString());
                        materia.Costo = Convert.ToDecimal(row[3].ToString());

                        materia.Semestre = new ML.Semestre();
                        materia.Semestre.IdSemestre = Convert.ToByte(row[4]);

                        result.Object = materia; //Boxing       //unboxing 

                        object x = "Jesus";
                        object y = true;
                        object z = 10.2;

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

        public static ML.Result Add(ML.Materia materia)
        {
            //ORACLE, MYSQL, OLEDB, SQL,  

            ML.Result result = new ML.Result(); //instancia-objeto

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Connnection.Get()))
                {

                    string Query = "INSERT INTO Materia (Nombre, Creditos, Costo) VALUES (@Nombre, @Creditos, @Costo)";

                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = Query;
                    cmd.Connection = context;

                    cmd.Parameters.AddWithValue("@Nombre", materia.Nombre);
                    cmd.Parameters.AddWithValue("@Creditos", materia.Creditos);
                    cmd.Parameters.AddWithValue("@Costo", materia.Costo);
                    cmd.Parameters.AddWithValue("@IdSemestre", materia.Semestre.IdSemestre); //GET

                    context.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();

                    if (RowsAffected > 0)
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

        public static ML.Result AddSP(ML.Materia materia)
        {
            //ORACLE, MYSQL, OLEDB, SQL,  

            ML.Result result = new ML.Result(); //instancia-objeto

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Connnection.Get()))
                {

                    string Query = "INSERT INTO Materia (Nombre, Creditos, Costo) VALUES (@Nombre, @Creditos, @Costo)";

                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = Query;
                    cmd.Connection = context;

                    cmd.Parameters.AddWithValue("@Nombre", materia.Nombre);
                    cmd.Parameters.AddWithValue("@Creditos", materia.Creditos);
                    cmd.Parameters.AddWithValue("@Costo", materia.Costo);

                    context.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();

                    if (RowsAffected > 0)
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


        public static ML.Result AddEF(ML.Materia materia)
        {
            //ORACLE, MYSQL, OLEDB, SQL,  

            ML.Result result = new ML.Result(); //instancia-objeto
            try
            { //LINQ
                using (DL_EF.JTorresProgramacionNCapasJunioEntities context = new DL_EF.JTorresProgramacionNCapasJunioEntities())
                {
                    var resultQuery = context.MateriaAdd(materia.Nombre, materia.Creditos, materia.Costo);

                    if (resultQuery > 0)
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

        public static ML.Result GetByIdEF(int IdMateria)
        {

            ML.Result result = new ML.Result(); //instancia-objeto

            try
            {
                using (DL_EF.JTorresProgramacionNCapasJunioEntities context = new DL_EF.JTorresProgramacionNCapasJunioEntities())
                {
                    var resultQuery = context.MateriaGetById(IdMateria).FirstOrDefault();

                    if (resultQuery != null)
                    {
                        ML.Materia materia = new ML.Materia();
                        materia.IdMateria = resultQuery.IdMateria;
                        materia.Nombre = resultQuery.Nombre;
                        materia.Creditos = resultQuery.Creditos.Value;

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
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result GetAllEF()
        {

            ML.Result result = new ML.Result(); //instancia-objeto

            try
            {
                using (DL_EF.JTorresProgramacionNCapasJunioEntities context = new DL_EF.JTorresProgramacionNCapasJunioEntities())
                {
                    List<DL_EF.MateriaGetAll_Result> resultQuery = context.MateriaGetAll().ToList();


                    if (resultQuery.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (MateriaGetAll_Result materiaDB in resultQuery)
                        {
                            ML.Materia materia = new ML.Materia();
                            materia.IdMateria = materiaDB.IdMateria;
                            //materia.Nombre = materiaDB.MateriaNombre;
                            materia.Creditos = materiaDB.Creditos.Value;
                            materia.Costo = materiaDB.Costo.Value;
                            materia.Semestre = new ML.Semestre();
                            //materia.Semestre.Nombre = materiaDB.SemestreNombre;

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
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result GetAllLinq()
        {

            ML.Result result = new ML.Result(); //instancia-objeto

            try
            {
                using (DL_EF.JTorresProgramacionNCapasJunioEntities context = new DL_EF.JTorresProgramacionNCapasJunioEntities())
                {

                    //select ____ from Materia //pluralize
                    var resultQuery = (from materiaDB in context.Materias
                                       join semestreDB in context.Semestres on materiaDB.IdSemestre equals semestreDB.IdSemestre
                                       select new
                                       {
                                           materiaDB.IdMateria,
                                           materiaDB.Nombre,
                                           materiaDB.Creditos,
                                           materiaDB.Costo,
                                       }).ToList();


                    if (resultQuery.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var materiaDB in resultQuery)
                        {
                            ML.Materia materia = new ML.Materia();
                            materia.IdMateria = materiaDB.IdMateria;
                            materia.Nombre = materiaDB.Nombre;
                            materia.Creditos = materiaDB.Creditos.Value;
                            materia.Costo = materiaDB.Costo.Value;
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
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result GetByIdLinq(int IdMateria)
        {

            ML.Result result = new ML.Result(); //instancia-objeto

            try
            {
                using (DL_EF.JTorresProgramacionNCapasJunioEntities context = new DL_EF.JTorresProgramacionNCapasJunioEntities())
                {

                    //select ____ from Materia //pluralize
                    var resultQuery = (from materiaDB in context.Materias                                   
                                       where materiaDB.IdMateria == IdMateria
                                       select materiaDB).FirstOrDefault();//select IdMateria, Nombre from Materia


                    if (resultQuery != null)
                    {
                        result.Objects = new List<object>();


                        ML.Materia materia = new ML.Materia();
                        //materia.IdMateria = resultQuery.IdMateria;
                        materia.Nombre = resultQuery.Nombre;
                        materia.Creditos = resultQuery.Creditos;
                        materia.Costo = resultQuery.Costo.Value;

                        materia.Semestre = new ML.Semestre();
                        materia.Semestre.IdSemestre = resultQuery.IdSemestre.Value;
                        
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
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result AddLinq(ML.Materia materia)
        {

            ML.Result result = new ML.Result(); //instancia-objeto

            try
            {
                using (DL_EF.JTorresProgramacionNCapasJunioEntities context = new DL_EF.JTorresProgramacionNCapasJunioEntities())
                {
                    DL_EF.Materia materiaDB = new DL_EF.Materia();

                    materiaDB.Nombre = materia.Nombre;
                    materiaDB.Creditos= materia.Creditos;
                    materiaDB.Costo = materia.Costo;
                    

                    context.Materias.Add(materiaDB);
                    int FilasAfectadas =  context.SaveChanges();
                    

                    if (FilasAfectadas > 0 )
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

        public static ML.Result UpdateLinq(ML.Materia materia)
        {

            ML.Result result = new ML.Result(); //instancia-objeto

            try
            {
                using (DL_EF.JTorresProgramacionNCapasJunioEntities context = new DL_EF.JTorresProgramacionNCapasJunioEntities())
                {

                    var queryElemento = (from materiaDB in  context.Materias
                                         where materiaDB.IdMateria == materia.IdMateria
                                         select materiaDB).SingleOrDefault();

                    if (queryElemento != null)
                    {
                        
                        queryElemento.Nombre = materia.Nombre;
                        queryElemento.Creditos = materia.Creditos;
                        queryElemento.Costo = materia.Costo;

                    }
                    
                    
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
    }
}
