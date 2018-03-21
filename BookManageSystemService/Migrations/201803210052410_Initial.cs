namespace BookManageSystemService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ManageUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sign = c.String(),
                        AccountNumber = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ManageUsers");
        }
    }
}
