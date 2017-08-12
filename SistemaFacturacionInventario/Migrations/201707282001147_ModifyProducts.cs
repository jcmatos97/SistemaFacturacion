namespace SistemaFacturacionInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyProducts : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Productoes", "Precio", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateStoredProcedure("sp_ModifyProducts", x => new { id = x.Int(), nombre = x.String(), precio = x.Decimal(), limite = x.Int() }, @"UPDATE dbo.Productoes SET Nombre = @nombre, Precio = @precio, LimiteExistencia = @limite WHERE Id = @id");
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Productoes", "Precio", c => c.String());
        }
    }
}
