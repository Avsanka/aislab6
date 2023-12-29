namespace lab6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Weathers", "CityWeather_id", "dbo.Cities");
            DropIndex("dbo.Weathers", new[] { "CityWeather_id" });
            CreateTable(
                "dbo.Histories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Weathers", "Hs_id", c => c.Int());
            CreateIndex("dbo.Weathers", "Hs_id");
            AddForeignKey("dbo.Weathers", "Hs_id", "dbo.Histories", "id");
            DropColumn("dbo.Weathers", "CityWeather_id");
            DropTable("dbo.Cities");
        }
        
        public override void Down()
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
            DropForeignKey("dbo.Weathers", "Hs_id", "dbo.Histories");
            DropIndex("dbo.Weathers", new[] { "Hs_id" });
            DropColumn("dbo.Weathers", "Hs_id");
            DropTable("dbo.Histories");
            CreateIndex("dbo.Weathers", "CityWeather_id");
            AddForeignKey("dbo.Weathers", "CityWeather_id", "dbo.Cities", "id");
        }
    }
}
