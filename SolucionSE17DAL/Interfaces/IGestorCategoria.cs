using SolucionSE17DAL.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionSE17DAL.Interfaces
{
    public interface IGestorCategoria
    {
        IEnumerable<Categoria> ListadodeCategorias();


        int CrearCategoria(Categoria pCategoria);


        int ActualizarCategoria(Categoria pCategoria);


        int EliminarCategoria(int ID_Categoria);
    }
}
