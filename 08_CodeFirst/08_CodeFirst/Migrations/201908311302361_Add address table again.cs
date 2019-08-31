namespace _08_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addaddresstableagain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "MyProperty", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "Surname", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Surname", c => c.String());
            DropColumn("dbo.Users", "MyProperty");
            DropTable("dbo.Addresses");
        }
    }
}
