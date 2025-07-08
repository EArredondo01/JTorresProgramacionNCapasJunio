using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class ImagenMateria
    { //bool  -> bit
      //decimal -> decimal
      //int -> int
      //string -> varchar

        public int IdImagenMateria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public byte[] Imagen { get; set; }
        public List<object> ImagenesMaterias { get; set; }
    }
}
