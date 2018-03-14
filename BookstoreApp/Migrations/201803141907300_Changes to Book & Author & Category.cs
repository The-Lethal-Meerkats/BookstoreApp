namespace BookstoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangestoBookAuthorCategory : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Books", "AuthorID");
            CreateIndex("dbo.Books", "CategoryID");
            AddForeignKey("dbo.Books", "AuthorID", "dbo.Authors", "AuthorID", cascadeDelete: true);
            AddForeignKey("dbo.Books", "CategoryID", "dbo.Categories", "CategoryID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Books", "AuthorID", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "CategoryID" });
            DropIndex("dbo.Books", new[] { "AuthorID" });
        }
    }
}
