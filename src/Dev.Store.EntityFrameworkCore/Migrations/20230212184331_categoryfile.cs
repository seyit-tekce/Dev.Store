using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dev.Store.Migrations
{
    /// <inheritdoc />
    public partial class categoryfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AppCategories_FileId",
                table: "AppCategories",
                column: "FileId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppCategories_AppUploadFiles_FileId",
                table: "AppCategories",
                column: "FileId",
                principalTable: "AppUploadFiles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppCategories_AppUploadFiles_FileId",
                table: "AppCategories");

            migrationBuilder.DropIndex(
                name: "IX_AppCategories_FileId",
                table: "AppCategories");
        }
    }
}
