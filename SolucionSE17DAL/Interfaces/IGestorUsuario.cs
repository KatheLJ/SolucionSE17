using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolucionSE17DAL.Modelo;

namespace SolucionSE17DAL.Interfaces
{
    public interface IGestorUsuario
    {
        IEnumerable<Usuario> ListadoUsuarios();


        int CrearUsuario(Usuario pUsuario);


        int ActualizarUsuario(Usuario pUsuario);


        int EliminarUsuario(int ID_Usuario);

    }
}
