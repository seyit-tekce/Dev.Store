using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dev.Store.Migrations
{
    /// <inheritdoc />
    public partial class orderds1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppOrderSets_AppOrderProducts_OrderProductId",
                table: "AppOrderSets");

            migrationBuilder.DropForeignKey(
                name: "FK_AppOrderSizes_AppOrderProducts_SizeId",
                table: "AppOrderSizes");

            migrationBuilder.DropIndex(
                name: "IX_AppOrderSizes_SizeId",
                table: "AppOrderSizes");

            migrationBuilder.DropIndex(
                name: "IX_AppOrderSets_OrderProductId",
                table: "AppOrderSets");

            migrationBuilder.CreateIndex(
                name: "IX_AppOrderSizes_OrderProductId",
                table: "AppOrderSizes",
                column: "OrderProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOrderSets_SetId",
                table: "AppOrderSets",
                column: "SetId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOrderSets_AppOrderProducts_SetId",
                table: "AppOrderSets",
                column: "SetId",
                principalTable: "AppOrderProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppOrderSizes_AppOrderProducts_OrderProductId",
                table: "AppOrderSizes",
                column: "OrderProductId",
                principalTable: "AppOrderProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppOrderSets_AppOrderProducts_SetId",
                table: "AppOrderSets");

            migrationBuilder.DropForeignKey(
                name: "FK_AppOrderSizes_AppOrderProducts_OrderProductId",
                table: "AppOrderSizes");

            migrationBuilder.DropIndex(
                name: "IX_AppOrderSizes_OrderProductId",
                table: "AppOrderSizes");

            migrationBuilder.DropIndex(
                name: "IX_AppOrderSets_SetId",
                table: "AppOrderSets");

            migrationBuilder.CreateIndex(
                name: "IX_AppOrderSizes_SizeId",
                table: "AppOrderSizes",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOrderSets_OrderProductId",
                table: "AppOrderSets",
                column: "OrderProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOrderSets_AppOrderProducts_OrderProductId",
                table: "AppOrderSets",
                column: "OrderProductId",
                principalTable: "AppOrderProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppOrderSizes_AppOrderProducts_SizeId",
                table: "AppOrderSizes",
                column: "SizeId",
                principalTable: "AppOrderProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
