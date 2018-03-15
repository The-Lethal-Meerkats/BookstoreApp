namespace BookstoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFKfortherestofthemodels : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Books", new[] { "AuthorID" });
            DropIndex("dbo.Books", new[] { "CategoryID" });
            DropIndex("dbo.Orders", new[] { "OrderStatusID" });
            DropIndex("dbo.Wishlists", new[] { "UserID" });
            CreateIndex("dbo.Books", "AuthorId");
            CreateIndex("dbo.Books", "CategoryId");
            CreateIndex("dbo.Orders", "OrderStatusId");
            CreateIndex("dbo.Wishlists", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Wishlists", new[] { "UserId" });
            DropIndex("dbo.Orders", new[] { "OrderStatusId" });
            DropIndex("dbo.Books", new[] { "CategoryId" });
            DropIndex("dbo.Books", new[] { "AuthorId" });
            CreateIndex("dbo.Wishlists", "UserID");
            CreateIndex("dbo.Orders", "OrderStatusID");
            CreateIndex("dbo.Books", "CategoryID");
            CreateIndex("dbo.Books", "AuthorID");
        }
    }
}
