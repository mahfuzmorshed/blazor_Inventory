using Inventory.Server.Authorization;
using Inventory.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseRepository _purchaseRepository;
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetSearchByPurchase([FromQuery] string? name, int page)
        {
            return Ok(_purchaseRepository.GetSearchByPurchase(name, page));
        }
    }
}
