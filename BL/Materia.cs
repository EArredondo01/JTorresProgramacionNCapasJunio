using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Odbc;//EXCEL
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

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

                            materia.IdMateria =Convert.ToInt32(row[0].ToString());
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

                    context.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();

                    if(RowsAffected > 0 )
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
