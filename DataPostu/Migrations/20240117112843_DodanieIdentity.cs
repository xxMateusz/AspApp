using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataPostu.Migrations
{
    public partial class DodanieIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 1, 17, 12, 28, 43, 44, DateTimeKind.Local).AddTicks(5608));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Content", "Created" },
                values: new object[] { "Drugie post", new DateTime(2024, 1, 17, 12, 28, 43, 44, DateTimeKind.Local).AddTicks(5641) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 1, 16, 17, 30, 21, 976, DateTimeKind.Local).AddTicks(82));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Content", "Created" },
                values: new object[] { "Drugie wprowadzenie", new DateTime(2024, 1, 16, 17, 30, 21, 976, DateTimeKind.Local).AddTicks(111) });
        }
    }
}
