using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPICodeFirst.Migrations
{
    public partial class d : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hastaneler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HastaneAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hastaneler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hastalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyisim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Klinik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MuayeneTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HastaneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hastalar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hastalar_Hastaneler_HastaneId",
                        column: x => x.HastaneId,
                        principalTable: "Hastaneler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Hastaneler",
                columns: new[] { "Id", "Adres", "HastaneAd" },
                values: new object[] { 1, "Beşiktaş", "Sait Çiftçi Devlet Hastanesi" });

            migrationBuilder.InsertData(
                table: "Hastaneler",
                columns: new[] { "Id", "Adres", "HastaneAd" },
                values: new object[] { 2, "Kartal", "Kartal Devlet Hastanesi" });

            migrationBuilder.InsertData(
                table: "Hastalar",
                columns: new[] { "Id", "HastaneId", "Isim", "Klinik", "MuayeneTarihi", "Soyisim" },
                values: new object[] { 1, 1, "John", "Kardiyoloji", new DateTime(2024, 1, 25, 14, 48, 1, 488, DateTimeKind.Local).AddTicks(7790), "Doe" });

            migrationBuilder.InsertData(
                table: "Hastalar",
                columns: new[] { "Id", "HastaneId", "Isim", "Klinik", "MuayeneTarihi", "Soyisim" },
                values: new object[] { 2, 2, "Jane", "Üroloji", new DateTime(2024, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doe" });

            migrationBuilder.CreateIndex(
                name: "IX_Hastalar_HastaneId",
                table: "Hastalar",
                column: "HastaneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hastalar");

            migrationBuilder.DropTable(
                name: "Hastaneler");
        }
    }
}
