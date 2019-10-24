namespace DoAn.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateWarningProfilProperty : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WarningProfile", "Name", c => c.String(nullable: false, maxLength: 50, unicode: false));
            DropColumn("dbo.WarningProfile", "PropertiesName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WarningProfile", "PropertiesName", c => c.String(maxLength: 30, unicode: false));
            AlterColumn("dbo.WarningProfile", "Name", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
