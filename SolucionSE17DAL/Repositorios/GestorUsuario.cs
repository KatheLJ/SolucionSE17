using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolucionSE17DAL.Interfaces;
using SolucionSE17DAL.Modelo;
using System.Threading.Tasks;

namespace SolucionSE17DAL.Repositorios
{
    public class GestorUsuario : IGestorUsuario
    {

        //Método para enlistar las Usuarios creados 
        IEnumerable<Usuario> IGestorUsuario.ListadoUsuarios()
        {
            List<Usuario> Usuarios = new List<Usuario>();
            using (SuperLaFamiliaEntities ContextoBD = new SuperLaFamiliaEntities())
            {
                Usuarios = ContextoBD.Usuarios.ToList();
            }
            return Usuarios;
        }



        //Método para crear nuevas Usuarios 
        int IGestorUsuario.CrearUsuario(Usuario pUsuario)
        {
            int n = 0;
            using (SuperLaFamiliaEntities ContextoBD = new SuperLaFamiliaEntities())
            {
                ContextoBD.Usuarios.Add(pUsuario);
                n = ContextoBD.SaveChanges();
            }
            return n;

        }






        //Método para actualizar un Usuario (Mantenimiento)
        int IGestorUsuario.ActualizarUsuario(Usuario pUsuario)
        {
            int n = 0;
            using (SuperLaFamiliaEntities ContextoBD = new SuperLaFamiliaEntities())
            {
                ContextoBD.Entry<Usuario>(pUsuario).State = System.Data.Entity.EntityState.Modified;
                n = ContextoBD.SaveChanges();
            }
            return n;

        }

        //Método para eliminar un Usuario (Mantenimiento)
        int IGestorUsuario.EliminarUsuario(int pIdUsuario)
        {
            int n = 0;
            using (SuperLaFamiliaEntities ContextoBD = new SuperLaFamiliaEntities())
            {
                var obj = ContextoBD.Usuarios.Where(x => x.ID_Usuario == pIdUsuario).FirstOrDefault();
                if (obj == null)
                {
                    n = 0;
                }
                else
                {
                    ContextoBD.Entry<Usuario>(obj).State = System.Data.Entity.EntityState.Deleted;
                    n = ContextoBD.SaveChanges();
                }
            }
            return n;
        }



    }
}
