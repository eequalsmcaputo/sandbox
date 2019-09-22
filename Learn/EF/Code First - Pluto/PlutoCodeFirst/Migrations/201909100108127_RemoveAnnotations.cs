namespace PlutoCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Name", c => c.String());
            AlterColumn("dbo.Courses", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "Description", c => c.String(nullable: false, maxLength: 2000));
            AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
