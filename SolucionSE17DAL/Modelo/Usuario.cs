//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SolucionSE17DAL.Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuario
    {
        public int ID_Usuario { get; set; }
        public string Nombre_Usuario { get; set; }
        public int ID_Rol { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }
        public string Usuario1 { get; set; }
        public string Contraseña { get; set; }
    
        public virtual Rol Rol { get; set; }
    }
}
