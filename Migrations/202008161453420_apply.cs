namespace lsad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class apply : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SepeteEkles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhoneNumber = c.String(),
                        Adress = c.String(),
                        OrderDate = c.DateTime(nullable: false),
                        ProductId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.ProductId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SepeteEkles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.SepeteEkles", "ProductId", "dbo.Products");
            DropIndex("dbo.SepeteEkles", new[] { "UserId" });
            DropIndex("dbo.SepeteEkles", new[] { "ProductId" });
            DropTable("dbo.SepeteEkles");
        }
    }
}
