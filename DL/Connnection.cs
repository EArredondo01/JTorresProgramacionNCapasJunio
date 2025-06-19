using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DL
{
    public class Connnection
    {
        public static string Get()
        {                       
            return ConfigurationManager.ConnectionStrings["JTorresProgramacionNCapasJunio"].ToString(); 
        }

        // Data Source=.;Initial Catalog=EArredondoProgramacionNCapasJunio;User ID=sa;Password=pass@word1;Encrypt=False
    }
}
