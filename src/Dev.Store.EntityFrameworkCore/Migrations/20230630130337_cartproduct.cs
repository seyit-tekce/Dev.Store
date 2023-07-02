using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dev.Store.Migrations
{
    /// <inheritdoc />
    public partial class cartproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppOrders_AbpUsers_UserId",
                table: "AppOrders");

            migrationBuilder.DropIndex(
                name: "IX_AppOrders_UserId",
                table: "AppOrders");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AppOrders");

            migrationBuilder.CreateTable(
                name: "AppCartProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: false, defaultValue: 1.0),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCartProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppCartProducts_AppProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "AppProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "");

            migrationBuilder.CreateTable(
                name: "AppCartSets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CartProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    SetId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    ProductSetId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCartSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppCartSets_AppCartProducts_CartProductId",
                        column: x => x.CartProductId,
                        principalTable: "AppCartProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppCartSets_AppProductSets_ProductSetId",
                        column: x => x.ProductSetId,
                        principalTable: "AppProductSets",
                        principalColumn: "Id");
                },
                comment: "");

            migrationBuilder.CreateTable(
                name: "AppCartSizes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CartProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    SizeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    ProductSizeId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCartSizes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppCartSizes_AppCartProducts_CartProductId",
                        column: x => x.CartProductId,
                        principalTable: "AppCartProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppCartSizes_AppProductSizes_ProductSizeId",
                        column: x => x.ProductSizeId,
                        principalTable: "AppProductSizes",
                        principalColumn: "Id");
                },
                comment: "");

            migrationBuilder.CreateIndex(
                name: "IX_AppOrders_CreatorId",
                table: "AppOrders",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOrders_DeleterId",
                table: "AppOrders",
                column: "DeleterId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOrders_LastModifierId",
                table: "AppOrders",
                column: "LastModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_AppCartProducts_ProductId",
                table: "AppCartProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AppCartSets_CartProductId",
                table: "AppCartSets",
                column: "CartProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AppCartSets_ProductSetId",
                table: "AppCartSets",
                column: "ProductSetId");

            migrationBuilder.CreateIndex(
                name: "IX_AppCartSizes_CartProductId",
                table: "AppCartSizes",
                column: "CartProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AppCartSizes_ProductSizeId",
                table: "AppCartSizes",
                column: "ProductSizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOrders_AbpUsers_CreatorId",
                table: "AppOrders",
                column: "CreatorId",
                principalTable: "AbpUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOrders_AbpUsers_DeleterId",
                table: "AppOrders",
                column: "DeleterId",
                principalTable: "AbpUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOrders_AbpUsers_LastModifierId",
                table: "AppOrders",
                column: "LastModifierId",
                principalTable: "AbpUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppOrders_AbpUsers_CreatorId",
                table: "AppOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_AppOrders_AbpUsers_DeleterId",
                table: "AppOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_AppOrders_AbpUsers_LastModifierId",
                table: "AppOrders");

            migrationBuilder.DropTable(
                name: "AppCartSets");

            migrationBuilder.DropTable(
                name: "AppCartSizes");

            migrationBuilder.DropTable(
                name: "AppCartProducts");

            migrationBuilder.DropIndex(
                name: "IX_AppOrders_CreatorId",
                table: "AppOrders");

            migrationBuilder.DropIndex(
                name: "IX_AppOrders_DeleterId",
                table: "AppOrders");

            migrationBuilder.DropIndex(
                name: "IX_AppOrders_LastModifierId",
                table: "AppOrders");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "AppOrders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AppOrders_UserId",
                table: "AppOrders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOrders_AbpUsers_UserId",
                table: "AppOrders",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
