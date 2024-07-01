using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvSef.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SiteSettingUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SiteAboutUs",
                table: "SiteSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SiteAboutUs",
                table: "SiteSettings");
        }
    }
}
