using SolucionSE17DAL.Interfaces;
using SolucionSE17DAL.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionSE17DAL.Repositorios
{
    public class GestorProducto : IGestorProducto
    {
        //Método para enlistar las Productos creados 
        IEnumerable<Producto> IGestorProducto.ListadodeProductos()
        {
            List<Producto> Productos = new List<Producto>();
            using (SuperLaFamiliaEntities ContextoBD = new SuperLaFamiliaEntities())
            {
                Productos = ContextoBD.Productos.ToList();
            }
            return Productos;
        }



        //Método para crear nuevas Productos 
        int IGestorProducto.CrearProducto(Producto pProducto)
        {
            int n = 0;
            using (SuperLaFamiliaEntities ContextoBD = new SuperLaFamiliaEntities())
            {
                ContextoBD.Productos.Add(pProducto);
                n = ContextoBD.SaveChanges();
            }
            return n;

        }






        //Método para actualizar un Producto (Mantenimiento)
        int IGestorProducto.ActualizarProducto(Producto pProducto)
        {
            int n = 0;
            using (SuperLaFamiliaEntities ContextoBD = new SuperLaFamiliaEntities())
            {
                ContextoBD.Entry<Producto>(pProducto).State = System.Data.Entity.EntityState.Modified;
                n = ContextoBD.SaveChanges();
            }
            return n;

        }

        //Método para eliminar un Producto (Mantenimiento)
        int IGestorProducto.EliminarProducto(int ID_Producto)
        {
            int n = 0;
            using (SuperLaFamiliaEntities ContextoBD = new SuperLaFamiliaEntities())
            {
                var obj = ContextoBD.Productos.Where(x => x.ID_Producto == ID_Producto).FirstOrDefault();
                if (obj == null)
                {
                    n = 0;
                }
                else
                {
                    ContextoBD.Entry<Producto>(obj).State = System.Data.Entity.EntityState.Deleted;
                    n = ContextoBD.SaveChanges();
                }
            }
            return n;
        }




    }
}
