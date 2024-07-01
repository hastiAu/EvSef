using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvSef.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CorporationFoodDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SocialMediaUrl",
                table: "SocialMedia",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateTable(
                name: "CorporationFoods",
                columns: table => new
                {
                    CorporationFoodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CorporationId = table.Column<int>(type: "int", nullable: false),
                    ChefFoodId = table.Column<int>(type: "int", nullable: false),
                    FoodAmount = table.Column<int>(type: "int", nullable: false),
                    WeekDayName = table.Column<int>(type: "int", nullable: false),
                    CorporationOrderFromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CorporationOrderToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorporationFoods", x => x.CorporationFoodId);
                });

            migrationBuilder.CreateTable(
                name: "ChefFoodCorporationFood",
                columns: table => new
                {
                    ChefFoodsChefFoodId = table.Column<int>(type: "int", nullable: false),
                    CorporationFoodsCorporationFoodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChefFoodCorporationFood", x => new { x.ChefFoodsChefFoodId, x.CorporationFoodsCorporationFoodId });
                    table.ForeignKey(
                        name: "FK_ChefFoodCorporationFood_ChefFoods_ChefFoodsChefFoodId",
                        column: x => x.ChefFoodsChefFoodId,
                        principalTable: "ChefFoods",
                        principalColumn: "ChefFoodId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChefFoodCorporationFood_CorporationFoods_CorporationFoodsCorporationFoodId",
                        column: x => x.CorporationFoodsCorporationFoodId,
                        principalTable: "CorporationFoods",
                        principalColumn: "CorporationFoodId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChefFoodCorporationFood_CorporationFoodsCorporationFoodId",
                table: "ChefFoodCorporationFood",
                column: "CorporationFoodsCorporationFoodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChefFoodCorporationFood");

            migrationBuilder.DropTable(
                name: "CorporationFoods");

            migrationBuilder.AlterColumn<string>(
                name: "SocialMediaUrl",
                table: "SocialMedia",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
