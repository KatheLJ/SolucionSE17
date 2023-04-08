using SolucionSE17DAL.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionSE17DAL.Interfaces
{
    public interface IGestorProducto
    {
        IEnumerable<Producto> ListadodeProductos();


        int CrearProducto(Producto pProducto);


        int ActualizarProducto(Producto pProducto);


        int EliminarProducto(int ID_Producto);
    }
}
