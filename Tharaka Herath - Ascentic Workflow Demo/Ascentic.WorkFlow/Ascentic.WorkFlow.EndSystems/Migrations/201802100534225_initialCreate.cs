namespace Ascentic.WorkFlow.EndSystems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Task",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Assignee = c.String(),
                        AssignedBy = c.String(),
                        Remark = c.String(),
                        Status = c.String(),
                        AgreedCompletionDate = c.DateTime(nullable: false),
                        ActualCompletionDate = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TaskId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Task");
        }
    }
}
