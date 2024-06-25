using Microsoft.AspNetCore.Mvc;

namespace Inventory.Server.Controllers
{
    public class PurchaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
