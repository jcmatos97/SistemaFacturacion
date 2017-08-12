using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacionInventario.Models
{
    public class Factura
    {
        [Key]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        [StringLength(128)]
        [Required]
        public string UsuarioID { get; set; }
        public int ClienteID { get; set; }
        public virtual Cliente Cliente { get; set; }
        public ICollection<DetalleFactura> DetalleFactura { get; set; }

    }
}