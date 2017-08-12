namespace SistemaFacturacionInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClienteTableUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "Telefono", c => c.Int(nullable: false));
            AddColumn("dbo.Clientes", "email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clientes", "email");
            DropColumn("dbo.Clientes", "Telefono");
        }
    }
}
