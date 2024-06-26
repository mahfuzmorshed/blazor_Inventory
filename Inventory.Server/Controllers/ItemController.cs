using Inventory.Server.Authorization;
using Inventory.Server.Models;
using Inventory.Shared.Model;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;
        public ItemController(IItemRepository itemRepository) { 
        this._itemRepository = itemRepository;
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult GetItems([FromQuery] string? name, int page)
        {
            return Ok(_itemRepository.GetAllItems(name, page));
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetItem(int id)
        {
            return Ok(await _itemRepository.GetItem(id));
        }

        [HttpPost]
        public async Task<ActionResult> AddItem(Item obj)
        {
            return Ok(await _itemRepository.AddItem(obj));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateItem(Item obj)
        {
            return Ok(await _itemRepository.UpdateItem(obj));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(int id)
        {
            return Ok(await _itemRepository.DeleteItem(id));
        }
    }
}
