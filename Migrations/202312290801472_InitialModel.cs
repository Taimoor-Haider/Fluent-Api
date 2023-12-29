namespace FluentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Courses", new[] { "Author_Id" });
            RenameColumn(table: "dbo.Courses", name: "Author_Id", newName: "AuthorID");
            DropPrimaryKey("dbo.TagCourses");
            CreateTable(
                "dbo.Covers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Id)
                .Index(t => t.Id);
            
            AlterColumn("dbo.Courses", "Title", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Courses", "Description", c => c.String(nullable: false, maxLength: 2000));
            AlterColumn("dbo.Courses", "AuthorID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.TagCourses", new[] { "Course_Id", "Tag_Id" });
            CreateIndex("dbo.Courses", "AuthorID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Covers", "Id", "dbo.Courses");
            DropIndex("dbo.Covers", new[] { "Id" });
            DropIndex("dbo.Courses", new[] { "AuthorID" });
            DropPrimaryKey("dbo.TagCourses");
            AlterColumn("dbo.Courses", "AuthorID", c => c.Int());
            AlterColumn("dbo.Courses", "Description", c => c.String());
            AlterColumn("dbo.Courses", "Title", c => c.String());
            DropTable("dbo.Covers");
            AddPrimaryKey("dbo.TagCourses", new[] { "Tag_Id", "Course_Id" });
            RenameColumn(table: "dbo.Courses", name: "AuthorID", newName: "Author_Id");
            CreateIndex("dbo.Courses", "Author_Id");
        }
    }
}
