using Inventory.Server.Authorization;
using Inventory.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : Controller
    {
        private readonly IItemRepository _itemRepository;
        public ItemController(IItemRepository itemRepository) { 
        this._itemRepository = itemRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
