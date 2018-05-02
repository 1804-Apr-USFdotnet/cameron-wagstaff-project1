using System.Data.Entity.Migrations;

namespace ReviewSiteData.Migrations
{
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Restaurants",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                    "dbo.Reviews",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String(),
                        Title = c.String(),
                        Body = c.String(),
                        Rating = c.Int(false),
                        Restaurant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_Id)
                .Index(t => t.Restaurant_Id);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "Restaurant_Id", "dbo.Restaurants");
            DropIndex("dbo.Reviews", new[] {"Restaurant_Id"});
            DropTable("dbo.Reviews");
            DropTable("dbo.Restaurants");
        }
    }
}