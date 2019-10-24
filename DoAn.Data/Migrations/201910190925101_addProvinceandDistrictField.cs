namespace DoAn.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProvinceandDistrictField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUsers", "ProvinceId", c => c.Int());
            AddColumn("dbo.ApplicationUsers", "DisctrictId", c => c.Int());
            CreateIndex("dbo.ApplicationUsers", "ProvinceId");
            CreateIndex("dbo.ApplicationUsers", "DisctrictId");
            AddForeignKey("dbo.ApplicationUsers", "DisctrictId", "dbo.District", "Id");
            AddForeignKey("dbo.ApplicationUsers", "ProvinceId", "dbo.Province", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUsers", "ProvinceId", "dbo.Province");
            DropForeignKey("dbo.ApplicationUsers", "DisctrictId", "dbo.District");
            DropIndex("dbo.ApplicationUsers", new[] { "DisctrictId" });
            DropIndex("dbo.ApplicationUsers", new[] { "ProvinceId" });
            DropColumn("dbo.ApplicationUsers", "DisctrictId");
            DropColumn("dbo.ApplicationUsers", "ProvinceId");
        }
    }
}
