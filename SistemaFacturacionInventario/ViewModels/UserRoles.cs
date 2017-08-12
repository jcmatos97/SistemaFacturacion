using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaFacturacionInventario.ViewModels
{
    public class UserRoles
    {
        public byte[] Foto { get; set; }
        public string Username{get;set;}
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Role { get; set; }
    }
}