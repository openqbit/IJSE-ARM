namespace IJSE.ARM.DataAccess.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class provincemodelupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Province", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Province", "Name");
        }
    }
}
