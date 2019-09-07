namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GenreName = c.String(),
                        Color = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SongName = c.String(nullable: false),
                        GenreId = c.Int(nullable: false),
                        SingerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .ForeignKey("dbo.Singers", t => t.SingerId, cascadeDelete: true)
                .Index(t => t.GenreId)
                .Index(t => t.SingerId);
            
            CreateTable(
                "dbo.Singers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UrlInfo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserSongs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        SongId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Songs", t => t.SongId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.SongId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserSongs", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserSongs", "SongId", "dbo.Songs");
            DropForeignKey("dbo.Songs", "SingerId", "dbo.Singers");
            DropForeignKey("dbo.Songs", "GenreId", "dbo.Genres");
            DropIndex("dbo.UserSongs", new[] { "SongId" });
            DropIndex("dbo.UserSongs", new[] { "UserId" });
            DropIndex("dbo.Songs", new[] { "SingerId" });
            DropIndex("dbo.Songs", new[] { "GenreId" });
            DropTable("dbo.Users");
            DropTable("dbo.UserSongs");
            DropTable("dbo.Singers");
            DropTable("dbo.Songs");
            DropTable("dbo.Genres");
        }
    }
}
