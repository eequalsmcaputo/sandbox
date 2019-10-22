namespace FacebookClone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "NameFirst", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Users", "NameLast", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.String(maxLength: 100));
            AlterColumn("dbo.Users", "Username", c => c.String(maxLength: 100));
            AlterColumn("dbo.Users", "Email", c => c.String(maxLength: 255));
            AlterColumn("dbo.Users", "NameLast", c => c.String(maxLength: 255));
            AlterColumn("dbo.Users", "NameFirst", c => c.String(maxLength: 255));
        }
    }
}
