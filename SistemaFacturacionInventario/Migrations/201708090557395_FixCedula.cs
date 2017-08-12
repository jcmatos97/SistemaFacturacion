namespace SistemaFacturacionInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixCedula : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clientes", "Telefono", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clientes", "Telefono", c => c.Int(nullable: false));
        }
    }
}
