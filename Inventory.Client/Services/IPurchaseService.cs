using Inventory.Shared.Data;
using Inventory.Shared.Model;

namespace Inventory.Client.Services
{
    public interface IPurchaseService
    {
        Task<PagedResultT<PurchaseMaster>> GetSearchByPurchase(string? name, string page);
        Task<PurchaseMaster> GetPurchaseMaster(int id);

        Task DeletePurchaseMaster(int id);

        Task AddPurchaseMaster(PurchaseMaster PurchaseMaster);

        Task UpdatePurchaseMaster(PurchaseMaster PurchaseMaster);
    }
}