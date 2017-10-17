namespace CAEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "DateR", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "DateR");
        }
    }
}
