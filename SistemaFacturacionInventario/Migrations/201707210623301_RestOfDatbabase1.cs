namespace SistemaFacturacionInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestOfDatbabase1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Facturas", "UsuarioID", c => c.String());
            AlterColumn("dbo.Pedidoes", "UsuarioID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pedidoes", "UsuarioID", c => c.Int(nullable: false));
            AlterColumn("dbo.Facturas", "UsuarioID", c => c.Int(nullable: false));
        }
    }
}
