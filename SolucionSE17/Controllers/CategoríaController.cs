using SolucionSE17DAL.Interfaces;
using SolucionSE17DAL.Modelo;
using SolucionSE17DAL.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SolucionSE17.Controllers
{
    public class CategoríaController : Controller
    {




        // GET: Categoría

        private readonly IGestorCategoria _oGestorCategoria;

        public CategoríaController()
        {
            _oGestorCategoria = new GestorCategoria();
        }

        public ActionResult CrearCategoria()
        {
            return View();
        }


        public ActionResult RegistroCategorias(Categoria pCategoria)
        {
            int registros = _oGestorCategoria.CrearCategoria(pCategoria);
            return RedirectToAction("ListadodeCategorias");
        }


        public ActionResult ListadodeCategorias()
        {
            //IEnumerable<Categoria> Categorias = _oGestorCategoria.ListadodeCategorias().;
            //return View(Categorias);
            using (SuperLaFamiliaEntities ContextoBD = new SuperLaFamiliaEntities())
            {
                var Categorias = ContextoBD.Categorias;
                return View(Categorias.ToList());


            }
        }



        //Muestra el formulario que permite actualizar un valor de las Categorias del Categoria
        public ActionResult ActualizarCategoria(int ID_Categoria)
        {
            Categoria obj = _oGestorCategoria.ListadodeCategorias().Where(x => x.ID_Categoria == ID_Categoria).FirstOrDefault();
            return View(obj);

        }


        //Permite actualizar una Categoria del Categoria
        public ActionResult ActualizarCategorias(Categoria pCategoria)
        {
            int registros = _oGestorCategoria.ActualizarCategoria(pCategoria);
            return RedirectToAction("ListadodeCategorias");

        }


        public ActionResult EliminarCategoria(int ID_Categoria)
        {
            using (SuperLaFamiliaEntities ContextoBD = new SuperLaFamiliaEntities())
            {
                var Categorias = ContextoBD.Categorias;
                return View(Categorias.ToList().Where(x => x.ID_Categoria == ID_Categoria).FirstOrDefault());
            }

        }


        //Permite eliminar una Categoria del Categoria
        public ActionResult Eliminar(int ID_Categoria)
        {
            int registro = _oGestorCategoria.EliminarCategoria(ID_Categoria);
            return RedirectToAction("ListadodeCategorias");

        }



        public ActionResult VerCategoria(int ID_Categoria)
        {

            using (SuperLaFamiliaEntities ContextoBD = new SuperLaFamiliaEntities())
            {
                var Categorias = ContextoBD.Categorias;
                return View(Categorias.ToList().Where(x => x.ID_Categoria == ID_Categoria).FirstOrDefault());
            }


        }
    }
}