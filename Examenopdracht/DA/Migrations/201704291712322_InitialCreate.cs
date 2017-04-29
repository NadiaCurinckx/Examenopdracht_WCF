namespace DA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Boeken",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titel = c.String(),
                        Auteur = c.String(),
                        AantalPaginas = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Omschrijving = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GenreBoeks",
                c => new
                    {
                        Genre_Id = c.Int(nullable: false),
                        Boek_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genre_Id, t.Boek_Id })
                .ForeignKey("dbo.Genres", t => t.Genre_Id, cascadeDelete: true)
                .ForeignKey("dbo.Boeken", t => t.Boek_Id, cascadeDelete: true)
                .Index(t => t.Genre_Id)
                .Index(t => t.Boek_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GenreBoeks", "Boek_Id", "dbo.Boeken");
            DropForeignKey("dbo.GenreBoeks", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.GenreBoeks", new[] { "Boek_Id" });
            DropIndex("dbo.GenreBoeks", new[] { "Genre_Id" });
            DropTable("dbo.GenreBoeks");
            DropTable("dbo.Genres");
            DropTable("dbo.Boeken");
        }
    }
}
