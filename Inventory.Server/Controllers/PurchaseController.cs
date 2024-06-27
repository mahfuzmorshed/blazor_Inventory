using Inventory.Server.Authorization;
using Inventory.Server.Models;
using Inventory.Shared.Model;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseRepository _purchaseRepository;
        public PurchaseController(IPurchaseRepository purchaseRepository)
        {
            this._purchaseRepository = purchaseRepository;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetSearchByPurchase([FromQuery] string? name, int page)
        {
            return Ok(_purchaseRepository.GetSearchByPurchase(name, page));
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetPurchaseMaster(int id)
        {
            return Ok(await _purchaseRepository.GetPurchaseMaster(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePurchaseMaster(int id)
        {
            return Ok(await _purchaseRepository.DeletePurchaseMaster(id));
        }

        [HttpPost]
        public async Task<ActionResult> AddPurchaseMaster(PurchaseMaster obj)
        {
            return Ok(await _purchaseRepository.AddPurchaseMaster(obj));
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePurchaseMaster(PurchaseMaster obj)
        {
            return Ok(await _purchaseRepository.UpdatePurchaseMaster(obj));
        }
    }
}
