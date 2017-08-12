namespace SistemaFacturacionInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ListaPedidos : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("sp_ListaPedidos", @"select pe.Id, NombreProveedor as 'Proveedor',u.Nombre+' '+u.Apellido as 'Nombre',pe.Fecha as 'Fecha', sum(dp.SubTotal) as 'SubTotal', sum(dp.ITBIS) as 'ITBIS',sum(dp.TotalDetalle) as 'Total' from detallePedidoes dp inner join Pedidoes pe on dp.PedidoId= pe.Id inner join AspNetUsers u on pe.UsuarioID = u.Id inner join Proveedors pr on pe.ProveedorId = pr.Id group by dp.PedidoId, pe.Fecha, u.Nombre, u.Apellido, pr.NombreProveedor, pe.Id");
        }

        public override void Down()
        {
        }
    }
}
