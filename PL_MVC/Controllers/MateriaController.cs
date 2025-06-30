using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class MateriaController : Controller
    {
        //ActionResult

        [HttpGet]  // Action Verb [HttpPost]
        public ActionResult GetAll() //Action Method
        {
            ML.Materia materia = new ML.Materia();

            //BL

            ML.Result result = BL.Materia.GetAllLinq();

            if(result.Correct)
            {
                materia.Materias = result.Objects;
            }
            
            return View(materia);
        }

       
    }
}