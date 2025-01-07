using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vanguardium.Infra.ORM.Migrations
{
    /// <inheritdoc />
    public partial class addnewpropertyandmodificationtypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "balance",
                schema: "Vanguardium",
                table: "User",
                type: "decimal(18,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 10);

            migrationBuilder.AlterColumn<decimal>(
                name: "value",
                schema: "Vanguardium",
                table: "Transfers",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "balance",
                schema: "Vanguardium",
                table: "User");

            migrationBuilder.AlterColumn<long>(
                name: "value",
                schema: "Vanguardium",
                table: "Transfers",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
