using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacionInventario.Models
{
    public class Proveedor
    {
        [Key]
        public int Id { get; set; }
        public string NombreProveedor { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public ICollection<Pedido> Pedido { get; set; }
    }
}