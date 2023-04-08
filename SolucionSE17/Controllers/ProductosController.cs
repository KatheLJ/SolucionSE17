using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using SolucionSE17DAL.Modelo;
using SolucionSE17DAL.Repositorios;
using SolucionSE17DAL.Interfaces;
using System.Web.Helpers;

namespace SolucionSE17.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        private readonly IGestorProducto _oGestorProducto;

        public ProductosController()
        {
            _oGestorProducto = new GestorProducto();
        }



        // GET: Productos
        public ActionResult RegistrodeProductos()
        {
            //Se inicializan las listas que se usaran más adelante
            List<Models.ViewModels.Estado_productos> lst = null;
            List<Models.ViewModels.Categoria> lst2 = null;
            List<Models.ViewModels.Marca> lst3 = null;

            using (SuperLaFamiliaEntities ContextoBD = new SuperLaFamiliaEntities())
            {

                lst =
                (from d in ContextoBD.Estado_productos
                 select new Models.ViewModels.Estado_productos
                 {
                     ID_Estado = d.ID_Estado,
                     Nombre_estado = d.Nombre_estado
                 }).ToList();

                List<SelectListItem> items = lst.ConvertAll(d =>
                {

                    return new SelectListItem
                    {

                        Text = d.Nombre_estado.ToString(),
                        Value = d.ID_Estado.ToString(),
                        Selected = false
                    };

                });



                lst2 =
                (from d in ContextoBD.Categorias
                 select new Models.ViewModels.Categoria
                 {
                     ID_Categoria = d.ID_Categoria,
                     Descripcion = d.Descripcion
                 }).ToList();

                List<SelectListItem> items2 = lst2.ConvertAll(d =>
                {

                    return new SelectListItem
                    {

                        Text = d.Descripcion.ToString(),
                        Value = d.ID_Categoria.ToString(),
                        Selected = false
                    };

                });


                lst3 =
               (from d in ContextoBD.Marcas
                select new Models.ViewModels.Marca
                {
                    ID_Marca = d.ID_Marca,
                    Descripcion = d.Descripcion
                }).ToList();

                List<SelectListItem> items3 = lst3.ConvertAll(d =>
                {

                    return new SelectListItem
                    {

                        Text = d.Descripcion.ToString(),
                        Value = d.ID_Marca.ToString(),
                        Selected = false
                    };

                });


                ViewData["EstadoProducto"] = items;
                ViewData["Categoria"] = items2;
                ViewData["Marca"] = items3;
                return View();
            }

        }

        public ActionResult RegistroProductos(Producto pProducto)
        {
            int registros = _oGestorProducto.CrearProducto(pProducto);
            return RedirectToAction("ListadodeProductos");
        }


        public ActionResult ListadodeProductos()
        {
            //IEnumerable<Producto> productos = _oGestorProducto.ListadodeProductos().;
            //return View(productos);
            using (SuperLaFamiliaEntities ContextoBD = new SuperLaFamiliaEntities())
            {
                var productos = ContextoBD.Productos;
                return View(productos.ToList());


            }
        }



        //Muestra el formulario que permite actualizar un valor de las Productos del Producto
        public ActionResult ActualizarProductos(int id)
        {
            Producto obj = _oGestorProducto.ListadodeProductos().Where(x => x.ID_Producto == id).FirstOrDefault();
            return View(obj);

        }


        //Permite actualizar una Producto del Producto
        public ActionResult ActualizarProducto(Producto pProducto)
        {
            int registros = _oGestorProducto.ActualizarProducto(pProducto);
            return RedirectToAction("ListadodeProductos");

        }

        //Permite eliminar una Producto del Producto
        public ActionResult EliminarProducto(int id)
        {
            int registro = _oGestorProducto.EliminarProducto(id);
            return RedirectToAction("ListadodeProductos");

        }
    }
}