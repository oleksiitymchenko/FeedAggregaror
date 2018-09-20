using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FeedAggregator.BLL.Interfaces;
using FeedAggregator.Shared.Dtos;
using FeedAggregator.Shared.Requests;
using Microsoft.AspNetCore.Mvc;

namespace FeedAggregaror.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        private IFeedService _feedService;
        public FeedController(IFeedService service)
        {
            _feedService = service;
        }

        // GET api/Feed
        [HttpPost]
        public async Task<ActionResult<IEnumerable<FeedDto>>> Post([FromBody] FeedRequest request)
        {
            try
            {
                var dto = _feedService.AddFeedToUser(request);
            }
            catch(Exception)
            {
                return StatusCode(500);
            }
            return Ok();/*(Ok(await parser.Parse("http://blogzinet.free.fr/atom.php", FeedType.Atom)));*/
        }
    }
}
