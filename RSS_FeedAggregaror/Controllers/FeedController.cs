using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeedParser;
using FeedParser.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FeedAggregaror.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        // GET api/Feed
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> Get()
        {
            var parser = new ItemsParser();

            return (Ok(await parser.Parse("http://blogzinet.free.fr/atom.php", FeedType.Atom)));
        }
    }
}
