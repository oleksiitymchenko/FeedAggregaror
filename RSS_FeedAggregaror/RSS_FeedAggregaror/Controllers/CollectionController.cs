using System;
using System.Threading.Tasks;
using FeedAggregator.BLL.Interfaces;
using FeedAggregator.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FeedAggregaror.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionController : ControllerBase
    {
        private IUserCollectionService _userCollectionService;
        private ILogger _logger;
        public CollectionController(IUserCollectionService service, ILogger logger)
        {
            _userCollectionService = service;
            _logger = logger;
        }

        // GET api/collection
        [HttpGet("{id}")]
        public async Task<ActionResult<UserCollectionDto>> Get(string id)
        {
            try
            {
                var dto = await _userCollectionService.GetUserCollectionByUserIdAsync(id);
                if (dto == null)
                {
                    _logger.LogWarning($"UserCollection id:{id} not found");
                    return NoContent();
                }
                _logger.LogInformation($"UserCollection id:{id} is found");
                return Ok(dto);
            }
            catch (Exception)
            {
                _logger.LogError($"Error ocurred while seeking for UserCollection {id}");
                return StatusCode(500);
            }
        }

        // POST api/collection
        [HttpPost]
        public async Task<ActionResult<UserCollectionDto>> Create()
        {
            try
            {
                var dto = await _userCollectionService.CreateUserCollectionAsync();
                _logger.LogInformation($"UserCollection id:{dto.Id} is created");
                return Ok(dto);
            }
            catch (Exception)
            {
                _logger.LogError($"Error ocurred while creating UserCollection");
                return StatusCode(500);
            }
        }

        // DEL api/collection/userid
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await _userCollectionService.DeleteUserCollectionAsync(id);
                if (!result)
                {
                    _logger.LogWarning($"UserCollection id:{id} not found");
                    return NotFound();
                }
                _logger.LogInformation($"UserCollection id:{id} is deleted");
                return Ok();
            }
            catch(Exception)
            {
                _logger.LogError($"Error ocurred while deleting UserCollection");
                return StatusCode(500);
            }
        }
    }
}
