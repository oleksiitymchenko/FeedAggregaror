using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FeedAggregator.DAL.Data.Migrations
{
    public partial class RenamedFeedCollectionToFeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FeedItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2018, 9, 20, 19, 52, 9, 678, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "FeedItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2018, 9, 20, 19, 52, 9, 689, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "FeedItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishDate",
                value: new DateTime(2018, 9, 20, 19, 52, 9, 689, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "FeedItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "PublishDate",
                value: new DateTime(2018, 9, 20, 19, 52, 9, 689, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FeedItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2018, 9, 20, 18, 48, 43, 707, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "FeedItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2018, 9, 20, 18, 48, 43, 720, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "FeedItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishDate",
                value: new DateTime(2018, 9, 20, 18, 48, 43, 720, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "FeedItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "PublishDate",
                value: new DateTime(2018, 9, 20, 18, 48, 43, 720, DateTimeKind.Local));
        }
    }
}
