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
    
    public partial class Garantia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Garantia()
        {
            this.Revisiones_Garantia = new HashSet<Revisiones_Garantia>();
        }
    
        public int ID_Garantia { get; set; }
        public int ID_Vehiculo_Vendido { get; set; }
        public System.DateTime Fecha_Inicio_Garantia { get; set; }
        public Nullable<System.DateTime> Fecha_Fin_Garantia { get; set; }
        public string Descripcion_Garantia { get; set; }
        public Nullable<int> Kilometraje_Inicio { get; set; }
        public Nullable<int> Kilometraje_Fin { get; set; }
        public string Estado_Garantia { get; set; }
    
        public virtual Venta Venta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Revisiones_Garantia> Revisiones_Garantia { get; set; }
    }
}
