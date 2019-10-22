namespace FacebookClone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProfileImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "ProfileImage", c => c.Binary(storeType: "image"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "ProfileImage");
        }
    }
}
