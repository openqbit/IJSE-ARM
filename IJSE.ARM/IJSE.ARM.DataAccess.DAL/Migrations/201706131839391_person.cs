namespace IJSE.ARM.DataAccess.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class person : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Person", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Person", "Name");
        }
    }
}
