namespace SistemaFacturacionInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyRoles : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("sp_ModifyRoles",x => new { Role = x.String(), Username = x.String() }, @"UPDATE R SET R.RoleId = @Role FROM dbo.AspNetUserRoles AS R INNER JOIN dbo.AspNetUsers AS P ON r.UserId = p.Id WHERE p.UserName = @Username");
        }
        
        public override void Down()
        {
        }
    }
}
