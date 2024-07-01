using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvSef.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class firstDb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chefs",
                columns: table => new
                {
                    ChefId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MealsNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserState = table.Column<int>(type: "int", nullable: false),
                    ChefAvatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ChefRequestState = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chefs", x => x.ChefId);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelatedId = table.Column<int>(type: "int", nullable: false),
                    RelatedType = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserState = table.Column<int>(type: "int", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "ContactInfos",
                columns: table => new
                {
                    ContactInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    RelatedId = table.Column<int>(type: "int", nullable: false),
                    RelatedType = table.Column<int>(type: "int", nullable: false),
                    ContactInfoAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactInfoZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfos", x => x.ContactInfoId);
                });

            migrationBuilder.CreateTable(
                name: "ContactLocations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactLocations", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_ContactLocations_ContactLocations_ParentId",
                        column: x => x.ParentId,
                        principalTable: "ContactLocations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Corporations",
                columns: table => new
                {
                    CorporationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CorporationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StaffNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserState = table.Column<int>(type: "int", nullable: false),
                    CorporationRequestState = table.Column<int>(type: "int", nullable: false),
                    CorporationAvatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corporations", x => x.CorporationId);
                });

            migrationBuilder.CreateTable(
                name: "FoodCategories",
                columns: table => new
                {
                    FoodCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodCategoryParentId = table.Column<int>(type: "int", nullable: true),
                    FoodCategoryTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodCategories", x => x.FoodCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    FoodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FoodDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageFood = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.FoodId);
                });

            migrationBuilder.CreateTable(
                name: "OurCustomers",
                columns: table => new
                {
                    OurCustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OurCustomerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OurCustomerDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OurCustomers", x => x.OurCustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserState = table.Column<int>(type: "int", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "PriceTypes",
                columns: table => new
                {
                    PriceTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceTypeCurrency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceTypeIsDefault = table.Column<bool>(type: "bit", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceTypes", x => x.PriceTypeId);
                });

            migrationBuilder.CreateTable(
                name: "SiteSettings",
                columns: table => new
                {
                    SiteSettingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SiteUrl = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SitePhone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SiteCustomerPhone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SiteEmail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SiteCopyRight = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SiteLogo = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    SloganTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderFormTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorporationFormTitle2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonFormTitle2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutUs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OurService = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodMenu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomFoodTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomFoodDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DietFoodTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DietFoodDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OurChef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeChefTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeChefDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeChefImage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    JoinChefTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReasonChefTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorporationFoodTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorporationFoodDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HowOrderCorporationFood = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteSettings", x => x.SiteSettingId);
                });

            migrationBuilder.CreateTable(
                name: "ChefFoods",
                columns: table => new
                {
                    ChefFoodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    ChefId = table.Column<int>(type: "int", nullable: false),
                    ChefFoodLimitCount = table.Column<float>(type: "real", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChefFoods", x => x.ChefFoodId);
                    table.ForeignKey(
                        name: "FK_ChefFoods_Chefs_ChefId",
                        column: x => x.ChefId,
                        principalTable: "Chefs",
                        principalColumn: "ChefId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChefFoods_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "FoodId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FoodSelectedCategories",
                columns: table => new
                {
                    FoodSelectedCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    FoodCategoryId = table.Column<int>(type: "int", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodSelectedCategories", x => x.FoodSelectedCategoryId);
                    table.ForeignKey(
                        name: "FK_FoodSelectedCategories_FoodCategories_FoodCategoryId",
                        column: x => x.FoodCategoryId,
                        principalTable: "FoodCategories",
                        principalColumn: "FoodCategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FoodSelectedCategories_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "FoodId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeekdayFoods",
                columns: table => new
                {
                    WeekdayFoodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    FoodCategoryId = table.Column<int>(type: "int", nullable: false),
                    WeekDayFromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WeekDayToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekdayFoods", x => x.WeekdayFoodId);
                    table.ForeignKey(
                        name: "FK_WeekdayFoods_FoodCategories_FoodCategoryId",
                        column: x => x.FoodCategoryId,
                        principalTable: "FoodCategories",
                        principalColumn: "FoodCategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeekdayFoods_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "FoodId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChefFoodPrices",
                columns: table => new
                {
                    ChefFoodPriceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChefFoodId = table.Column<int>(type: "int", nullable: false),
                    PriceTypeId = table.Column<int>(type: "int", nullable: false),
                    ChefFoodsPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    ChefFoodPriceIsDefault = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    ChefFoodPriceFromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChefFoodPriceToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChefFoodPrices", x => x.ChefFoodPriceId);
                    table.ForeignKey(
                        name: "FK_ChefFoodPrices_ChefFoods_ChefFoodId",
                        column: x => x.ChefFoodId,
                        principalTable: "ChefFoods",
                        principalColumn: "ChefFoodId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChefFoodPrices_PriceTypes_PriceTypeId",
                        column: x => x.PriceTypeId,
                        principalTable: "PriceTypes",
                        principalColumn: "PriceTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChefFoodPrices_ChefFoodId",
                table: "ChefFoodPrices",
                column: "ChefFoodId");

            migrationBuilder.CreateIndex(
                name: "IX_ChefFoodPrices_PriceTypeId",
                table: "ChefFoodPrices",
                column: "PriceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ChefFoods_ChefId",
                table: "ChefFoods",
                column: "ChefId");

            migrationBuilder.CreateIndex(
                name: "IX_ChefFoods_FoodId",
                table: "ChefFoods",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactLocations_ParentId",
                table: "ContactLocations",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodSelectedCategories_FoodCategoryId",
                table: "FoodSelectedCategories",
                column: "FoodCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodSelectedCategories_FoodId",
                table: "FoodSelectedCategories",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_WeekdayFoods_FoodCategoryId",
                table: "WeekdayFoods",
                column: "FoodCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_WeekdayFoods_FoodId",
                table: "WeekdayFoods",
                column: "FoodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChefFoodPrices");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "ContactInfos");

            migrationBuilder.DropTable(
                name: "ContactLocations");

            migrationBuilder.DropTable(
                name: "Corporations");

            migrationBuilder.DropTable(
                name: "FoodSelectedCategories");

            migrationBuilder.DropTable(
                name: "OurCustomers");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "SiteSettings");

            migrationBuilder.DropTable(
                name: "WeekdayFoods");

            migrationBuilder.DropTable(
                name: "ChefFoods");

            migrationBuilder.DropTable(
                name: "PriceTypes");

            migrationBuilder.DropTable(
                name: "FoodCategories");

            migrationBuilder.DropTable(
                name: "Chefs");

            migrationBuilder.DropTable(
                name: "Foods");
        }
    }
}
