namespace SistemaFacturacionInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MismoTipoFK : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Facturas", "UsuarioID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Pedidoes", "UsuarioID", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pedidoes", "UsuarioID", c => c.String());
            AlterColumn("dbo.Facturas", "UsuarioID", c => c.String());
        }
    }
}
