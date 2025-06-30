using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Materia
    {
        //ctrl + tab
        public static void GetAll()
        {
            ML.Result result = BL.Materia.GetAll();

            if (result.Correct)
            {
                foreach (ML.Materia materia in result.Objects)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("\n IdMateria: " + materia.IdMateria);
                    Console.WriteLine("\n Nombre: " + materia.Nombre);
                    Console.WriteLine("\n Creditos: " + materia.Creditos);
                    Console.WriteLine("\n Costo: " + materia.Costo);
                }
            }
        }

        public static void GetById()
        {

            ML.Result result = BL.Materia.GetById(2);

            if (result.Correct)
            {
                //primitivos , complejos
                Console.WriteLine("\n");
                Console.WriteLine("\n IdMateria: " + ((ML.Materia)result.Object).IdMateria); //unboxing
                Console.WriteLine("\n Nombre: " + ((ML.Materia)result.Object).Nombre);
                Console.WriteLine("\n Creditos: " + ((ML.Materia)result.Object).Creditos);
                Console.WriteLine("\n Costo: " + ((ML.Materia)result.Object).Costo);

            }
        }

        public static void Add()
        {
            ML.Materia materia = new ML.Materia();

            Console.WriteLine("Ingresa el nombre");
            materia.Nombre = Console.ReadLine();

            Console.WriteLine("Ingresa los créditos");
            materia.Creditos = Convert.ToByte(Console.ReadLine()); //1

            Console.WriteLine("Ingresa el costo");
            materia.Costo = Convert.ToDecimal(Console.ReadLine());

            //materia.Semestre = new ML.Semestre();
            materia.Semestre.IdSemestre = Convert.ToByte(Console.ReadLine()); //SET

            //ML.Result result = BL.Materia.Add(materia);
            ML.Result result = BL.Materia.AddEF(materia);

            if (result.Correct)
            {
                Console.WriteLine("Se insertó correctamente la materia");
            }
            else
            {
                Console.WriteLine("Hubo un error al insertar la materia:" + result.ErrorMessage);
            }

        }

        public static void Update()
        {
            ML.Materia materia = new ML.Materia();

            materia.IdMateria = Convert.ToByte(Console.ReadLine());

            Console.WriteLine("Ingresa el nombre");
            materia.Nombre = Console.ReadLine();

            Console.WriteLine("Ingresa los créditos");
            materia.Creditos = Convert.ToByte(Console.ReadLine()); //1

            Console.WriteLine("Ingresa el costo");
            materia.Costo = Convert.ToDecimal(Console.ReadLine());

            ML.Result result = BL.Materia.UpdateLinq(materia);


        }
    }
}
