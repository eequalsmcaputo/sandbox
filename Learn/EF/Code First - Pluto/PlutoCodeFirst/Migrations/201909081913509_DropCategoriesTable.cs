namespace PlutoCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropCategoriesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo._Categories",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);
            Sql("insert into _Categories (Name) select Name from Categories");
            DropTable("dbo.Categories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            Sql("insert into Categories (Name) select Name from _Categories");
            DropTable("dbo._Categories");
        }
    }
}
