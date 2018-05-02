using System.Data.Entity.Migrations;

namespace ReviewSiteData.Migrations
{
    public partial class AddReviewTimestamp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "DatePublished", c => c.DateTime(false));
        }

        public override void Down()
        {
            DropColumn("dbo.Reviews", "DatePublished");
        }
    }
}