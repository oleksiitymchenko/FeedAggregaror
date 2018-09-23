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

        // GET api/collection
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

        // POST api/collection
        [HttpPost]
        public async Task<ActionResult<UserCollectionDto>> Create()
        {
            try
            {
                var dto = await _userCollectionService.CreateUserCollectionAsync();
                return Ok(dto);
            }
            catch(Exception)
            {
                return StatusCode(500);
            }
        }

        // DEL api/collection/userid
        [HttpDelete]
        public async Task<ActionResult> Delete(int userId)
        {
            try
            {
                var result = await _userCollectionService.DeleteUserCollectionAsync(userId);
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
