namespace SistemaFacturacionInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DisponibilidadProducto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productoes", "Disponibilidad", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Productoes", "Disponibilidad");
        }
    }
}
