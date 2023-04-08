using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SolucionSE17DAL.Modelo;
using SolucionSE17DAL.Repositorios;
using SolucionSE17DAL.Interfaces;
using System.Web.Helpers;

namespace SolucionSE17.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        private readonly IGestorUsuario _oGestorUsuario;

        public UsuariosController()
        {
            _oGestorUsuario = new GestorUsuario();
        }


        // GET: Usuario
        public ActionResult Registro()
        {
            //Se inicializan las listas que se usaran más adelante
            List<Models.ViewModels.Rol> lst = null;

            using (SuperLaFamiliaEntities ContextoBD = new SuperLaFamiliaEntities())
            {
                //Permite mostrar un dropdownlist con los departamentos almacenados en la base de datos
                lst =
                (from d in ContextoBD.Rols
                 select new Models.ViewModels.Rol
                 {
                     ID_Rol = d.ID_Rol,
                     Nombre_Rol = d.Nombre_Rol
                 }).ToList();

                List<SelectListItem> items = lst.ConvertAll(d =>
                {

                    return new SelectListItem
                    {

                        Text = d.Nombre_Rol.ToString(),
                        Value = d.ID_Rol.ToString(),
                        Selected = false
                    };

                });


                ViewData["Rol"] = items;
                return View();
            }
        }


        //Accion que permite Registrar un empleado en la base de datos
        public ActionResult RegistroUsuario(Usuario pUsuario)
        {
            int registros = _oGestorUsuario.CrearUsuario(pUsuario);
            return RedirectToAction("Login");
        }





        //Accion que muestra la pantalla de inicio de sesion al empleado
        public ActionResult Login()
        {
            return View();
        }




        //Accion que valide los datos y permite o deniega el ingreso al usuario
        public ActionResult InicioSesion(Usuario pUsuario)
        {
            if (ModelState.IsValid)
            {
                using (SuperLaFamiliaEntities ContextoBD = new SuperLaFamiliaEntities())
                {
                    var user = ContextoBD.Usuarios.FirstOrDefault(a => a.Usuario1.Equals(pUsuario.Usuario1) &&
                    a.Contraseña.Equals(pUsuario.Contraseña));

                    if (user != null)
                    {
                        // Si se encuentra el usuario, se establecen las variables de sesión correspondientes
                        if (user.ID_Rol == 1)
                        {
                            Session["Gerencia"] = user.Usuario1;
                        }
                        else if (user.ID_Rol == 2)
                        {
                            Session["Administrador"] = user.Usuario1;
                        }
                        else if (user.ID_Rol == 3)
                        {
                            Session["Usuario"] = user.Usuario1;
                        }

                        Session["ID_Usuario"] = user.ID_Usuario;
                        Session["Nombre_Usuario"] = user.Nombre_Usuario;

                        // Redireccionar al usuario a la página de inicio
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            // Si no se encuentra el usuario, redireccionar a la página de registro
            return RedirectToAction("Registro", "Usuario");
        }

    }
}