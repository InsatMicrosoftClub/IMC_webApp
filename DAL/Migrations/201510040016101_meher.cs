namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class meher : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Comments", name: "Member_Id", newName: "User_Id");
            RenameIndex(table: "dbo.Comments", name: "IX_Member_Id", newName: "IX_User_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Comments", name: "IX_User_Id", newName: "IX_Member_Id");
            RenameColumn(table: "dbo.Comments", name: "User_Id", newName: "Member_Id");
        }
    }
}
