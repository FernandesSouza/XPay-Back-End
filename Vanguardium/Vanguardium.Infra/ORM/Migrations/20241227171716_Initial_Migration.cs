using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vanguardium.Infra.ORM.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Vanguardium");

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "Vanguardium",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    state = table.Column<string>(type: "varchar(150)", nullable: false),
                    city = table.Column<string>(type: "varchar(150)", nullable: false),
                    district = table.Column<string>(type: "varchar(150)", nullable: false),
                    street = table.Column<string>(type: "varchar(150)", nullable: false),
                    country = table.Column<string>(type: "varchar(80)", nullable: false),
                    zip_code = table.Column<string>(type: "varchar(30)", nullable: false),
                    complement = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                schema: "Vanguardium",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    corporateName = table.Column<string>(type: "varchar(150)", nullable: false),
                    document = table.Column<string>(type: "varchar(50)", nullable: false),
                    contactNumber = table.Column<string>(type: "varchar(50)", nullable: false),
                    AddressId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.id);
                    table.ForeignKey(
                        name: "FK_Company_Address_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "Vanguardium",
                        principalTable: "Address",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Vanguardium",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "varchar(150)", nullable: false),
                    document = table.Column<string>(type: "varchar(50)", nullable: false),
                    email = table.Column<string>(type: "varchar(50)", nullable: false),
                    password = table.Column<string>(type: "varchar(50)", nullable: false),
                    telephone = table.Column<string>(type: "varchar(50)", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    role = table.Column<byte>(type: "tinyint", nullable: false),
                    genero = table.Column<byte>(type: "tinyint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                    table.ForeignKey(
                        name: "FK_User_Address_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "Vanguardium",
                        principalTable: "Address",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transfers",
                schema: "Vanguardium",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    senderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    recipientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    value = table.Column<long>(type: "bigint", nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    statusTransfer = table.Column<byte>(type: "tinyint", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfers", x => x.id);
                    table.ForeignKey(
                        name: "FK_Transfers_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Vanguardium",
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_AddressId",
                schema: "Vanguardium",
                table: "Company",
                column: "AddressId",
                unique: true,
                filter: "[AddressId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_UserId",
                schema: "Vanguardium",
                table: "Transfers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_AddressId",
                schema: "Vanguardium",
                table: "User",
                column: "AddressId",
                unique: true,
                filter: "[AddressId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company",
                schema: "Vanguardium");

            migrationBuilder.DropTable(
                name: "Transfers",
                schema: "Vanguardium");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Vanguardium");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "Vanguardium");
        }
    }
}
