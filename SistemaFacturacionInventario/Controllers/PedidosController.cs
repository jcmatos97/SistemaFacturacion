using SistemaFacturacionInventario.Models;
using SistemaFacturacionInventario.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaFacturacionInventario.Controllers
{
    public class PedidosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public Pedido pedido;
        public EncabezadoPedido encabezado;
        
       [HttpGet]
        public ActionResult Index()
        {
            return View(Session["pedido_actual"]);
        }
        public ActionResult ListaPedidos()
        {
            var lp = db.Database.SqlQuery<ListaPedidos>("EXEC sp_ListaPedidos");
            return View(lp.ToList());
        }
        public ActionResult DetallePedido(int id)
        {
            var encabezado = db.Pedido.ToList().Find(x => x.Id == id);
            var proveedor_info = db.Proveedor.ToList().Find(x => x.Id == encabezado.ProveedorId);
            var user_info = db.Users.ToList().Find(x => x.Id == encabezado.UsuarioID);
            EncabezadoPedido encabezadoDetalle = new EncabezadoPedido {Id = encabezado.Id, Fecha = encabezado.Fecha, NombreProveedor = proveedor_info.NombreProveedor, NombresDelUsuario = user_info.Nombre+' '+user_info.Apellido };
            List<TotalesPedido> totalesDetalle = db.Database.SqlQuery<TotalesPedido>("EXEC sp_DetallePedidoTotales @PedidoId", new SqlParameter("@PedidoId", id)).ToList();
            List<DetallePedidosRows> detalles = db.Database.SqlQuery<DetallePedidosRows>("EXEC sp_DetallePedidoRows @PedidoId", new SqlParameter("@PedidoId", id)).ToList();
            FacturaPedido obj = new FacturaPedido {encabezado = encabezadoDetalle, detalle = detalles, totales=totalesDetalle};
            return View(obj);
        }

        [HttpPost]
        public ActionResult CrearPedido(ProveedorId Prov)
        {
            var Current_UserInfo = db.Users.ToList().Find(x => x.UserName == User.Identity.Name);
            pedido = new Pedido { Fecha = DateTime.Now, UsuarioID = Current_UserInfo.Id, ProveedorId = Prov.select_Proveedor };
            db.Pedido.Add(pedido);
            db.SaveChanges();
            var proveedor_info = db.Proveedor.ToList().Find(x => x.Id == Prov.select_Proveedor);
            encabezado = new EncabezadoPedido { Id = pedido.Id, Fecha = pedido.Fecha, NombreProveedor = proveedor_info.NombreProveedor, NombresDelUsuario = Current_UserInfo.Nombre + " " + Current_UserInfo.Apellido };
            Session["pedido_actual"] = encabezado;
            return RedirectToAction("Index", "Pedidos");
        }
        public ActionResult getParametersAndProducts()
        {
            var productos = db.Producto.ToList().Select(x => new { x.Id, x.Nombre, x.LimiteExistencia, x.Existencia });
            return Json(productos, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CrearDetallePedido(GuardarDetallePedido detalle)
        {
            decimal ITBIS = decimal.Parse(db.ITBIS.OrderByDescending(p => p.Id).Select(r => r.valor).First().ToString());
            var subtotal = detalle.Cantidad * detalle.Precio;
            var subtotal_ITBIS = ITBIS * subtotal;
            var total_detalle = subtotal + subtotal_ITBIS;
            
            DetallePedido detallepedido = new DetallePedido { PedidoId = detalle.PedidoId, ProductoId = detalle.IdProducto, Cantidad = detalle.Cantidad, PrecioUnitario = detalle.Precio, SubTotal = subtotal, ITBIS = subtotal_ITBIS, TotalDetalle = total_detalle };
            

            db.DetallePedido.Add(detallepedido);
            db.SaveChanges();



            return Json(detallepedido, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getDetalles(int id)
        {
            List<DetallePedidosRows> detalles = db.Database.SqlQuery<DetallePedidosRows>("EXEC sp_DetallePedidoRows @PedidoId", new SqlParameter("@PedidoId",id )).ToList();

            return Json(detalles, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getTotales(int id)
        {
            List<TotalesPedido> totales = db.Database.SqlQuery<TotalesPedido>("EXEC sp_DetallePedidoTotales @PedidoId", new SqlParameter("@PedidoId", id)).ToList();

            return Json(totales, JsonRequestBehavior.AllowGet);
        }
        public ActionResult delete_Detalle(int id) {
            DetallePedido detalle = db.DetallePedido.ToList().Find(p => p.Id == id);
            if(detalle != null)
            {
                db.DetallePedido.Remove(detalle);
                db.SaveChanges();
            }

            return Json(detalle, JsonRequestBehavior.AllowGet);
        }
        public ActionResult delete_Pedido(int id)
        {
            Pedido pedido = db.Pedido.ToList().Find(p => p.Id == id);
            if (pedido != null)
            {
                db.Pedido.Remove(pedido);
                db.SaveChanges();
            }
            return RedirectToAction("Index","Home");
        }

    }
    public class DetallePedidosRows
    {
        public int id_detallePedido{get; set;}
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
        public decimal ITBIS { get; set; }
        public decimal TotalDetalle { get; set; }
    }
    public class TotalesPedido
    {
        public decimal SubTotal { get; set; }
        public decimal ITBIS { get; set; }
        public decimal Total { get; set; }
    }
    public class ListaPedidos
    {
        public int Id { get; set; }
        public string Proveedor { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public decimal SubTotal { get; set; }
        public decimal ITBIS { get; set; }
        public decimal Total { get; set; }
    }
    public class FacturaPedido
    {
        public EncabezadoPedido encabezado { get; set; }
        public List<TotalesPedido> totales { get; set; }
        public List<DetallePedidosRows> detalle { get; set; }
    }
}