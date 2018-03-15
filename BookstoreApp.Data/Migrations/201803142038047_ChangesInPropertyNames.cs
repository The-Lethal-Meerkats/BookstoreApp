namespace BookstoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesInPropertyNames : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Books", new[] { "AuthorID" });
            DropIndex("dbo.Books", new[] { "CategoryID" });
            DropIndex("dbo.ShoppingCarts", new[] { "ShoppingCartStatusID" });
            DropIndex("dbo.OrderBooks", new[] { "Order_OrderID" });
            DropIndex("dbo.OrderBooks", new[] { "Book_BookID" });
            DropIndex("dbo.ShoppingCartBooks", new[] { "ShoppingCart_ShoppingCartID" });
            DropIndex("dbo.ShoppingCartBooks", new[] { "Book_BookID" });
            DropIndex("dbo.WishlistBooks", new[] { "Book_BookID" });
            CreateIndex("dbo.Books", "AuthorId");
            CreateIndex("dbo.Books", "CategoryId");
            CreateIndex("dbo.ShoppingCarts", "ShoppingCartStatusId");
            CreateIndex("dbo.OrderBooks", "Order_OrderId");
            CreateIndex("dbo.OrderBooks", "Book_BookId");
            CreateIndex("dbo.ShoppingCartBooks", "ShoppingCart_ShoppingCartId");
            CreateIndex("dbo.ShoppingCartBooks", "Book_BookId");
            CreateIndex("dbo.WishlistBooks", "Book_BookId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.WishlistBooks", new[] { "Book_BookId" });
            DropIndex("dbo.ShoppingCartBooks", new[] { "Book_BookId" });
            DropIndex("dbo.ShoppingCartBooks", new[] { "ShoppingCart_ShoppingCartId" });
            DropIndex("dbo.OrderBooks", new[] { "Book_BookId" });
            DropIndex("dbo.OrderBooks", new[] { "Order_OrderId" });
            DropIndex("dbo.ShoppingCarts", new[] { "ShoppingCartStatusId" });
            DropIndex("dbo.Books", new[] { "CategoryId" });
            DropIndex("dbo.Books", new[] { "AuthorId" });
            CreateIndex("dbo.WishlistBooks", "Book_BookID");
            CreateIndex("dbo.ShoppingCartBooks", "Book_BookID");
            CreateIndex("dbo.ShoppingCartBooks", "ShoppingCart_ShoppingCartID");
            CreateIndex("dbo.OrderBooks", "Book_BookID");
            CreateIndex("dbo.OrderBooks", "Order_OrderID");
            CreateIndex("dbo.ShoppingCarts", "ShoppingCartStatusID");
            CreateIndex("dbo.Books", "CategoryID");
            CreateIndex("dbo.Books", "AuthorID");
        }
    }
}
