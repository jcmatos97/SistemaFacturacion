namespace SistemaFacturacionInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_trigger : DbMigration
    {
        public override void Up()
        {
            Sql("CREATE TRIGGER Tr_AsignarRol on AspNetUsers after insert as begin declare @user_id nvarchar(50) set @user_id = (select id from inserted) Insert into AspNetUserRoles(UserId, RoleId) values(@user_id, '2') end");
        }
        
        public override void Down()
        {
        }
    }
}
