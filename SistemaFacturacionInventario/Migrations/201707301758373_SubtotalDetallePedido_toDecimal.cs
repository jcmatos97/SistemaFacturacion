namespace SistemaFacturacionInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubtotalDetallePedido_toDecimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DetallePedidoes", "SubTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DetallePedidoes", "SubTotal", c => c.Int(nullable: false));
        }
    }
}
