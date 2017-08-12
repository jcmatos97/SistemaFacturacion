namespace SistemaFacturacionInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NombreUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "NombreUsuario", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "NombreUsuario");
        }
    }
}
