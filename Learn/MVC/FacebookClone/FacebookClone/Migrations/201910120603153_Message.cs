namespace FacebookClone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Message : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        From = c.Int(nullable: false),
                        To = c.Int(nullable: false),
                        MessageText = c.String(),
                        DateSent = c.DateTime(nullable: false),
                        Read = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.From, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.To, cascadeDelete: false)
                .Index(t => t.From)
                .Index(t => t.To);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "To", "dbo.Users");
            DropForeignKey("dbo.Messages", "From", "dbo.Users");
            DropIndex("dbo.Messages", new[] { "To" });
            DropIndex("dbo.Messages", new[] { "From" });
            DropTable("dbo.Messages");
        }
    }
}
