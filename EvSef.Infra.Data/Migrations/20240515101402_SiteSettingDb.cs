using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvSef.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SiteSettingDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutUs",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "CustomFoodDescription",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "CustomFoodTitle",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "DietFoodDescription",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "DietFoodTitle",
                table: "SiteSettings");

            migrationBuilder.RenameColumn(
                name: "PersonFormTitle2",
                table: "SiteSettings",
                newName: "SliderPhoto");

            migrationBuilder.RenameColumn(
                name: "OurService",
                table: "SiteSettings",
                newName: "OurServiceTitle");

            migrationBuilder.RenameColumn(
                name: "OurChef",
                table: "SiteSettings",
                newName: "OurChefTitle");

            migrationBuilder.RenameColumn(
                name: "OrderFormTitle",
                table: "SiteSettings",
                newName: "HowOrderCorporationFoodTitle");

            migrationBuilder.RenameColumn(
                name: "HowOrderCorporationFood",
                table: "SiteSettings",
                newName: "FoodMenuTitle");

            migrationBuilder.RenameColumn(
                name: "FoodMenu",
                table: "SiteSettings",
                newName: "CorporationFormTitle1");

            migrationBuilder.AlterColumn<string>(
                name: "SiteLogo",
                table: "SiteSettings",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.CreateTable(
                name: "CustomFoods",
                columns: table => new
                {
                    CustomFoodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomFoodTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomFoodDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomFoodImage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomFoods", x => x.CustomFoodId);
                });

            migrationBuilder.CreateTable(
                name: "MainSliders",
                columns: table => new
                {
                    MaidSliderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SliderTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SliderDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SliderImage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainSliders", x => x.MaidSliderId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomFoods");

            migrationBuilder.DropTable(
                name: "MainSliders");

            migrationBuilder.RenameColumn(
                name: "SliderPhoto",
                table: "SiteSettings",
                newName: "PersonFormTitle2");

            migrationBuilder.RenameColumn(
                name: "OurServiceTitle",
                table: "SiteSettings",
                newName: "OurService");

            migrationBuilder.RenameColumn(
                name: "OurChefTitle",
                table: "SiteSettings",
                newName: "OurChef");

            migrationBuilder.RenameColumn(
                name: "HowOrderCorporationFoodTitle",
                table: "SiteSettings",
                newName: "OrderFormTitle");

            migrationBuilder.RenameColumn(
                name: "FoodMenuTitle",
                table: "SiteSettings",
                newName: "HowOrderCorporationFood");

            migrationBuilder.RenameColumn(
                name: "CorporationFormTitle1",
                table: "SiteSettings",
                newName: "FoodMenu");

            migrationBuilder.AlterColumn<string>(
                name: "SiteLogo",
                table: "SiteSettings",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<string>(
                name: "AboutUs",
                table: "SiteSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomFoodDescription",
                table: "SiteSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomFoodTitle",
                table: "SiteSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DietFoodDescription",
                table: "SiteSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DietFoodTitle",
                table: "SiteSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
