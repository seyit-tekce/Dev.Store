using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace Dev.Store.Migrations
{
    /// <inheritdoc />
    public partial class nullablebrandid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppProducts_AppBrands_BrandId",
                table: "AppProducts");

            migrationBuilder.AlterColumn<Guid>(
                name: "BrandId",
                table: "AppProducts",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_AppProducts_AppBrands_BrandId",
                table: "AppProducts",
                column: "BrandId",
                principalTable: "AppBrands",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppProducts_AppBrands_BrandId",
                table: "AppProducts");

            migrationBuilder.AlterColumn<Guid>(
                name: "BrandId",
                table: "AppProducts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppProducts_AppBrands_BrandId",
                table: "AppProducts",
                column: "BrandId",
                principalTable: "AppBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
