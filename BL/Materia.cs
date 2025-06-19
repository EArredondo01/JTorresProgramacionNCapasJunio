using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Materia
    {
        public static void Add()
        {
            // Liberar recursos
            // Importar namespaces
            using (SqlConnection context = new SqlConnection("Data Source=.;Initial Catalog=EArredondoProgramacionNCapasJunio;User ID=sa;Password=pass@word1;Encrypt=False"))
            {
                string Nombre = "Prueba";
                byte Creditos = 140;
                decimal Costo = 200;

                string query = "INSERT INTO Materia (Nombre, Creditos, Costo) VALUES (@Nombre, @Creditos, @Costo)";

                SqlCommand cmd = new SqlCommand(query, context);
                //SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = context;

                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Creditos", Creditos);
                cmd.Parameters.AddWithValue("@Costo", Costo);

                context.Open();

                cmd.ExecuteNonQuery();
            }
        }

    }
}
