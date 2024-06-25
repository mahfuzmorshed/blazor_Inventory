using Inventory.Client.Shared;
using Inventory.Shared.Data;
using Inventory.Shared.Model;
using Inventory.Client.Services;
using Microsoft.AspNetCore.Components;

namespace Inventory.Client.Services
{
    public class PurchaseService: IPurchaseService
    {
        private IHttpService _httpService;

        public PurchaseService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<PagedResultT<PurchaseMaster>> GetSearchByPurchase(string? name, string page)
        {
            return await _httpService.Get<PagedResultT<PurchaseMaster>>("api/Purchase" + "?page=" + page + "&name=" + name);
        }

        public async Task<PurchaseMaster> GetPurchaseMaster(int id)
        {
            return await _httpService.Get<PurchaseMaster>($"api/Purchase/{id}");
        }

        public async Task DeletePurchaseMaster(int id)
        {
            await _httpService.Delete($"api/Purchase/{id}");
        }

        public async Task AddPurchaseMaster(PurchaseMaster PurchaseMaster)
        {
            await _httpService.Post($"api/Purchase", PurchaseMaster);
        }

        public async Task UpdatePurchaseMaster(PurchaseMaster PurchaseMaster)
        {
            await _httpService.Put($"api/Purchase", PurchaseMaster);
        }
    }
}