namespace BookManageSystemService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BusinessOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        ReaderUserId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                        BusinessState = c.String(),
                        OrderState = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.ReaderUsers", t => t.ReaderUserId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.ReaderUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BusinessOrders", "ReaderUserId", "dbo.ReaderUsers");
            DropForeignKey("dbo.BusinessOrders", "BookId", "dbo.Books");
            DropIndex("dbo.BusinessOrders", new[] { "ReaderUserId" });
            DropIndex("dbo.BusinessOrders", new[] { "BookId" });
            DropTable("dbo.BusinessOrders");
        }
    }
}
