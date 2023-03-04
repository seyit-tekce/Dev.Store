using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dev.Store.Migrations
{
    /// <inheritdoc />
    public partial class removedindex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppProductImages",
                table: "AppProductImages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppProductImages",
                table: "AppProductImages",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AppProductImages_ProductId",
                table: "AppProductImages",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppProductImages",
                table: "AppProductImages");

            migrationBuilder.DropIndex(
                name: "IX_AppProductImages_ProductId",
                table: "AppProductImages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppProductImages",
                table: "AppProductImages",
                columns: new[] { "ProductId", "IsMain" });
        }
    }
}
