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
                var dto = await _feedService.AddFeedToUser(request);
                if (dto == null) return BadRequest();
            }
            catch(Exception)
            {
                return StatusCode(500);
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await _feedService.DeleteFeedFromUserAsync(id);

                if (!result) return NotFound();

                return Ok();
            }
            catch(Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
