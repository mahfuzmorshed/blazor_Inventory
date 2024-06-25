using Inventory.Shared.Data;
using Inventory.Shared.Model;

namespace Inventory.Server.Models
{
    public interface IItemRepository
    {
        PagedResultT<Item> GetAllItems(string? name, int page);
        Task<Item?> GetItem(int personId);
        Task<Item> AddItem(Item person);
        Task<Item?> UpdateItem(Item person);
        Task<Item?> DeleteItem(int personId);
    }
}