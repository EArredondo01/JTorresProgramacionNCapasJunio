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

            if(result.Correct)
            {
                materia.Materias = result.Objects;
            }
            else
            {
                ViewBag.Mensaje = result.ErrorMessage;
            }
            
            return View(materia); //ML.Result - 
        }

        [HttpGet]
        public ActionResult Add() 
        {
            

            return View();
        }
       
    }
}