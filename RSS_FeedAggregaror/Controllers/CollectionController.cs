using System;
using System.Threading.Tasks;
using FeedAggregator.BLL.Interfaces;
using FeedAggregator.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FeedAggregaror.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionController : ControllerBase
    {
        private IUserCollectionService _userCollectionService;

        public CollectionController(IUserCollectionService service)
        {
            _userCollectionService = service;
        }

        // GET api/feed
        [HttpGet("{id}")]
        public async Task<ActionResult<UserCollectionDto>> Get(string id)
        {
            try
            {
                var dto = await _userCollectionService.GetUserCollectionByUserIdAsync(id);
                if (dto == null) return NoContent();
                return Ok(dto);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
