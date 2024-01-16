using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataPostu.Migrations
{
    public partial class InitialCreate43535 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Content = table.Column<string>(type: "TEXT", maxLength: 5000, nullable: false),
                    Author = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Tags = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Comment = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Author", "Comment", "Content", "Created", "PublicationDate", "Tags" },
                values: new object[] { 1, "Jan Kowalski", "To jest pierwszy post na moim blogu!", "Pierwszy post na blogu", new DateTime(2024, 1, 16, 17, 30, 21, 976, DateTimeKind.Local).AddTicks(82), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pierwszy, blog" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Author", "Comment", "Content", "Created", "PublicationDate", "Tags" },
                values: new object[] { 2, "Anna Nowak", "Drugi post na blogu z moimi przemyśleniami.", "Drugie wprowadzenie", new DateTime(2024, 1, 16, 17, 30, 21, 976, DateTimeKind.Local).AddTicks(111), new DateTime(2021, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "wprowadzenie, blog" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
