using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BeerStore.Data.Migrations
{
    public partial class AddAgentPlus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgentPlusUsers",
                columns: table => new
                {
                    AgentPlusUserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    DateOrder = table.Column<DateTime>(nullable: false),
                    DateUpdate = table.Column<DateTime>(nullable: false),
                    Descr = table.Column<string>(nullable: true),
                    IsMark = table.Column<bool>(nullable: false),
                    MerchandiserId = table.Column<int>(nullable: true),
                    Update = table.Column<bool>(nullable: false),
                    Version = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentPlusUsers", x => x.AgentPlusUserId);
                    table.ForeignKey(
                        name: "FK_AgentPlusUsers_Merchandisers_MerchandiserId",
                        column: x => x.MerchandiserId,
                        principalTable: "Merchandisers",
                        principalColumn: "MerchandiserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AgentPlusUserShopingArea",
                columns: table => new
                {
                    AgentPlusUserId = table.Column<int>(nullable: false),
                    ShoppingAreaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentPlusUserShopingArea", x => new { x.AgentPlusUserId, x.ShoppingAreaId });
                    table.ForeignKey(
                        name: "FK_AgentPlusUserShopingArea_AgentPlusUsers_AgentPlusUserId",
                        column: x => x.AgentPlusUserId,
                        principalTable: "AgentPlusUsers",
                        principalColumn: "AgentPlusUserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgentPlusUserShopingArea_ShoppingArea_ShoppingAreaId",
                        column: x => x.ShoppingAreaId,
                        principalTable: "ShoppingArea",
                        principalColumn: "ShoppingAreaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgentPlusUsers_MerchandiserId",
                table: "AgentPlusUsers",
                column: "MerchandiserId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentPlusUserShopingArea_ShoppingAreaId",
                table: "AgentPlusUserShopingArea",
                column: "ShoppingAreaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgentPlusUserShopingArea");

            migrationBuilder.DropTable(
                name: "AgentPlusUsers");
        }
    }
}
