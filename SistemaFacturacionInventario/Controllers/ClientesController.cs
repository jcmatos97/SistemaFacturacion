using SistemaFacturacionInventario.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaFacturacionInventario.Controllers
{
    public class ClientesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetClientes()
        {
            var data = db.Cliente.ToList();

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getClientesById(int id)
        {

            var data = db.Cliente.ToList().Find(x => x.Id == id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        //Crear Proveedor
        public ActionResult CrearCliente([Bind(Exclude = "Id")] Cliente Cliente)
        {
            if (ModelState.IsValid)
            {
                db.Cliente.Add(Cliente);
                db.SaveChanges();
            }

            return Json(Cliente, JsonRequestBehavior.AllowGet);
        }

        //Actualizar Proveedor
        public ActionResult ActualizarClientes(Cliente Cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Cliente).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(Cliente, JsonRequestBehavior.AllowGet);
        }
    }
}