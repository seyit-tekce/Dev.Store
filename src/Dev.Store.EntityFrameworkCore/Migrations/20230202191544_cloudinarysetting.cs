using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dev.Store.Migrations
{
    /// <inheritdoc />
    public partial class cloudinarysetting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppKeywords",
                table: "AppKeywords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppBrands",
                table: "AppBrands");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppKeywords",
                table: "AppKeywords",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppBrands",
                table: "AppBrands",
                column: "Code");

            migrationBuilder.CreateTable(
                name: "AppCloudinarySettings",
                columns: table => new
                {
                    CloudName = table.Column<string>(type: "text", nullable: false),
                    ApiKey = table.Column<string>(type: "text", nullable: false),
                    ApiSecret = table.Column<string>(type: "text", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_AppCloudinarySettings", x => x.CloudName);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppCloudinarySettings_CloudName",
                table: "AppCloudinarySettings",
                column: "CloudName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppCloudinarySettings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppKeywords",
                table: "AppKeywords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppBrands",
                table: "AppBrands");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppKeywords",
                table: "AppKeywords",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppBrands",
                table: "AppBrands",
                column: "Id");
        }
    }
}
