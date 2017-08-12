namespace SistemaFacturacionInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablaITBIS : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ITBIS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ITBIS");
        }
    }
}
