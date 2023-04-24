using SolucionSE17DAL.Interfaces;
using SolucionSE17DAL.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionSE17DAL.Repositorios
{
    public class GestorCategoria : IGestorCategoria
    {
        //Método para enlistar las Categorias creados 
        IEnumerable<Categoria> IGestorCategoria.ListadodeCategorias()
        {
            List<Categoria> Categorias = new List<Categoria>();
            using (SuperLaFamiliaEntities ContextoBD = new SuperLaFamiliaEntities())
            {
                Categorias = ContextoBD.Categorias.ToList();
            }
            return Categorias;
        }



        //Método para crear nuevas Categorias 
        int IGestorCategoria.CrearCategoria(Categoria pCategoria)
        {
            int n = 0;
            using (SuperLaFamiliaEntities ContextoBD = new SuperLaFamiliaEntities())
            {
                ContextoBD.Categorias.Add(pCategoria);
                n = ContextoBD.SaveChanges();
            }
            return n;

        }






        //Método para actualizar un Categoria (Mantenimiento)
        int IGestorCategoria.ActualizarCategoria(Categoria pCategoria)
        {
            int n = 0;
            using (SuperLaFamiliaEntities ContextoBD = new SuperLaFamiliaEntities())
            {
                ContextoBD.Entry<Categoria>(pCategoria).State = System.Data.Entity.EntityState.Modified;
                n = ContextoBD.SaveChanges();
            }
            return n;

        }

        //Método para eliminar un Categoria (Mantenimiento)
        int IGestorCategoria.EliminarCategoria(int ID_Categoria)
        {
            int n = 0;
            using (SuperLaFamiliaEntities ContextoBD = new SuperLaFamiliaEntities())
            {
                var obj = ContextoBD.Categorias.Where(x => x.ID_Categoria == ID_Categoria).FirstOrDefault();
                if (obj == null)
                {
                    n = 0;
                }
                else
                {
                    ContextoBD.Entry<Categoria>(obj).State = System.Data.Entity.EntityState.Deleted;
                    n = ContextoBD.SaveChanges();
                }
            }
            return n;
        }




    }
}
