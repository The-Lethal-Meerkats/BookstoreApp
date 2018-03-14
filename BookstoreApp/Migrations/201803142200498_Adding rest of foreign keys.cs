namespace BookstoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addingrestofforeignkeys : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropIndex("dbo.Books", new[] { "CategoryId" });
            CreateIndex("dbo.Books", "AuthorID");
            CreateIndex("dbo.Books", "CategoryID");
            CreateIndex("dbo.Orders", "OrderStatusID");
            CreateIndex("dbo.Wishlists", "UserID");
            AddForeignKey("dbo.Orders", "OrderStatusID", "dbo.OrderStatus", "OrderStatusId", cascadeDelete: true);
            AddForeignKey("dbo.Wishlists", "UserID", "dbo.Users", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Wishlists", "UserID", "dbo.Users");
            DropForeignKey("dbo.Orders", "OrderStatusID", "dbo.OrderStatus");
            DropIndex("dbo.Wishlists", new[] { "UserID" });
            DropIndex("dbo.Orders", new[] { "OrderStatusID" });
            DropIndex("dbo.Books", new[] { "CategoryID" });
            DropIndex("dbo.Books", new[] { "AuthorID" });
            CreateIndex("dbo.Books", "CategoryId");
            CreateIndex("dbo.Books", "AuthorId");
        }
    }
}
