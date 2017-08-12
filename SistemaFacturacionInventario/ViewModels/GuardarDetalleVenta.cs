using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaFacturacionInventario.ViewModels
{
    public class GuardarDetalleVenta
    {
        public int IdVenta { get; set; }
        public int Producto_Id { get; set; }
        public int _Cantidad { get; set; }
    }
}