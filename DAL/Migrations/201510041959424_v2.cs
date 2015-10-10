namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Comments", name: "Subject_SubjectID", newName: "SubjectID");
            RenameColumn(table: "dbo.Comments", name: "User_Id", newName: "UserID");
            RenameIndex(table: "dbo.Comments", name: "IX_User_Id", newName: "IX_UserID");
            RenameIndex(table: "dbo.Comments", name: "IX_Subject_SubjectID", newName: "IX_SubjectID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Comments", name: "IX_SubjectID", newName: "IX_Subject_SubjectID");
            RenameIndex(table: "dbo.Comments", name: "IX_UserID", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Comments", name: "UserID", newName: "User_Id");
            RenameColumn(table: "dbo.Comments", name: "SubjectID", newName: "Subject_SubjectID");
        }
    }
}
