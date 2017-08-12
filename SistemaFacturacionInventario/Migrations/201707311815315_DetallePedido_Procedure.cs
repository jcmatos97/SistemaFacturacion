namespace SistemaFacturacionInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DetallePedido_Procedure : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("sp_DetallePedidoRows", x => new { PedidoId = x.Int() }, @"select dp.ProductoId, dp.Cantidad, dp.PrecioUnitario, dp.SubTotal, dp.ITBIS, dp.TotalDetalle from DetallePedidoes dp where dp.PedidoId = @PedidoId");
            CreateStoredProcedure("sp_DetallePedidoTotales", x => new { PedidoId = x.Int() }, @"select SUM(dp.SubTotal) as 'SubTotal', SUM(dp.ITBIS) as 'ITBIS', SUM(dp.TotalDetalle) as 'Total' from DetallePedidoes dp where dp.PedidoId = @PedidoId group by(dp.PedidoId)");

        }

        public override void Down()
        {
        }
    }
}
