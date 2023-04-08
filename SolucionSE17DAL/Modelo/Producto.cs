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
    using System.ComponentModel.DataAnnotations;

    public partial class Producto
    {
        [Display(Name = "Id")]
        public int ID_Producto { get; set; }
        [Display(Name = "Nombre")]
        public string Nombre_producto { get; set; }
        [Display(Name = "Marca")]
        public int ID_Marca { get; set; }
        [Display(Name = "Categoria")]
        public int ID_Categoría { get; set; }
        public int Cantidad { get; set; }
        [Display(Name = "Estado")]
        public int Id_Estado { get; set; }
        public decimal Precio { get; set; }
        [Display(Name = "Ingreso")]
        public System.DateTime Fecha_iNgreso { get; set; }
    
        public virtual Categoria Categoria { get; set; }
        public virtual Estado_productos Estado_productos { get; set; }
        public virtual Marca Marca { get; set; }
    }
}
