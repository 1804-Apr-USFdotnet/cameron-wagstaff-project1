using System.Data.Entity.Migrations;

namespace ReviewSiteData.Migrations
{

    public partial class RestIDtoReview : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reviews", "Restaurant_Id", "dbo.Restaurants");
            DropIndex("dbo.Reviews", new[] { "Restaurant_Id" });
            RenameColumn("dbo.Reviews", "Restaurant_Id", "RestaurantId");
            AlterColumn("dbo.Reviews", "RestaurantId", c => c.Int(false));
            CreateIndex("dbo.Reviews", "RestaurantId");
            AddForeignKey("dbo.Reviews", "RestaurantId", "dbo.Restaurants", "Id", true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "RestaurantId", "dbo.Restaurants");
            DropIndex("dbo.Reviews", new[] { "RestaurantId" });
            AlterColumn("dbo.Reviews", "RestaurantId", c => c.Int());
            RenameColumn("dbo.Reviews", "RestaurantId", "Restaurant_Id");
            CreateIndex("dbo.Reviews", "Restaurant_Id");
            AddForeignKey("dbo.Reviews", "Restaurant_Id", "dbo.Restaurants", "Id");
        }
    }
}
