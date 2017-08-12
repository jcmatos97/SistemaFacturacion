namespace SistemaFacturacionInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProceduresFactura : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("sp_DetalleVentaRows", x => new { VentaId = x.Int() }, @"select dp.Id as 'id_detalleVenta', p.Nombre as 'Producto', dp.Cantidad, dp.PrecioUnitario, dp.SubTotal, dp.ITBIS, dp.TotalDetalle from DetalleFacturas dp inner join Productoes p on dp.ProductoId=p.Id where dp.FacturaID = @VentaId");
            CreateStoredProcedure("sp_DetalleVentaTotales", x => new { VentaId = x.Int() }, @"select SUM(dp.SubTotal) as 'SubTotal', SUM(dp.ITBIS) as 'ITBIS', SUM(dp.TotalDetalle) as 'Total' from DetalleFacturas dp where dp.FacturaID = @VentaId group by(dp.FacturaID)");

        }

        public override void Down()
        {
        }
    }
}
