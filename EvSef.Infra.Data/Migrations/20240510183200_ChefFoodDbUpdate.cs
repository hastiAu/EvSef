using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvSef.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChefFoodDbUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "ChefFoodLimitCount",
                table: "Foods",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<bool>(
                name: "ChefFoodPriceIsDefault",
                table: "ChefFoodPrices",
                type: "bit",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AddColumn<decimal>(
                name: "ChefFoodPriceDiscount",
                table: "ChefFoodPrices",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChefFoodLimitCount",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "ChefFoodPriceDiscount",
                table: "ChefFoodPrices");

            migrationBuilder.AlterColumn<decimal>(
                name: "ChefFoodPriceIsDefault",
                table: "ChefFoodPrices",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
