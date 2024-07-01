using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvSef.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChefFoodPriceDb3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChefFoodId",
                table: "WeekdayFoods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "ChefFoodPriceIsDefault",
                table: "ChefFoodPrices",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<decimal>(
                name: "ChefFoodPriceDiscount",
                table: "ChefFoodPrices",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChefFoodId",
                table: "WeekdayFoods");

            migrationBuilder.AlterColumn<bool>(
                name: "ChefFoodPriceIsDefault",
                table: "ChefFoodPrices",
                type: "bit",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ChefFoodPriceDiscount",
                table: "ChefFoodPrices",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");
        }
    }
}
