using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvSef.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class JoinUsDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JoinUs",
                columns: table => new
                {
                    JoinUsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JoinUsTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    JoinUsDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JoinUsImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JoinUs", x => x.JoinUsId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JoinUs");
        }
    }
}
