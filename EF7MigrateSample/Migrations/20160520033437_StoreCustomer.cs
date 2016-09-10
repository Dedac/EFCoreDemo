using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace EF7MigrateSample.Migrations
{
    public partial class StoreCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StoreCustomer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false),
                    StoreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreCustomer", x => new { x.CustomerId, x.StoreId });
                    table.ForeignKey(
                        name: "FK_StoreCustomer_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreCustomer_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("StoreCustomer");
        }
    }
}
