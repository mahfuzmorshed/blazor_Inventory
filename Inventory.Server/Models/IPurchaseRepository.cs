using Inventory.Shared.Data;
using Inventory.Shared.Model;

namespace Inventory.Server.Models
{
    public interface IPurchaseRepository
    {
        PagedResultT<PurchaseMaster> GetSearchByPurchase(string? name, int page);
        Task<PurchaseMaster?> GetPurchaseMaster(int PurchaseMasterId);
        Task<PurchaseMaster> AddPurchaseMaster(PurchaseMaster PurchaseMaster);
        Task<PurchaseMaster?> UpdatePurchaseMaster(PurchaseMaster PurchaseMaster);
        Task<PurchaseMaster?> DeletePurchaseMaster(int PurchaseMasterId);
    }
}