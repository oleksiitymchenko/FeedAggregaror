using FeedParser.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FeedParser
{
    public class ItemsParser
    {
        public async Task<IEnumerable<Item>> Parse(string url, FeedType feedType)
        {
            switch (feedType)
            {
                case FeedType.RSS:
                    return await Task.FromResult(ParseRss(url));
                case FeedType.Atom:
                    return await Task.FromResult(ParseAtom(url));
                default:
                    throw new NotSupportedException(string.Format("{0} is not supported", feedType.ToString()));
            }
        }

        private IEnumerable<Item> ParseAtom(string url)
        {
            try
            {
                XDocument doc = XDocument.Load(url);

                var entities = doc.Root.Elements()
                                  .Where( o => o.Name.LocalName == "entry")
                                  .Select(o => NormalizeAtomItem(o));
                return entities;
            }
            catch
            {
                throw new Exception("Something gone wrong in feedparser");
            }
        }

        private IEnumerable<Item> ParseRss(string url)
        {
            try
            {
                XDocument doc = XDocument.Load(url);

                var entities = doc.Root.Element("channel")
                                      .Elements("item")
                                      .Select( o => NormalizeRssItem(o));
                return entities;
            }
            catch
            {
                throw new Exception("Something gone wrong in feedparser");
            }
        }

        private Item NormalizeAtomItem(XElement entryNode)
        {
            return new Item
            {
                FeedType = FeedType.Atom,
                Content = entryNode.Elements().FirstOrDefault( o => o.Name.LocalName == "content").Value,
                Link = entryNode.Elements().FirstOrDefault(o => o.Name.LocalName == "link").Attribute("href").Value,
                PublishDate = ParseDate(entryNode.Elements().FirstOrDefault(o => o.Name.LocalName == "updated").Value),
                Title = entryNode.Elements().FirstOrDefault(o => o.Name.LocalName == "title").Value
            };
        }

        private Item NormalizeRssItem(XElement itemNode)
        {
            return new Item
            {
                FeedType = FeedType.RSS,
                Content = itemNode.Element("description").Value,
                Link = itemNode.Element("link").Value,
                PublishDate = ParseDate(itemNode.Element("pubDate").Value),
                Title = itemNode.Element("title").Value
            };
        }

        private DateTime ParseDate(string date)
        {
            DateTime result;
            if (DateTime.TryParse(date, out result))
                return result;
            else
                return DateTime.MinValue;
        }
    }
}
