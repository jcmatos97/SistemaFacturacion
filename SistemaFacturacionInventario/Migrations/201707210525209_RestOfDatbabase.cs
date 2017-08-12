namespace SistemaFacturacionInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestOfDatbabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Cedula = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        UsuarioID = c.Int(nullable: false),
                        ClienteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.ClienteID, cascadeDelete: true)
                .Index(t => t.ClienteID);
            
            CreateTable(
                "dbo.DetalleFacturas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FacturaID = c.Int(nullable: false),
                        ProductoID = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        PrecioUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubTotal = c.Int(nullable: false),
                        ITBIS = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalDetalle = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Facturas", t => t.FacturaID, cascadeDelete: true)
                .ForeignKey("dbo.Productoes", t => t.ProductoID, cascadeDelete: true)
                .Index(t => t.FacturaID)
                .Index(t => t.ProductoID);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Existencia = c.Int(nullable: false),
                        Precio = c.String(),
                        Foto = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DetallePedidoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PedidoId = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        PrecioUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubTotal = c.Int(nullable: false),
                        ITBIS = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalDetalle = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pedidoes", t => t.PedidoId, cascadeDelete: true)
                .ForeignKey("dbo.Productoes", t => t.ProductoId, cascadeDelete: true)
                .Index(t => t.PedidoId)
                .Index(t => t.ProductoId);
            
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        UsuarioID = c.Int(nullable: false),
                        ProveedorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Proveedors", t => t.ProveedorId, cascadeDelete: true)
                .Index(t => t.ProveedorId);
            
            CreateTable(
                "dbo.Proveedors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreProveedor = c.String(),
                        Telefono = c.String(),
                        Direccion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetallePedidoes", "ProductoId", "dbo.Productoes");
            DropForeignKey("dbo.Pedidoes", "ProveedorId", "dbo.Proveedors");
            DropForeignKey("dbo.DetallePedidoes", "PedidoId", "dbo.Pedidoes");
            DropForeignKey("dbo.DetalleFacturas", "ProductoID", "dbo.Productoes");
            DropForeignKey("dbo.DetalleFacturas", "FacturaID", "dbo.Facturas");
            DropForeignKey("dbo.Facturas", "ClienteID", "dbo.Clientes");
            DropIndex("dbo.Pedidoes", new[] { "ProveedorId" });
            DropIndex("dbo.DetallePedidoes", new[] { "ProductoId" });
            DropIndex("dbo.DetallePedidoes", new[] { "PedidoId" });
            DropIndex("dbo.DetalleFacturas", new[] { "ProductoID" });
            DropIndex("dbo.DetalleFacturas", new[] { "FacturaID" });
            DropIndex("dbo.Facturas", new[] { "ClienteID" });
            DropTable("dbo.Proveedors");
            DropTable("dbo.Pedidoes");
            DropTable("dbo.DetallePedidoes");
            DropTable("dbo.Productoes");
            DropTable("dbo.DetalleFacturas");
            DropTable("dbo.Facturas");
            DropTable("dbo.Clientes");
        }
    }
}
