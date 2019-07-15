using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BeerStore.Data.Migrations
{
    public partial class AddWarehouse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Merchandisers",
                columns: table => new
                {
                    MerchandiserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Descr = table.Column<string>(nullable: false),
                    IsMark = table.Column<bool>(nullable: false),
                    Version = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchandisers", x => x.MerchandiserId);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingArea",
                columns: table => new
                {
                    ShoppingAreaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Descr = table.Column<string>(nullable: true),
                    IsMark = table.Column<bool>(nullable: false),
                    Version = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingArea", x => x.ShoppingAreaId);
                });

            migrationBuilder.CreateTable(
                name: "Warehouse",
                columns: table => new
                {
                    WarehouseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Descr = table.Column<string>(nullable: false),
                    IsMark = table.Column<bool>(nullable: false),
                    Version = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.WarehouseId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Merchandisers_Code",
                table: "Merchandisers",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingArea_Code",
                table: "ShoppingArea",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_Code",
                table: "Warehouse",
                column: "Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Merchandisers");

            migrationBuilder.DropTable(
                name: "ShoppingArea");

            migrationBuilder.DropTable(
                name: "Warehouse");
        }
    }
}
