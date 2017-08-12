using SistemaFacturacionInventario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.SqlClient;

namespace SistemaFacturacionInventario.Controllers
{
    public class ProductosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var data = db.Producto.ToList();
            return View(data);
        }

        public ActionResult GuardarProducto(Producto_DecimalFix producto, HttpPostedFileBase imagen)
        {
            try
            {
                string[] precio_arreglo = producto.Precio.Split('.');
                Producto producto_decimalFixed = new Producto { Nombre = producto.Nombre, Existencia = producto.Existencia, LimiteExistencia = producto.LimiteExistencia, Precio = Convert.ToDecimal(precio_arreglo[0] + ',' + precio_arreglo[1]), Foto = producto.Foto, Disponibilidad = producto.Disponibilidad };
                //Producto Nuevo con Imagenes  
                producto_decimalFixed.Foto = new byte[imagen.ContentLength];
                imagen.InputStream.Read(producto_decimalFixed.Foto, 0, imagen.ContentLength);
                db.Producto.Add(producto_decimalFixed);
                db.SaveChanges();
                var data = db.Producto.ToList();
                return RedirectToAction("Index", "Productos", data);
            }
            catch
            {
                Producto producto_decimalFixed = new Producto { Nombre = producto.Nombre, Existencia = producto.Existencia, LimiteExistencia = producto.LimiteExistencia, Precio = Convert.ToDecimal(producto.Precio), Foto = producto.Foto, Disponibilidad = producto.Disponibilidad };
                //Producto Nuevo con Imagenes  
                producto_decimalFixed.Foto = new byte[imagen.ContentLength];
                imagen.InputStream.Read(producto_decimalFixed.Foto, 0, imagen.ContentLength);
                db.Producto.Add(producto_decimalFixed);
                db.SaveChanges();
                var data = db.Producto.ToList();
                return RedirectToAction("Index", "Productos", data);
            }
            
        }
        
        public ActionResult ModificarProducto(Producto producto)
        {

            db.Database.ExecuteSqlCommand("EXEC sp_ModifyProducts @id, @nombre, @precio, @limite", new SqlParameter("@id", producto.Id), new SqlParameter("@nombre", producto.Nombre), new SqlParameter("@precio", producto.Precio), new SqlParameter("@limite", producto.LimiteExistencia));
            db.SaveChanges();

            var data = db.Producto.ToList();
            return RedirectToAction("Index", "Productos", data);
        }
        public class Producto_DecimalFix
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public int Existencia { get; set; }
            public int LimiteExistencia { get; set; }
            public string Precio { get; set; }
            public byte[] Foto { get; set; }
            public int Disponibilidad { get; set; }
         
        }
      
    }
}