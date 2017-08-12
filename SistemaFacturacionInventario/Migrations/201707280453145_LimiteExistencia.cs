namespace SistemaFacturacionInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LimiteExistencia : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productoes", "LimiteExistencia", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Productoes", "LimiteExistencia");
        }
    }
}
