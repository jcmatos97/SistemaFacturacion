using SistemaFacturacionInventario.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaFacturacionInventario.Controllers
{
    public class ProveedorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetProveedores()
        {
            var data = db.Proveedor.ToList();

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetProveedoresById(int id)
        {
           
            var data = db.Proveedor.ToList().Find(x => x.Id == id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        
        //Crear Proveedor
        public ActionResult CrearProveedor([Bind(Exclude = "Id")] Proveedor Proveedor)
        {
            if (ModelState.IsValid)
            {
                db.Proveedor.Add(Proveedor);
                db.SaveChanges();
            }

            return Json(Proveedor, JsonRequestBehavior.AllowGet);
        }
        
        //Actualizar Proveedor
        public ActionResult ActualizarProveedor(Proveedor Proveedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Proveedor).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(Proveedor, JsonRequestBehavior.AllowGet);
        }

    }
}