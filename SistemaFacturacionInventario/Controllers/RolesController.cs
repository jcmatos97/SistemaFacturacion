using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaFacturacionInventario.Models;
using SistemaFacturacionInventario.ViewModels;
using System.Data.SqlClient;

namespace SistemaFacturacionInventario.Controllers
{
    public class RolesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Roles
        public ActionResult Configurar()
        {
            if (User.IsInRole("Administrador"))
            {
            var query = db.Database.SqlQuery<UserRoles>("GetUserAndRoles");
            return View(query.ToList());
            }
            else
            {
                return RedirectToAction("index", "home");
            }

        }
        public ActionResult Actualizar(ModifyRole v)
        {
            db.Database.ExecuteSqlCommand("EXEC sp_ModifyRoles @Rol, @Username", new SqlParameter("@Rol",v.Rol), new SqlParameter("@Username",v.Username));
            return RedirectToAction("Configurar", "Roles");
        }
    }
}