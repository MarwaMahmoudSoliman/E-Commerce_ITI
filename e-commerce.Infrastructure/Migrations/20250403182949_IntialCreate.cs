﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_commerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IntialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Category__3214EC2794A91D88", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__3214EC27B75DE14A", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Seller",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Seller__3214EC272DFE5864", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sub_Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Category_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Sub_Cate__3214EC27EDCAACCF", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Sub_Categ__Categ__398D8EEE",
                        column: x => x.Category_ID,
                        principalTable: "Category",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_ID = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DeptNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Address__3214EC27EC8F225B", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Address__Custome__4CA06362",
                        column: x => x.Customer_ID,
                        principalTable: "Customer",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Total_Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Total_Items_Number = table.Column<int>(type: "int", nullable: false),
                    Customer_ID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cart__3214EC27F2436962", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Cart__Customer_I__59FA5E80",
                        column: x => x.Customer_ID,
                        principalTable: "Customer",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Wishlist",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Wishlist__3214EC27DFF4E54F", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Wishlist__Custom__60A75C0F",
                        column: x => x.Customer_ID,
                        principalTable: "Customer",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DESC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(5,2)", nullable: true, defaultValue: 0m),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Sub_Category_ID = table.Column<int>(type: "int", nullable: false),
                    Seller_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Product__3214EC278B3FF41B", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Product__Seller___4222D4EF",
                        column: x => x.Seller_ID,
                        principalTable: "Seller",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__Product__Sub_Cat__412EB0B6",
                        column: x => x.Sub_Category_ID,
                        principalTable: "Sub_Category",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_ID = table.Column<int>(type: "int", nullable: false),
                    Order_Date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Payment_Method = table.Column<int>(type: "int", nullable: false),
                    Total_Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Shipping_Address_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Order__3214EC27C4A690F4", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Order__Customer___5070F446",
                        column: x => x.Customer_ID,
                        principalTable: "Customer",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__Order__Shipping___5165187F",
                        column: x => x.Shipping_Address_ID,
                        principalTable: "Address",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Cart_Product",
                columns: table => new
                {
                    Cart_ID = table.Column<int>(type: "int", nullable: false),
                    product_code = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Unit_Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Item_Total = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cart_Pro__9C4AF075F8E58532", x => new { x.Cart_ID, x.product_code });
                    table.ForeignKey(
                        name: "FK__Cart_Prod__Cart___5CD6CB2B",
                        column: x => x.Cart_ID,
                        principalTable: "Cart",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__Cart_Prod__produ__5DCAEF64",
                        column: x => x.product_code,
                        principalTable: "Product",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Product_Image",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_ID = table.Column<int>(type: "int", nullable: false),
                    Image_URL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Is_Primary = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Display_Order = table.Column<int>(type: "int", nullable: true, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Product___3214EC27769A4C12", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Product_I__Produ__46E78A0C",
                        column: x => x.Product_ID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product_Wishlist",
                columns: table => new
                {
                    Wishlist_ID = table.Column<int>(type: "int", nullable: false),
                    Product_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Product___7FD1083A4BA20C42", x => new { x.Wishlist_ID, x.Product_ID });
                    table.ForeignKey(
                        name: "FK__Product_W__Produ__6477ECF3",
                        column: x => x.Product_ID,
                        principalTable: "Product",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__Product_W__Wishl__6383C8BA",
                        column: x => x.Wishlist_ID,
                        principalTable: "Wishlist",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_ID = table.Column<int>(type: "int", nullable: false),
                    Product_ID = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Review_Date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Review__3214EC2760B66623", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Review__Customer__693CA210",
                        column: x => x.Customer_ID,
                        principalTable: "Customer",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__Review__Product___6A30C649",
                        column: x => x.Product_ID,
                        principalTable: "Product",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Order_Product",
                columns: table => new
                {
                    Order_ID = table.Column<int>(type: "int", nullable: false),
                    Product_ID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Unit_Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Item_Total = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Order_Pr__48672C2257690B3E", x => new { x.Order_ID, x.Product_ID });
                    table.ForeignKey(
                        name: "FK__Order_Pro__Order__5441852A",
                        column: x => x.Order_ID,
                        principalTable: "Order",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__Order_Pro__Produ__5535A963",
                        column: x => x.Product_ID,
                        principalTable: "Product",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Returns",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Order_ID = table.Column<int>(type: "int", nullable: false),
                    Product_ID = table.Column<int>(type: "int", nullable: false),
                    Return_Date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Returns__3214EC274E77FA1B", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Returns__Order_I__6E01572D",
                        column: x => x.Order_ID,
                        principalTable: "Order",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__Returns__Product__6EF57B66",
                        column: x => x.Product_ID,
                        principalTable: "Product",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Return_Image",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Return_ID = table.Column<int>(type: "int", nullable: false),
                    Image_URL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Is_Primary = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Display_Order = table.Column<int>(type: "int", nullable: true, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Return_I__3214EC27A7EF9997", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Return_Im__Retur__73BA3083",
                        column: x => x.Return_ID,
                        principalTable: "Returns",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_Customer_ID",
                table: "Address",
                column: "Customer_ID");

            migrationBuilder.CreateIndex(
                name: "UQ__Cart__8CB286B8700ED883",
                table: "Cart",
                column: "Customer_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cart_Product_product_code",
                table: "Cart_Product",
                column: "product_code");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Customer_ID",
                table: "Order",
                column: "Customer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Shipping_Address_ID",
                table: "Order",
                column: "Shipping_Address_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Product_Product_ID",
                table: "Order_Product",
                column: "Product_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Seller_ID",
                table: "Product",
                column: "Seller_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Sub_Category_ID",
                table: "Product",
                column: "Sub_Category_ID");

            migrationBuilder.CreateIndex(
                name: "UQ__Product__A25C5AA733C60312",
                table: "Product",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_Image_Product_ID",
                table: "Product_Image",
                column: "Product_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Wishlist_Product_ID",
                table: "Product_Wishlist",
                column: "Product_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Return_Image_Return_ID",
                table: "Return_Image",
                column: "Return_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Returns_Order_ID",
                table: "Returns",
                column: "Order_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Returns_Product_ID",
                table: "Returns",
                column: "Product_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Review_Customer_ID",
                table: "Review",
                column: "Customer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Review_Product_ID",
                table: "Review",
                column: "Product_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Sub_Category_Category_ID",
                table: "Sub_Category",
                column: "Category_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_Customer_ID",
                table: "Wishlist",
                column: "Customer_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart_Product");

            migrationBuilder.DropTable(
                name: "Order_Product");

            migrationBuilder.DropTable(
                name: "Product_Image");

            migrationBuilder.DropTable(
                name: "Product_Wishlist");

            migrationBuilder.DropTable(
                name: "Return_Image");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Wishlist");

            migrationBuilder.DropTable(
                name: "Returns");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Seller");

            migrationBuilder.DropTable(
                name: "Sub_Category");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
