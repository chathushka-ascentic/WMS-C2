namespace Ascentic.WorkFlow.EndSystems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Task", "AgreedCompletionDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Task", "ActualCompletionDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Task", "CreatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropColumn("dbo.Task", "Remark");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Task", "Remark", c => c.String());
            AlterColumn("dbo.Task", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Task", "ActualCompletionDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Task", "AgreedCompletionDate", c => c.DateTime(nullable: false));
        }
    }
}
