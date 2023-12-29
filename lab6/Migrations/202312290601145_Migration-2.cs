namespace lab6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Weathers", "CityWeather_id", c => c.Int());
            CreateIndex("dbo.Weathers", "CityWeather_id");
            AddForeignKey("dbo.Weathers", "CityWeather_id", "dbo.Cities", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Weathers", "CityWeather_id", "dbo.Cities");
            DropIndex("dbo.Weathers", new[] { "CityWeather_id" });
            DropColumn("dbo.Weathers", "CityWeather_id");
            DropTable("dbo.Cities");
        }
    }
}
