namespace BookstoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorID = c.Int(nullable: false, identity: true),
                        AuthorName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AuthorID);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookID = c.Int(nullable: false, identity: true),
                        ISBN = c.String(nullable: false),
                        ImageURL = c.String(nullable: false),
                        BookName = c.String(nullable: false),
                        AuthorID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        UserAddressID = c.Int(nullable: false),
                        ReceivedOrderTime = c.DateTime(nullable: false),
                        OrderCompletedTime = c.DateTime(),
                        PhoneNumber = c.String(nullable: false),
                        OrderStatusID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID);
            
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        ShoppingCartID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        ShoppingCartStatusID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShoppingCartID);
            
            CreateTable(
                "dbo.Wishlists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.OrderStatus",
                c => new
                    {
                        OrderStatusID = c.Int(nullable: false, identity: true),
                        OrderStatusDescription = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.OrderStatusID);
            
            CreateTable(
                "dbo.ShoppingCartStatus",
                c => new
                    {
                        ShoppingCartStatusID = c.Int(nullable: false, identity: true),
                        ShoppingCartStatusDescription = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ShoppingCartStatusID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.OrderBooks",
                c => new
                    {
                        Order_OrderID = c.Int(nullable: false),
                        Book_BookID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_OrderID, t.Book_BookID })
                .ForeignKey("dbo.Orders", t => t.Order_OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_BookID, cascadeDelete: true)
                .Index(t => t.Order_OrderID)
                .Index(t => t.Book_BookID);
            
            CreateTable(
                "dbo.ShoppingCartBooks",
                c => new
                    {
                        ShoppingCart_ShoppingCartID = c.Int(nullable: false),
                        Book_BookID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ShoppingCart_ShoppingCartID, t.Book_BookID })
                .ForeignKey("dbo.ShoppingCarts", t => t.ShoppingCart_ShoppingCartID, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_BookID, cascadeDelete: true)
                .Index(t => t.ShoppingCart_ShoppingCartID)
                .Index(t => t.Book_BookID);
            
            CreateTable(
                "dbo.WishlistBooks",
                c => new
                    {
                        Wishlist_Id = c.Int(nullable: false),
                        Book_BookID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Wishlist_Id, t.Book_BookID })
                .ForeignKey("dbo.Wishlists", t => t.Wishlist_Id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_BookID, cascadeDelete: true)
                .Index(t => t.Wishlist_Id)
                .Index(t => t.Book_BookID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WishlistBooks", "Book_BookID", "dbo.Books");
            DropForeignKey("dbo.WishlistBooks", "Wishlist_Id", "dbo.Wishlists");
            DropForeignKey("dbo.ShoppingCartBooks", "Book_BookID", "dbo.Books");
            DropForeignKey("dbo.ShoppingCartBooks", "ShoppingCart_ShoppingCartID", "dbo.ShoppingCarts");
            DropForeignKey("dbo.OrderBooks", "Book_BookID", "dbo.Books");
            DropForeignKey("dbo.OrderBooks", "Order_OrderID", "dbo.Orders");
            DropIndex("dbo.WishlistBooks", new[] { "Book_BookID" });
            DropIndex("dbo.WishlistBooks", new[] { "Wishlist_Id" });
            DropIndex("dbo.ShoppingCartBooks", new[] { "Book_BookID" });
            DropIndex("dbo.ShoppingCartBooks", new[] { "ShoppingCart_ShoppingCartID" });
            DropIndex("dbo.OrderBooks", new[] { "Book_BookID" });
            DropIndex("dbo.OrderBooks", new[] { "Order_OrderID" });
            DropTable("dbo.WishlistBooks");
            DropTable("dbo.ShoppingCartBooks");
            DropTable("dbo.OrderBooks");
            DropTable("dbo.Users");
            DropTable("dbo.ShoppingCartStatus");
            DropTable("dbo.OrderStatus");
            DropTable("dbo.Categories");
            DropTable("dbo.Wishlists");
            DropTable("dbo.ShoppingCarts");
            DropTable("dbo.Orders");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
