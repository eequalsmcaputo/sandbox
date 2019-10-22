namespace FacebookClone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOnlineUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OnlineUsers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ConnId = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OnlineUsers", "Id", "dbo.Users");
            DropIndex("dbo.OnlineUsers", new[] { "Id" });
            DropTable("dbo.OnlineUsers");
        }
    }
}
