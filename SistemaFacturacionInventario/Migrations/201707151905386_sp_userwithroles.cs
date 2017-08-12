namespace SistemaFacturacionInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sp_userwithroles : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("GetUserAndRoles", "select users.UserName as Username, users.Nombre as Nombre, users.Apellido as Apellido, users.Foto as Foto, roles.Name as [Role] from AspNetUsers users inner join AspNetUserRoles usersroles on users.Id = usersroles.UserId inner join AspNetRoles roles on usersroles.RoleId = roles.Id");
        }
        
        public override void Down()
        {
        }
    }
}
