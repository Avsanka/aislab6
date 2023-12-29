namespace lab6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Weathers", "Stations", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Weathers", "Stations");
        }
    }
}
