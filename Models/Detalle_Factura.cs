//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Venta_de_Carros.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Detalle_Factura
    {
        public int ID_Detalle_Factura { get; set; }
        public int ID_Factura { get; set; }
        public string Tipo_Item { get; set; }
        public Nullable<int> ID_Detalle_Servicio_Factura { get; set; }
        public Nullable<int> ID_Detalle_Repuesto_Factura { get; set; }
        public string Descripcion_Item { get; set; }
        public Nullable<decimal> Cantidad { get; set; }
        public Nullable<decimal> Precio_Unitario { get; set; }
        public Nullable<decimal> Subtotal_Item { get; set; }
    
        public virtual Detalle_Repuestos_Orden Detalle_Repuestos_Orden { get; set; }
        public virtual Detalle_Servicios Detalle_Servicios { get; set; }
        public virtual Factura Factura { get; set; }
    }
}
