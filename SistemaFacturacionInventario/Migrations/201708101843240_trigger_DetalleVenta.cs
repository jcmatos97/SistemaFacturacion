namespace SistemaFacturacionInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class trigger_DetalleVenta : DbMigration
    {
        public override void Up()
        {
            Sql("CREATE TRIGGER [dbo].[Tr_ActualizarInventarioVenta] on [dbo].[DetalleFacturas] after insert, delete as begin declare @product_id_inserted int declare @product_id_deleted int declare @existencia int declare @cantidad int set @product_id_inserted = (select ProductoId from inserted) set @product_id_deleted = (select ProductoId from deleted) if @product_id_inserted is not null begin set @existencia = (select Existencia from Productoes where Id = @product_id_inserted) set @cantidad = (select Cantidad from inserted) UPDATE Productoes SET Existencia = @existencia-@cantidad WHERE Id = @product_id_inserted end else if @product_id_deleted is not null begin set @existencia = (select Existencia from Productoes where Id = @product_id_deleted) set @cantidad = (select Cantidad from deleted) UPDATE Productoes SET Existencia = @existencia+@cantidad WHERE Id = @product_id_deleted end end");
        }
        
        public override void Down()
        {
        }
    }
}
