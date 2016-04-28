namespace YayOrNay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Movies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Description", c => c.String(maxLength: 1000));
            DropColumn("dbo.Movies", "Decription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Decription", c => c.String(maxLength: 1000));
            DropColumn("dbo.Movies", "Description");
        }
    }
}
