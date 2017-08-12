using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacionInventario.Models
{
    public class DetallePedido
    {
        [Key]
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public virtual Pedido Pedido { get; set; }
        public int ProductoId { get; set; }
        public virtual Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal SubTotal { get; set; }
        public decimal ITBIS { get; set; }
        public decimal TotalDetalle { get; set; }
    }
}