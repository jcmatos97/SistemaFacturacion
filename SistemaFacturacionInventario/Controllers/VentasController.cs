using Newtonsoft.Json;
using SistemaFacturacionInventario.Models;
using SistemaFacturacionInventario.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaFacturacionInventario.Controllers
{
    public class VentasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public Factura venta;
        public EncabezadoVenta encabezado;
        public ActionResult Index()
        {
            return View(Session["venta_actual"]);
        }
        public ActionResult ListaVentas()
        {
            var lp = db.Database.SqlQuery<ListaVentas>("EXEC sp_ListaVentas");
            return View(lp.ToList());
        }
        public ActionResult DetalleVenta(int id)
        {
            db.Configuration.LazyLoadingEnabled = false;
            db.Configuration.ProxyCreationEnabled = false;
            
            var encabezado = db.Factura.OrderBy(a => a.Id).Select(c => new { Id = c.Id, Fecha = c.Fecha, UsuarioID = c.UsuarioID, ClienteID = c.ClienteID}).ToList();
            var encabezado2 = encabezado.ToList().Find(x => x.Id == id);
            var cliente_info = db.Cliente.ToList().Find(x => x.Id == encabezado2.ClienteID);
            var user_info = db.Users.ToList().Find(x => x.Id == encabezado2.UsuarioID);
            EncabezadoVenta encabezadoVenta = new EncabezadoVenta { Id = encabezado2.Id, Fecha = encabezado2.Fecha, NombreCliente = cliente_info.Nombre+' '+cliente_info.Apellido, NombresDelUsuario = user_info.Nombre + ' ' + user_info.Apellido };
            List<TotalesPedido> totalesDetalle = db.Database.SqlQuery<TotalesPedido>("EXEC sp_DetalleVentaTotales @VentaId", new SqlParameter("@VentaId", id)).ToList();
            List<DetalleVentaRows> detalles = db.Database.SqlQuery<DetalleVentaRows>("EXEC sp_DetalleVentaRows @VentaId", new SqlParameter("@VentaId", id)).ToList();
            FacturaVentas obj = new FacturaVentas { encabezado = encabezadoVenta, detalle = detalles, totales = totalesDetalle };
            return View(obj);
        }

        [HttpPost]
        public ActionResult CrearVenta(ClienteId Cli)
        {
            var Current_UserInfo = db.Users.ToList().Find(x => x.UserName == User.Identity.Name);
            venta = new Factura { Fecha = DateTime.Now, UsuarioID = Current_UserInfo.Id, ClienteID = Cli.select_Cliente };
            db.Factura.Add(venta);
            db.SaveChanges();
            var cliente_info = db.Cliente.ToList().Find(x => x.Id == Cli.select_Cliente);
            encabezado = new EncabezadoVenta {Id=venta.Id,Fecha=venta.Fecha, NombreCliente = cliente_info.Nombre+" "+cliente_info.Apellido, NombresDelUsuario = Current_UserInfo.Nombre+" "+Current_UserInfo.Apellido};
            Session["venta_actual"] = encabezado;
            return RedirectToAction("Index", "Ventas");
            
        }
        public ActionResult getExistencia()
        {
            var productos = db.Producto.ToList().Select(x => new { x.Id, x.Nombre, x.Existencia });
            return Json(productos, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CrearDetalleVenta(GuardarDetalleVenta detalle)
        {
            decimal ITBIS = decimal.Parse(db.ITBIS.OrderByDescending(p => p.Id).Select(r => r.valor).First().ToString());
            var Product_info = db.Producto.ToList().Find(x => x.Id == detalle.Producto_Id);
            var subtotal = detalle._Cantidad * Product_info.Precio;
            var subtotal_ITBIS = ITBIS * subtotal;
            var total_detalle = subtotal + subtotal_ITBIS;

            DetalleFactura detalleventa = new DetalleFactura { FacturaID = detalle.IdVenta, ProductoID = detalle.Producto_Id, Cantidad = detalle._Cantidad, PrecioUnitario = Product_info.Precio, SubTotal = subtotal, ITBIS = subtotal_ITBIS, TotalDetalle = total_detalle };

            db.DetalleFactura.Add(detalleventa);
            db.SaveChanges();
            
            return Json(detalleventa, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getDetalles(int id)
        {
            List<DetalleVentaRows> detalles = db.Database.SqlQuery<DetalleVentaRows>("EXEC sp_DetalleVentaRows @VentaId", new SqlParameter("@VentaId", id)).ToList();
            return Json(detalles, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getTotales(int id)
        {
            List<TotalesPedido> totales = db.Database.SqlQuery<TotalesPedido>("EXEC sp_DetalleVentaTotales @VentaId", new SqlParameter("@VentaId", id)).ToList();

            return Json(totales, JsonRequestBehavior.AllowGet);
        }
        public ActionResult delete_Detalle(int id)
        {
            DetalleFactura detalle = db.DetalleFactura.ToList().Find(p => p.Id == id);
            if (detalle != null)
            {
                db.DetalleFactura.Remove(detalle);
                db.SaveChanges();
            }

            return Json(detalle, JsonRequestBehavior.AllowGet);
        }
        public ActionResult delete_Venta(int id)
        {
            Factura factura = db.Factura.ToList().Find(p => p.Id == id);
            if (factura != null)
            {
                db.Factura.Remove(factura);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }

    }
    public class DetalleVentaRows
    {
        public int id_detalleVenta { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
        public decimal ITBIS { get; set; }
        public decimal TotalDetalle { get; set; }
    }
    public class ListaVentas
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public decimal SubTotal { get; set; }
        public decimal ITBIS { get; set; }
        public decimal Total { get; set; }
    }
    public class FacturaVentas
    {
        public EncabezadoVenta encabezado { get; set; }
        public List<TotalesPedido> totales { get; set; }
        public List<DetalleVentaRows> detalle { get; set; }
    }
}
