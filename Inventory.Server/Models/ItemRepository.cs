using Inventory.Shared.Data;
using Inventory.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Server.Models
{
    public class ItemRepository:IItemRepository
    {
        private readonly AppDbContext _appDbContext;

        public ItemRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Item> AddItem(Item Item)
        {
            var result = await _appDbContext.items.AddAsync(Item);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Item?> DeleteItem(int ItemId)
        {
            var result = await _appDbContext.items.FirstOrDefaultAsync(p => p.ItemId==ItemId);
            if (result!=null)
            {
                _appDbContext.items.Remove(result);
                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Item not found");
            }
            return result;
        }

        public async Task<Item?> GetItem(int ItemId)
        {
            var result = await _appDbContext.items
                //.Include(p => p.Addresses)
                .FirstOrDefaultAsync(p => p.ItemId==ItemId);
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new KeyNotFoundException("Item not found");
            }
        }

        public PagedResultT<Item> GetAllItems(string? name, int page)
        {
            int pageSize = 5;
            
            if (name != null)
            {
                return _appDbContext.items
                    .Where(p => p.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase))
                    .OrderBy(p => p.ItemId)
                    //.Include(p => p.Addresses)
                    .GetPaged(page, pageSize);
            }
            else
            {
                return _appDbContext.items
                    .OrderBy(p => p.ItemId)
                    //.Include(p => p.Addresses)
                    .GetPaged(page, pageSize);
            }
        }

        public async Task<Item?> UpdateItem(Item Item)
        {
            var result = await _appDbContext.items
                //.Include("Addresses")
                .FirstOrDefaultAsync(p => p.ItemId==Item.ItemId);
            if (result!=null)
            {
                // Update existing Item
                _appDbContext.Entry(result).CurrentValues.SetValues(Item);
                
                
                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Item not found");
            }
            return result;
        }
    }
}