using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ML
{
    public class Semestre
    {
        public byte IdSemestre { get; set; } //value
        public string Nombre { get; set; } //text
        public List<object> Semestres { get; set; }
    }

}
