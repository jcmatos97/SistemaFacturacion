using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacionInventario.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        public string Nombre {get;set;}
        public int Existencia { get; set; }
        public int LimiteExistencia { get; set; }
        public  decimal Precio { get; set; }
        public byte[] Foto { get; set; }
        public int Disponibilidad { get; set; }
        public ICollection<DetalleFactura> DetalleFactura { get; set; }
        public ICollection<DetallePedido> DetallePedido { get; set; }
    }
}