using FeedAggregator.DAL.Entities;
using FeedParser.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FeedAggregator.DAL.Data
{
    public static class FeedAggregatorDbInitializator
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCollection>().HasData(
                new UserCollection() { Id = 1, UserId = "12345678" });

            modelBuilder.Entity<Feed>().HasData(
                new Feed()
                 { Id = 1, ChanellUrl = "http://rss.cnn.com/rss/cnn_topstories.rss", UserCollectionId = 1, FeedType = FeedType.RSS },
                new Feed()
                 { Id = 2, ChanellUrl = "http://newsrss.bbc.co.uk/rss/newsonline_world_edition/americas/rss.xml", UserCollectionId = 1, FeedType = FeedType.RSS });

            modelBuilder.Entity<FeedItem>().HasData(
                new FeedItem()
                 { Id = 1, Title = "FirstNews", Link = "Link1", Content = "Some text that is content", PublishDate = DateTime.Now, FeedCollectionId = 1 },
                 new FeedItem()
                 { Id = 2, Title = "SecondNews", Link = "Link2", Content = "Some text that is content", PublishDate = DateTime.Now, FeedCollectionId = 1 },
                 new FeedItem()
                 { Id = 3, Title = "ThirdNews", Link = "Link3", Content = "Some text that is content", PublishDate = DateTime.Now, FeedCollectionId = 2 },
                 new FeedItem()
                 { Id = 4, Title = "FourthNews", Link = "Link4", Content = "Some text that is content", PublishDate = DateTime.Now, FeedCollectionId = 2 }
                );
        }
    }
}