using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaFacturacionInventario.ViewModels
{
    public class EncabezadoVenta
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string NombresDelUsuario { get; set; }
        public string NombreCliente { get; set; }
    }
}