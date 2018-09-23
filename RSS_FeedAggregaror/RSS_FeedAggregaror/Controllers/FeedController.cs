using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FeedAggregator.BLL.Interfaces;
using FeedAggregator.Shared.Dtos;
using FeedAggregator.Shared.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FeedAggregaror.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        private IFeedService _feedService;
        private ILogger _logger;

        public FeedController(IFeedService service, ILogger logger)
        {
            _feedService = service;
            _logger = logger;
        }

        // GET api/Feed
        [HttpPost]
        public async Task<ActionResult<IEnumerable<FeedDto>>> Post([FromBody] FeedRequest request)
        {
            try
            {
                var dto = await _feedService.AddFeedToUser(request);
                if (dto == null)
                {
                    _logger.LogWarning($"Feed was not created");
                    return BadRequest();
                }
                _logger.LogInformation($"Feed was created with id {dto.Id}");
            }
            catch (Exception)
            {
                _logger.LogError("Error ocurred while creating Feed ");
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

                if (!result)
                {
                    _logger.LogWarning($"Feed with id: {id} was not found");
                    return NotFound();
                }
                _logger.LogInformation($"Feed with id:{id} was deleted");
                return Ok();

            }
            catch(Exception)
            {
                _logger.LogError("Error ocurred while deleting Feed ");
                return StatusCode(500);
            }
        }
    }
}
