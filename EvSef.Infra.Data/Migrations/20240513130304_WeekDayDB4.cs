using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvSef.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class WeekDayDB4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeekDayFoods_FoodCategories_FoodCategoryId",
                table: "WeekDayFoods");

            migrationBuilder.DropForeignKey(
                name: "FK_WeekDayFoods_Foods_FoodId",
                table: "WeekDayFoods");

            migrationBuilder.DropIndex(
                name: "IX_WeekDayFoods_FoodCategoryId",
                table: "WeekDayFoods");

            migrationBuilder.DropIndex(
                name: "IX_WeekDayFoods_FoodId",
                table: "WeekDayFoods");

            migrationBuilder.DropColumn(
                name: "FoodCategoryId",
                table: "WeekDayFoods");

            migrationBuilder.DropColumn(
                name: "FoodId",
                table: "WeekDayFoods");

            migrationBuilder.CreateIndex(
                name: "IX_WeekDayFoods_ChefFoodId",
                table: "WeekDayFoods",
                column: "ChefFoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeekDayFoods_ChefFoods_ChefFoodId",
                table: "WeekDayFoods",
                column: "ChefFoodId",
                principalTable: "ChefFoods",
                principalColumn: "ChefFoodId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeekDayFoods_ChefFoods_ChefFoodId",
                table: "WeekDayFoods");

            migrationBuilder.DropIndex(
                name: "IX_WeekDayFoods_ChefFoodId",
                table: "WeekDayFoods");

            migrationBuilder.AddColumn<int>(
                name: "FoodCategoryId",
                table: "WeekDayFoods",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FoodId",
                table: "WeekDayFoods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WeekDayFoods_FoodCategoryId",
                table: "WeekDayFoods",
                column: "FoodCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_WeekDayFoods_FoodId",
                table: "WeekDayFoods",
                column: "FoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeekDayFoods_FoodCategories_FoodCategoryId",
                table: "WeekDayFoods",
                column: "FoodCategoryId",
                principalTable: "FoodCategories",
                principalColumn: "FoodCategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WeekDayFoods_Foods_FoodId",
                table: "WeekDayFoods",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "FoodId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
