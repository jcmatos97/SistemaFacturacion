namespace SistemaFacturacionInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DetalleFacturas", "SubTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DetalleFacturas", "SubTotal", c => c.Int(nullable: false));
        }
    }
}
