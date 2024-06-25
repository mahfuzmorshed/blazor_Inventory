using Inventory.Shared.Data;
using Inventory.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Server.Models
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly AppDbContext _appDbContext;

        public PurchaseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<PurchaseMaster> AddPurchaseMaster(PurchaseMaster PurchaseMaster)
        {
            var result = await _appDbContext.purchaseMasters.AddAsync(PurchaseMaster);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<PurchaseMaster?> DeletePurchaseMaster(int PurchaseMasterId)
        {
            var result = await _appDbContext.purchaseMasters.FirstOrDefaultAsync(p => p.Id == PurchaseMasterId);
            if (result != null)
            {
                _appDbContext.purchaseMasters.Remove(result);
                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("PurchaseMaster not found");
            }
            return result;
        }

        public async Task<PurchaseMaster?> GetPurchaseMaster(int PurchaseMasterId)
        {
            var result = await _appDbContext.purchaseMasters
                .Include(p => p.purchaseDetails)
                .FirstOrDefaultAsync(p => p.Id == PurchaseMasterId);
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new KeyNotFoundException("PurchaseMaster not found");
            }
        }

        public PagedResultT<PurchaseMaster> GetSearchByPurchase(string? name, int page)
        {
            int pageSize = 5;

            if (name != null)
            {
                return _appDbContext.purchaseMasters
                    .Where(p => p.InvoiceNo.Contains(name, StringComparison.CurrentCultureIgnoreCase)) 
                    .OrderBy(p => p.Id)
                    .Include(p => p.purchaseDetails)
                    .GetPaged(page, pageSize);
            }
            else
            {
                return _appDbContext.purchaseMasters
                    .OrderBy(p => p.Id)
                    .Include(p => p.purchaseDetails)
                    .GetPaged(page, pageSize);
            }
        }

        public async Task<PurchaseMaster?> UpdatePurchaseMaster(PurchaseMaster PurchaseMaster)
        {
            var result = await _appDbContext.purchaseMasters.Include("purchaseDetails").FirstOrDefaultAsync(p => p.Id == PurchaseMaster.Id);
            if (result != null)
            {
                // Update existing PurchaseMaster
                _appDbContext.Entry(result).CurrentValues.SetValues(PurchaseMaster);

                // Remove deleted addresses
                foreach (var existingAddress in result.purchaseDetails.ToList())
                {
                    if (!PurchaseMaster.purchaseDetails.Any(o => o.Id == existingAddress.Id))
                        _appDbContext.purchaseDetails.Remove(existingAddress);
                }

                // Update and Insert Addresses
                foreach (var addressModel in PurchaseMaster.purchaseDetails)
                {
                    var existingAddress = result.purchaseDetails
                        .Where(a => a.Id == addressModel.Id)
                        .SingleOrDefault();
                    if (existingAddress != null)
                        _appDbContext.Entry(existingAddress).CurrentValues.SetValues(addressModel);
                    else
                    {
                        var newAddress = new PurchaseDetails
                        {
                            ItemId = addressModel.ItemId,
                            MasterId = addressModel.MasterId,
                            Price = addressModel.Price,
                            Quantity = addressModel.Quantity,
                        };
                        result.purchaseDetails.Add(newAddress);
                    }
                }
                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("PurchaseMaster not found");
            }
            return result;
        }
    }
}