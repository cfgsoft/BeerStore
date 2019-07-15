using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BeerStore.Data.Migrations
{
    public partial class AddArea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DepartmentCode",
                table: "Warehouse",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Warehouse",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CustomerShoppingArea",
                columns: table => new
                {
                    ShoppingAreaId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    UpdateStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerShoppingArea", x => new { x.ShoppingAreaId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_CustomerShoppingArea_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerShoppingArea_ShoppingArea_ShoppingAreaId",
                        column: x => x.ShoppingAreaId,
                        principalTable: "ShoppingArea",
                        principalColumn: "ShoppingAreaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarketingEvent",
                columns: table => new
                {
                    MarketingEventId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Descr = table.Column<string>(nullable: true),
                    IsMark = table.Column<bool>(nullable: false),
                    Version = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketingEvent", x => x.MarketingEventId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comment = table.Column<string>(nullable: true),
                    CustomerId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Finance = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 256, nullable: true),
                    LastName = table.Column<string>(maxLength: 256, nullable: true),
                    Number = table.Column<string>(maxLength: 10, nullable: true),
                    OutletId = table.Column<int>(nullable: true),
                    PayType = table.Column<int>(nullable: false),
                    Shipped = table.Column<bool>(nullable: false),
                    ThisReturn = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(maxLength: 450, nullable: true),
                    WarehouseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Outlets_OutletId",
                        column: x => x.OutletId,
                        principalTable: "Outlets",
                        principalColumn: "OutletId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    WarehouseId = table.Column<int>(nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric(20,3)", nullable: false),
                    ReservedQuantity = table.Column<decimal>(type: "numeric(20,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => new { x.ProductId, x.WarehouseId });
                    table.ForeignKey(
                        name: "FK_Stock_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stock_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarehouseShoppingArea",
                columns: table => new
                {
                    ShoppingAreaId = table.Column<int>(nullable: false),
                    WarehouseId = table.Column<int>(nullable: false),
                    UpdateStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseShoppingArea", x => new { x.ShoppingAreaId, x.WarehouseId });
                    table.ForeignKey(
                        name: "FK_WarehouseShoppingArea_ShoppingArea_ShoppingAreaId",
                        column: x => x.ShoppingAreaId,
                        principalTable: "ShoppingArea",
                        principalColumn: "ShoppingAreaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WarehouseShoppingArea_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarketingEventProduct",
                columns: table => new
                {
                    MarketingEventId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketingEventProduct", x => new { x.MarketingEventId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_MarketingEventProduct_MarketingEvent_MarketingEventId",
                        column: x => x.MarketingEventId,
                        principalTable: "MarketingEvent",
                        principalColumn: "MarketingEventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarketingEventProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderLine",
                columns: table => new
                {
                    CartLineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MarketingEventId = table.Column<int>(nullable: true),
                    OrderId = table.Column<int>(nullable: true),
                    ProductId = table.Column<int>(nullable: true),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLine", x => x.CartLineId);
                    table.ForeignKey(
                        name: "FK_OrderLine_MarketingEvent_MarketingEventId",
                        column: x => x.MarketingEventId,
                        principalTable: "MarketingEvent",
                        principalColumn: "MarketingEventId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderLine_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderLine_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_DepartmentId",
                table: "Warehouse",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerShoppingArea_CustomerId",
                table: "CustomerShoppingArea",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketingEvent_Code",
                table: "MarketingEvent",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_MarketingEventProduct_ProductId",
                table: "MarketingEventProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLine_MarketingEventId",
                table: "OrderLine",
                column: "MarketingEventId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLine_OrderId",
                table: "OrderLine",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLine_ProductId",
                table: "OrderLine",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Number",
                table: "Orders",
                column: "Number");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OutletId",
                table: "Orders",
                column: "OutletId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_WarehouseId",
                table: "Orders",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_WarehouseId",
                table: "Stock",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseShoppingArea_WarehouseId",
                table: "WarehouseShoppingArea",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouse_Departments_DepartmentId",
                table: "Warehouse",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warehouse_Departments_DepartmentId",
                table: "Warehouse");

            migrationBuilder.DropTable(
                name: "CustomerShoppingArea");

            migrationBuilder.DropTable(
                name: "MarketingEventProduct");

            migrationBuilder.DropTable(
                name: "OrderLine");

            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "WarehouseShoppingArea");

            migrationBuilder.DropTable(
                name: "MarketingEvent");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Warehouse_DepartmentId",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "DepartmentCode",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Warehouse");
        }
    }
}
