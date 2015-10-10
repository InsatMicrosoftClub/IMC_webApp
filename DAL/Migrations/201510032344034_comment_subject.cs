namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comment_subject : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Date = c.DateTime(nullable: false),
                        Member_Id = c.String(maxLength: 128),
                        Subject_SubjectID = c.Int(),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.AspNetUsers", t => t.Member_Id)
                .ForeignKey("dbo.Subjects", t => t.Subject_SubjectID)
                .Index(t => t.Member_Id)
                .Index(t => t.Subject_SubjectID);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.SubjectID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Subject_SubjectID", "dbo.Subjects");
            DropForeignKey("dbo.Comments", "Member_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Comments", new[] { "Subject_SubjectID" });
            DropIndex("dbo.Comments", new[] { "Member_Id" });
            DropTable("dbo.Subjects");
            DropTable("dbo.Comments");
        }
    }
}
