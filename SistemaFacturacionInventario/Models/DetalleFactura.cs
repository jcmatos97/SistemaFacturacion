using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacionInventario.Models
{
    public class DetalleFactura
    {
        [Key]
        public int Id { get; set; }
        public int FacturaID { get; set; }
        public virtual Factura Factura { get; set; }
        public int ProductoID { get; set; }
        public virtual Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal SubTotal { get; set; }
        public decimal ITBIS { get; set; }
        public decimal TotalDetalle { get; set; }

    }
}