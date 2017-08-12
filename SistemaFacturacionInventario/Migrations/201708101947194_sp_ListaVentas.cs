namespace SistemaFacturacionInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sp_ListaVentas : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("sp_ListaVentas", @"select fa.Id, cl.Nombre+' '+cl.Apellido as 'Cliente',u.Nombre+' '+u.Apellido as 'Nombre', fa.Fecha as 'Fecha', sum(df.SubTotal) as 'SubTotal', sum(df.ITBIS) as 'ITBIS', sum(df.TotalDetalle) as 'Total' from DetalleFacturas df inner join Facturas fa on df.FacturaID = fa.Id inner join AspNetUsers u on fa.UsuarioID = u.Id inner join Clientes cl on fa.ClienteID = cl.Id group by df.FacturaID, fa.Fecha, u.Nombre, u.Apellido, cl.Nombre, cl.Apellido, fa.Id");
        }
        
        public override void Down()
        {
        }
    }
}
