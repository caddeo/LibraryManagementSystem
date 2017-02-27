namespace LMSService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Loans",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        From = c.DateTime(nullable: false),
                        To = c.DateTime(nullable: false),
                        Book_Id = c.Guid(),
                        Renter_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.Book_Id)
                .ForeignKey("dbo.Renters", t => t.Renter_Id)
                .Index(t => t.Book_Id)
                .Index(t => t.Renter_Id);
            
            CreateTable(
                "dbo.Renters",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Books", "IsLendOut", c => c.Boolean(nullable: false));
            AddColumn("dbo.Reservations", "Renter_Id", c => c.Guid());
            CreateIndex("dbo.Reservations", "Renter_Id");
            AddForeignKey("dbo.Reservations", "Renter_Id", "dbo.Renters", "Id");
            DropColumn("dbo.Books", "IsReserved");
            DropColumn("dbo.Reservations", "PersonDetails");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "PersonDetails", c => c.String());
            AddColumn("dbo.Books", "IsReserved", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Reservations", "Renter_Id", "dbo.Renters");
            DropForeignKey("dbo.Loans", "Renter_Id", "dbo.Renters");
            DropForeignKey("dbo.Loans", "Book_Id", "dbo.Books");
            DropIndex("dbo.Reservations", new[] { "Renter_Id" });
            DropIndex("dbo.Loans", new[] { "Renter_Id" });
            DropIndex("dbo.Loans", new[] { "Book_Id" });
            DropColumn("dbo.Reservations", "Renter_Id");
            DropColumn("dbo.Books", "IsLendOut");
            DropTable("dbo.Renters");
            DropTable("dbo.Loans");
        }
    }
}
