using System.Collections.Generic;
using System.Threading.Tasks;
using FeedParser.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FeedAggregaror.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionController : ControllerBase
    {
        // GET api/Feed
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> Get()
        {
            //var parser = new ItemsParser();

            return Ok();/*(Ok(await parser.Parse("http://blogzinet.free.fr/atom.php", FeedType.Atom)));*/
        }
    }
}
