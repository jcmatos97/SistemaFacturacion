using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacionInventario.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        [StringLength(128)]
        [Required]
        public string UsuarioID { get; set; }
        public int ProveedorId { get; set; }
        public virtual Proveedor Proveedor { get; set; }
        public ICollection<DetallePedido> DetallePedido { get; set; }
    }
}