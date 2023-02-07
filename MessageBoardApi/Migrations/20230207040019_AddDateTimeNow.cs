using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessageBoardApi.Migrations
{
    public partial class AddDateTimeNow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Comment", "Date", "Group", "UserName" },
                values: new object[] { 35, "I'm a good boy", new DateTime(2023, 2, 6, 20, 0, 19, 289, DateTimeKind.Local).AddTicks(9462), "Good Times", "mr_hans" });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Comment", "Date", "Group", "UserName" },
                values: new object[] { 36, "Time is crazy", new DateTime(2023, 2, 6, 20, 0, 19, 289, DateTimeKind.Local).AddTicks(9490), "Good Times", "mr_hans" });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Comment", "Date", "Group", "UserName" },
                values: new object[] { 37, "I like time, i'm obsessed with it.", new DateTime(2023, 2, 6, 20, 0, 19, 289, DateTimeKind.Local).AddTicks(9492), "Good Times", "mr_hans" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 37);

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Comment", "Date", "Group", "UserName" },
                values: new object[] { 1, "I'm a good boy", new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Good Times", "mr_hans" });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Comment", "Date", "Group", "UserName" },
                values: new object[] { 2, "Time is crazy", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Good Times", "mr_hans" });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Comment", "Date", "Group", "UserName" },
                values: new object[] { 3, "I like time, i'm obsessed with it.", new DateTime(2023, 1, 29, 18, 0, 21, 0, DateTimeKind.Unspecified), "Good Times", "mr_hans" });
        }
    }
}
