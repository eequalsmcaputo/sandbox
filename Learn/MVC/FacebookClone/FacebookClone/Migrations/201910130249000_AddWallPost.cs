namespace FacebookClone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWallPost : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WallPosts",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        MessageText = c.String(),
                        DateEdited = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WallPosts", "Id", "dbo.Users");
            DropIndex("dbo.WallPosts", new[] { "Id" });
            DropTable("dbo.WallPosts");
        }
    }
}
