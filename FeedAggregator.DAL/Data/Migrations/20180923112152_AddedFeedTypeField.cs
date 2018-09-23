using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FeedAggregator.DAL.Data.Migrations
{
    public partial class AddedFeedTypeField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FeedType",
                table: "FeedCollections",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "FeedItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2018, 9, 23, 14, 21, 50, 659, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "FeedItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2018, 9, 23, 14, 21, 50, 673, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "FeedItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishDate",
                value: new DateTime(2018, 9, 23, 14, 21, 50, 673, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "FeedItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "PublishDate",
                value: new DateTime(2018, 9, 23, 14, 21, 50, 673, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FeedType",
                table: "FeedCollections");

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
    }
}
