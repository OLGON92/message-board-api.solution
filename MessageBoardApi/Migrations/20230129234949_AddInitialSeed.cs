using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessageBoardApi.Migrations
{
    public partial class AddInitialSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Comment", "Date", "Group", "UserName" },
                values: new object[] { 1, "I'm a good boy", new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Good Times", "mr_hans" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1);
        }
    }
}
