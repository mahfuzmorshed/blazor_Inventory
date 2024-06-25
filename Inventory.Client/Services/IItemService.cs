using Inventory.Shared.Data;
using Inventory.Shared.Model;

namespace Inventory.Client.Services
{
    public interface IItemService
    {
        Task<PagedResultT<Item>> GetItems(string? name, string page);
        Task<Item> GetItem(int id);

        Task DeleteItem(int id);

        Task AddItem(Item Item);

        Task UpdateItem(Item Item);
    }
}