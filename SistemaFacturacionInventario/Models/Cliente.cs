using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaFacturacionInventario.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } 
        public ICollection<Factura> Fatura { get; set; }
        
    }
}