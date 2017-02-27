namespace LMSService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Author = c.String(),
                        Publisher = c.String(),
                        Pages = c.Int(nullable: false),
                        OriginalTitle = c.String(),
                        ISBN = c.String(),
                        Genre = c.String(),
                        PictureURL = c.String(),
                        IsReserved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PersonDetails = c.String(),
                        Book_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.Book_Id)
                .Index(t => t.Book_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "Book_Id", "dbo.Books");
            DropIndex("dbo.Reservations", new[] { "Book_Id" });
            DropTable("dbo.Reservations");
            DropTable("dbo.Books");
        }
    }
}
