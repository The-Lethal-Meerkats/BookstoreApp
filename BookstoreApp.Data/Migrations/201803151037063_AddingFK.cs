namespace BookstoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.ShoppingCarts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Wishlists", "UserId", "dbo.Users");
            DropPrimaryKey("dbo.Users");
            CreateTable(
                "dbo.UserAddresses",
                c => new
                    {
                        UserAddressId = c.Int(nullable: false, identity: true),
                        Street = c.String(nullable: false),
                        UserId = c.Int(nullable: false),
                        CountryId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserAddressId)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId)
                .Index(t => t.CityId);
            
            AddColumn("dbo.Orders", "UserAddressId", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "UserId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Users", "UserId");
            CreateIndex("dbo.Orders", "UserAddressId");
            CreateIndex("dbo.Users", "UserId");
            AddForeignKey("dbo.Users", "UserId", "dbo.UserAddresses", "UserAddressId");
            AddForeignKey("dbo.Orders", "UserAddressId", "dbo.UserAddresses", "UserAddressId", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.ShoppingCarts", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Wishlists", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Wishlists", "UserId", "dbo.Users");
            DropForeignKey("dbo.ShoppingCarts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "UserAddressId", "dbo.UserAddresses");
            DropForeignKey("dbo.Users", "UserId", "dbo.UserAddresses");
            DropForeignKey("dbo.UserAddresses", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.UserAddresses", "CityId", "dbo.Cities");
            DropIndex("dbo.UserAddresses", new[] { "CityId" });
            DropIndex("dbo.UserAddresses", new[] { "CountryId" });
            DropIndex("dbo.Users", new[] { "UserId" });
            DropIndex("dbo.Orders", new[] { "UserAddressId" });
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "UserId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Orders", "UserAddressId");
            DropTable("dbo.UserAddresses");
            AddPrimaryKey("dbo.Users", "UserId");
            AddForeignKey("dbo.Wishlists", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.ShoppingCarts", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}
