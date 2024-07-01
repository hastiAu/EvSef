using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvSef.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class WeekDayDB2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeekdayFoods_FoodCategories_FoodCategoryId",
                table: "WeekdayFoods");

            migrationBuilder.DropForeignKey(
                name: "FK_WeekdayFoods_Foods_FoodId",
                table: "WeekdayFoods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeekdayFoods",
                table: "WeekdayFoods");

            migrationBuilder.RenameTable(
                name: "WeekdayFoods",
                newName: "WeekDayFoods");

            migrationBuilder.RenameIndex(
                name: "IX_WeekdayFoods_FoodId",
                table: "WeekDayFoods",
                newName: "IX_WeekDayFoods_FoodId");

            migrationBuilder.RenameIndex(
                name: "IX_WeekdayFoods_FoodCategoryId",
                table: "WeekDayFoods",
                newName: "IX_WeekDayFoods_FoodCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeekDayFoods",
                table: "WeekDayFoods",
                column: "WeekdayFoodId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeekDayFoods_FoodCategories_FoodCategoryId",
                table: "WeekDayFoods");

            migrationBuilder.DropForeignKey(
                name: "FK_WeekDayFoods_Foods_FoodId",
                table: "WeekDayFoods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeekDayFoods",
                table: "WeekDayFoods");

            migrationBuilder.RenameTable(
                name: "WeekDayFoods",
                newName: "WeekdayFoods");

            migrationBuilder.RenameIndex(
                name: "IX_WeekDayFoods_FoodId",
                table: "WeekdayFoods",
                newName: "IX_WeekdayFoods_FoodId");

            migrationBuilder.RenameIndex(
                name: "IX_WeekDayFoods_FoodCategoryId",
                table: "WeekdayFoods",
                newName: "IX_WeekdayFoods_FoodCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeekdayFoods",
                table: "WeekdayFoods",
                column: "WeekdayFoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeekdayFoods_FoodCategories_FoodCategoryId",
                table: "WeekdayFoods",
                column: "FoodCategoryId",
                principalTable: "FoodCategories",
                principalColumn: "FoodCategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WeekdayFoods_Foods_FoodId",
                table: "WeekdayFoods",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "FoodId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
