using ML;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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

            ML.Result result = BL.Materia.GetAllEF();

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


        public ActionResult DeleteImagen(string IdImagenMateria) //Action Method 
        {
            ML.ImagenMateria imagenMateria = new ML.ImagenMateria();
            if((Session["ListaImagenes"]) != null)
            {
                imagenMateria.ImagenesMaterias = (Session["ListaImagenes"]) as List<object>;

                foreach (ML.ImagenMateria obj in imagenMateria.ImagenesMaterias)
                {
                    if(obj.IdImagenMateria == IdImagenMateria)
                    {
                        imagenMateria.ImagenesMaterias.Remove(obj);
                        break;
                    }
                }

                int x;

                bool PudoConvertir = int.TryParse(IdImagenMateria,out x);

                if(PudoConvertir==true)
                {
                    //BL.   ImagenMateria.Delete(IdImagenMateria);
                }
                
                

                Session["ListaImagenes"] = imagenMateria.ImagenesMaterias;

            }
            else
            {
                ViewBag.Error = "No existen elementos en la sesión";
            }

            return RedirectToAction("Form", new { IdMateria = 0 });

        }

        [HttpPost]
        public ActionResult AddImagen(ML.Materia materia) //Action Method 
        {

            materia.ImagenMateria.ImagenesMaterias = new List<object>();

            HttpPostedFileBase imagen = Request.Files["imgMateriaInput"];

            #region ConvertStreamToByte
            if (imagen.ContentLength > 0)
            {
                MemoryStream target = new MemoryStream();
                imagen.InputStream.CopyTo(target);
                byte[] data = target.ToArray();
                materia.ImagenMateria.Imagen = data;
                materia.ImagenMateria.IdImagenMateria = Guid.NewGuid().ToString();
                materia.ImagenMateria.Nombre = imagen.FileName;
            }
            #endregion 



            if (Session["ListaImagenes"] == null)
            {
                materia.ImagenMateria.ImagenesMaterias.Add(materia.ImagenMateria);
            }
            else
            {
                materia.ImagenMateria.ImagenesMaterias = (Session["ListaImagenes"]) as List<object>;
                materia.ImagenMateria.ImagenesMaterias.Add(materia.ImagenMateria);
            }

            

            Session["ListaImagenes"] = materia.ImagenMateria.ImagenesMaterias;

            return RedirectToAction("Form", new { IdMateria = materia.IdMateria, BorrarSesion = false });
        }


        [HttpGet] // Mostrar la vista
        public ActionResult Form(int? IdMateria, bool? BorrarSesion) //Add, update
        {
            ML.Materia materia = new ML.Materia();
            materia.ImagenMateria = new ML.ImagenMateria();

            ML.Result resultSemestres = new ML.Result();
            resultSemestres = BL.Semestre.GetAll(); // Consulto todos mis semestres

            if(BorrarSesion.Value == true)
            {
                if (Session["ListaImagenes"] != null)
                {
                    Session["ListaImagenes"] = null;
                }

            }
            if (resultSemestres.Correct)
            {
                materia.Semestre = new ML.Semestre();
                materia.Semestre.Semestres = resultSemestres.Objects;
            }

            if (IdMateria > 0) //     >0   Update
            {
                //get by id
                ML.Result result = BL.Materia.GetByIdLinq(IdMateria.Value);

                if (result.Correct)
                {
                    materia = (ML.Materia)result.Object;//Unboxing
                    materia.Semestre.Semestres = resultSemestres.Objects;

                    ML.Result resultImagenes = BL.ImagenMateria.GetByIdMateria(IdMateria.Value);
                    materia.ImagenMateria = new ML.ImagenMateria();

                    if (Session["ListaImagenes"] != null)
                    {
                        List<object> list1 = (Session["ListaImagenes"]) as List<object>; //4
                        materia.ImagenMateria.ImagenesMaterias = resultImagenes.Objects;//2
                        List<object> list2 = resultImagenes.Objects;

                        var lista3=list1.Concat(list2).Distinct().ToList();//prueba

                        List<ImagenMateria> list4 = new List<ImagenMateria>();

                        foreach (ML.ImagenMateria obj in lista3)
                        {
                            var obj4 = list4.Find(x => x.IdImagenMateria == obj.IdImagenMateria);
                            if(obj4 == null)
                            {
                                list4.Add(obj);
                            }

                        }

                        Session["ListaImagenes"] = list4.Cast<object>().ToList(); 
                        materia.ImagenMateria.ImagenesMaterias = list4.Cast<object>().ToList();
                        return View(materia);

                    }
                    else
                    {
                        materia.ImagenMateria.ImagenesMaterias = resultImagenes.Objects;//2

                    }

                }
                else
                {

                }

            }
            else //Add
            {

            }

            if (Session["ListaImagenes"] != null)
            {
                List<object> prueba = (Session["ListaImagenes"]) as List<object>;
                materia.ImagenMateria.ImagenesMaterias = prueba;
            }


            return View(materia);
        }

        [HttpPost] // Recibir datos, guardar datos
        public ActionResult Form(ML.Materia materia) //Add, update
        {
            if (materia.IdMateria == 0) //Add
            {
                ML.Result result = BL.Materia.AddLinq(materia);

                int IdMateria = (int)result.Object;


                if(IdMateria> 0)
                {
                    //insertar las materia
                    materia.ImagenMateria = new ML.ImagenMateria();
                    materia.ImagenMateria.ImagenesMaterias = (Session["ListaImagenes"]) as List<object>;


                    foreach (ML.ImagenMateria imagenMateriaObj in materia.ImagenMateria.ImagenesMaterias)
                    {
                        materia.ImagenMateria = imagenMateriaObj;
                        materia.IdMateria = IdMateria;
                        
                        //if(Convert.ToInt(imagenMateriaObj.IdImagenMateria))
                        //{
                        //    ML.Result resultInsertImagenMateria = BL.ImagenMateria.Update(materia);

                        //}
                        //else
                        //{
                            ML.Result resultInsertImagenMateria = BL.ImagenMateria.Add(materia);

                        //}
                    }
                }
            }
            else //Update
            {

            }


            return RedirectToAction("GetAll");
        }

        public ActionResult Delete(int IdMateria)
        {
            return RedirectToAction("GetAll");
        }
    }
}