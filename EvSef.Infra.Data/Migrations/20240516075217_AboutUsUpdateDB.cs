using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvSef.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AboutUsUpdateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AboutUsImage",
                table: "AboutUs",
                newName: "AboutUsImage2");

            migrationBuilder.AddColumn<string>(
                name: "AboutUsImage1",
                table: "AboutUs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutUsImage1",
                table: "AboutUs");

            migrationBuilder.RenameColumn(
                name: "AboutUsImage2",
                table: "AboutUs",
                newName: "AboutUsImage");
        }
    }
}
