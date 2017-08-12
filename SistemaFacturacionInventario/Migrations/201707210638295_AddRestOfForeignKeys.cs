namespace SistemaFacturacionInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRestOfForeignKeys : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE Facturas ADD FOREIGN KEY (UsuarioID) REFERENCES AspNetUsers(Id) ALTER TABLE Pedidoes ADD FOREIGN KEY(UsuarioID) REFERENCES AspNetUsers(Id)");
        }
        
        public override void Down()
        {
        }
    }
}
