using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Venta_de_Carros.Models;
using System.Data.Entity;


namespace Venta_de_Carros.Clases
{
    public class clsRevisionesGarantia
    {

        private VentaDeCarrosTallerEntities ITM_Ventas = new VentaDeCarrosTallerEntities();
        public Revisiones_Garantia Revisiones_Garantia { get; set; }
        public string Insertar()
        {
            ITM_Ventas.Revisiones_Garantia.Add(Revisiones_Garantia);
            ITM_Ventas.SaveChanges();
            return "Revisión de garantia insertada exitosamente";
        }

        public string Actualizar()
        {
            try
            {
                Revisiones_Garantia RevisionGarantia = Consultar(Revisiones_Garantia.ID_Revision.ToString());
                if (RevisionGarantia == null)
                {
                    return "La revisión de garantia no existe";
                }

                ITM_Ventas.Revisiones_Garantia.AddOrUpdate(Revisiones_Garantia);
                ITM_Ventas.SaveChanges();
                return "Se actualizó correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Revisiones_Garantia Consultar(string IdRevision)
        {
            Revisiones_Garantia RevisionGarantia = ITM_Ventas.Revisiones_Garantia.FirstOrDefault(e => e.ID_Revision.ToString() == IdRevision.ToString());
            return RevisionGarantia;
        }

        public string Eliminar()
        {
            try
            {
                Revisiones_Garantia RevisionGarantia = Consultar(Revisiones_Garantia.ID_Revision.ToString());
                if (RevisionGarantia == null)
                {
                    return "La revisión de garantia no existe";
                }
                ITM_Ventas.Revisiones_Garantia.Remove(RevisionGarantia);
                ITM_Ventas.SaveChanges();
                return "Se eliminó la revision de factura exitosamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Revisiones_Garantia> ConsultarTodos()
        {
            // 1. Usa .Include() para cargar las entidades relacionadas que necesitas.
            // 2. Usa .Select() para proyectar los resultados a tu DTO.
            var resut = ITM_Ventas
                .Revisiones_Garantia
                //.Include(rg => rg.Garantia) // Incluye la entidad Garantia
                //.Include(rg => rg.Empleado) // Incluye la entidad Empleado
                .ToList();

            return resut; // Ahora retorna la lista de DTOs

        }
    }
}