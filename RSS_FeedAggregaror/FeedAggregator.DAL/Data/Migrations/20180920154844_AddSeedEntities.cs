using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FeedAggregator.DAL.Data.Migrations
{
    public partial class AddSeedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserCollections",
                columns: new[] { "Id", "UserId" },
                values: new object[] { 1, "12345678" });

            migrationBuilder.InsertData(
                table: "FeedCollections",
                columns: new[] { "Id", "ChanellUrl", "UserCollectionId" },
                values: new object[] { 1, "http://rss.cnn.com/rss/cnn_topstories.rss", 1 });

            migrationBuilder.InsertData(
                table: "FeedCollections",
                columns: new[] { "Id", "ChanellUrl", "UserCollectionId" },
                values: new object[] { 2, "http://newsrss.bbc.co.uk/rss/newsonline_world_edition/americas/rss.xml", 1 });

            migrationBuilder.InsertData(
                table: "FeedItems",
                columns: new[] { "Id", "Content", "FeedCollectionId", "Link", "PublishDate", "Title" },
                values: new object[,]
                {
                    { 1, "Some text that is content", 1, "Link1", new DateTime(2018, 9, 20, 18, 48, 43, 707, DateTimeKind.Local), "FirstNews" },
                    { 2, "Some text that is content", 1, "Link2", new DateTime(2018, 9, 20, 18, 48, 43, 720, DateTimeKind.Local), "SecondNews" },
                    { 3, "Some text that is content", 2, "Link3", new DateTime(2018, 9, 20, 18, 48, 43, 720, DateTimeKind.Local), "ThirdNews" },
                    { 4, "Some text that is content", 2, "Link4", new DateTime(2018, 9, 20, 18, 48, 43, 720, DateTimeKind.Local), "FourthNews" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FeedItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FeedItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FeedItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FeedItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FeedCollections",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FeedCollections",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserCollections",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
