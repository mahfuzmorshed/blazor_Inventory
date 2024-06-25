using Inventory.Client.Shared;
using Inventory.Shared.Data;
using Inventory.Shared.Model;

namespace Inventory.Client.Services
{
    public class ItemService: IItemService
    {
        private readonly IHttpService _httpService;

        public ItemService(IHttpService httpService)
        {
            _httpService=httpService;
        }

        public async Task<PagedResultT<Item>> GetItems(string? name, string page)
        {
            return await _httpService.Get<PagedResultT<Item>>("api/Item" + "?page=" + page + "&name=" + name);
        }

        public async Task<Item> GetItem(int id)
        {
            return await _httpService.Get<Item>($"api/Item/{id}");
        }

        public async Task DeleteItem(int id)
        {
            await _httpService.Delete($"api/Item/{id}");
        }

        public async Task AddItem(Item Item)
        {
            await _httpService.Post($"api/Item", Item);
        }

        public async Task UpdateItem(Item Item)
        {
            await _httpService.Put($"api/Item", Item);
        }
    }
}