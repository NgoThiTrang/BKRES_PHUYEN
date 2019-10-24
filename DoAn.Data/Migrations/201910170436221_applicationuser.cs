namespace DoAn.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class applicationuser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUsers", "Gender", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationUsers", "Gender");
        }
    }
}
