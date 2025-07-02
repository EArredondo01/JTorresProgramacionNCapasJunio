using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class MateriaController : Controller
    {


        [HttpGet]
        public ActionResult GetAll() //Action Method 
        {
            ML.Materia materia = new ML.Materia();

            ML.Result result = BL.Materia.GetAllLinq();

            if (result.Correct)
            {
                materia.Materias = result.Objects;
            }
            else
            {
                ViewBag.Mensaje = result.ErrorMessage;
            }

            return View(materia); //ML.Result - 
        }

        [HttpGet] // Mostrar la vista
        public ActionResult Form(int? IdMateria) //Add, update
        {
            ML.Materia materia = new ML.Materia();

            if (IdMateria > 0) //     >0   Update
            {
                //get by id
                ML.Result result = BL.Materia.GetByIdLinq(IdMateria.Value);
                
                if(result.Correct)
                {
                    materia = (ML.Materia)result.Object;//Unboxing
                }
                else
                {

                }
                
            }
            else //Add
            {

            }


            return View(materia);
        }

        [HttpPost] // Recibir datos, guardar datos
        public ActionResult Form(ML.Materia Materia) //Add, update
        {
            ML.Materia materia = new ML.Materia();

            if (materia.IdMateria == 0) //Add
            {
               ML.Result result = BL.Materia.AddLinq(materia);
            }
            else //Update
            {

            }


            return RedirectToAction("GetAll");
        }

    }
}