namespace FacebookClone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Friends : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Friends",
                c => new
                    {
                        UserId1 = c.Int(nullable: false),
                        UserId2 = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId1, t.UserId2 })
                .ForeignKey("dbo.Users", t => t.UserId1, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UserId2, cascadeDelete: false)
                .Index(t => t.UserId1)
                .Index(t => t.UserId2);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Friends", "UserId2", "dbo.Users");
            DropForeignKey("dbo.Friends", "UserId1", "dbo.Users");
            DropIndex("dbo.Friends", new[] { "UserId2" });
            DropIndex("dbo.Friends", new[] { "UserId1" });
            DropTable("dbo.Friends");
        }
    }
}
