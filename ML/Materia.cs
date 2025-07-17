using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Materia //Usuario
    {
     
        public int IdMateria { get; set; }
        public string Nombre { get; set; }
        public byte? Creditos { get; set; }
        public decimal Costo { get; set; }
        public List<object> Materias { get; set; }
        public ML.Semestre Semestre { get; set; }
        public ML.ImagenMateria ImagenMateria { get; set; }

        //Direccion             //Grupo
        //Dentro de Direccion  va el ML.Colonia
        //Dentro del ML.Colonia va el ML.Municipio
        //Dentro del ML.Municipio va el ML.Estado

        public ML.Grupo Grupo { get; set; }
        

    }
}
