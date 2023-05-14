using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Firstapi.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(name: "Brand Name", type: "nvarchar(max)", nullable: true),
                    BrandDescription = table.Column<string>(name: "Brand Description", type: "nvarchar(max)", nullable: true),
                    BrandPrice = table.Column<decimal>(name: "Brand Price", type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    BrandUnit = table.Column<string>(name: "Brand Unit", type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
