using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaFacturacionInventario.ViewModels
{
    public class GuardarDetallePedido
    {
        public int PedidoId { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    }
}