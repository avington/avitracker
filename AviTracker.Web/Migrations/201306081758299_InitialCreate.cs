namespace AviTracker.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        ClientName = c.String(),
                        ContactName = c.String(),
                        EmailAddress = c.String(),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(),
                        Description = c.String(),
                        Client_ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.Clients", t => t.Client_ClientId, cascadeDelete: true)
                .Index(t => t.Client_ClientId);
            
            CreateTable(
                "dbo.ProjectTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaskName = c.String(),
                        Rate = c.Decimal(precision: 18, scale: 2),
                        Hours = c.Decimal(precision: 18, scale: 2),
                        StartDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(),
                        CodeRevisionNumber = c.String(),
                        Project_ProjectId = c.Int(),
                        TaskType_TaskTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.Project_ProjectId)
                .ForeignKey("dbo.TaskTypes", t => t.TaskType_TaskTypeId)
                .Index(t => t.Project_ProjectId)
                .Index(t => t.TaskType_TaskTypeId);
            
            CreateTable(
                "dbo.TaskTypes",
                c => new
                    {
                        TaskTypeId = c.Int(nullable: false, identity: true),
                        TaskTypeName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.TaskTypeId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ProjectTasks", new[] { "TaskType_TaskTypeId" });
            DropIndex("dbo.ProjectTasks", new[] { "Project_ProjectId" });
            DropIndex("dbo.Projects", new[] { "Client_ClientId" });
            DropForeignKey("dbo.ProjectTasks", "TaskType_TaskTypeId", "dbo.TaskTypes");
            DropForeignKey("dbo.ProjectTasks", "Project_ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Projects", "Client_ClientId", "dbo.Clients");
            DropTable("dbo.TaskTypes");
            DropTable("dbo.ProjectTasks");
            DropTable("dbo.Projects");
            DropTable("dbo.Clients");
        }
    }
}
