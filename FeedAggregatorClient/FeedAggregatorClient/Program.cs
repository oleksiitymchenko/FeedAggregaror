using FeedAggregator.Shared.Dtos;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Linq;

namespace FeedAggregatorClient
{
    class Program
    {

        private static HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            var address = new Uri("http://localhost:5000/api/");
            while (true)
            {
                Console.Clear();
                Console.WriteLine("[1] New UserCollection");
                Console.WriteLine("[2] Delete UserCollection");
                Console.WriteLine("[3] Get UserCollection by id");
                Console.WriteLine("[4] Subscribe to feed");
                Console.WriteLine("[5] Unsubscribe from feed");
                try
                {
                    switch (Console.ReadLine())
                    {
                        case "1":
                            {
                                StringContent content = new StringContent("");
                                var responce = client.PostAsync(address+ "collection", content).Result;

                                var userId = JsonConvert.DeserializeObject<UserCollectionDto>(responce.Content.ReadAsStringAsync().Result);
                                Console.WriteLine($"New user id: {userId.UserId}");
                                Console.WriteLine($"status code: {responce.StatusCode}");
                                Console.ReadLine();
                                break;
                            }
                        case "2":
                            {
                                Console.WriteLine("Input usercollection int id");
                                var id = int.Parse(Console.ReadLine());
                                var responce = client.DeleteAsync($"{address}collection/{id}").Result;
                                Console.WriteLine($"status code: {responce.StatusCode}");
                                Console.ReadLine();
                                break;
                            }
                        case "3":
                            {
                                Console.WriteLine("input userId");
                                var id = Console.ReadLine();

                                var responce = client.GetAsync($"{address}collection/{id}").Result;

                                Console.WriteLine($"status code: {responce.StatusCode}");
                                var userCollection = JsonConvert.DeserializeObject<UserCollectionDto>(responce.Content.ReadAsStringAsync().Result);
                                Console.WriteLine($"UserID: {userCollection.UserId}");
                                Console.WriteLine($"EntityID: {userCollection.Id}");
                                userCollection.FeedCollections.ToList().ForEach( feed => DrawFeed(feed));
                                Console.ReadLine();
                                break;
                            }
                        case "4":
                            {
                                Console.WriteLine("input user id");
                                var id = Console.ReadLine();

                                Console.WriteLine("input type(RSS or Atom)");
                                var feedtype = Console.ReadLine();

                                Console.WriteLine("input link");
                                var link = Console.ReadLine();

                                var request = new
                                {
                                    userId = id,
                                    feedType = feedtype,
                                    chanellUrl = link
                                };

                                var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

                                var responce = client.PostAsync($"{address}feed", content).Result;

                                Console.WriteLine($"status code: {responce.StatusCode}");
                                DrawFeed(JsonConvert.DeserializeObject<FeedDto>(responce.Content.ReadAsStringAsync().Result));
                                Console.ReadLine();
                                break;
                            }
                        case "5":
                            {
                                Console.WriteLine("input feed int id");
                                var id = int.Parse(Console.ReadLine());

                                var responce = client.DeleteAsync($"{address}feed/{id}").Result;

                                Console.WriteLine($"status code: {responce.StatusCode}");
                                Console.WriteLine(responce.Content.ReadAsStringAsync().Result);
                                Console.ReadLine();
                                break;
                            }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
            }
        }
        public static void DrawFeed(FeedDto feed)
        {
            Console.WriteLine();
            Console.WriteLine($"\t FeedID: {feed.Id}");
            Console.WriteLine($"\t Feed chanell: {feed.ChanellUrl}");
            feed.FeedItems.ToList().ForEach(item => DrawFeedItem(item));
        }

        public static void DrawFeedItem(FeedItemDto item)
        {
            Console.WriteLine($"\t\t ItemId {item.Id}");
            Console.WriteLine($"\t\t Title: {item.Title}");
            Console.WriteLine($"\t\t Link: {item.Link}");
            Console.WriteLine($"\t\t Content: {item.Content}");
            Console.WriteLine($"\t\t Date: {item.PublishDate}");
        }
    }
}
