using Inventory.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Server.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Item> items => Set<Item>();
        public DbSet<PurchaseMaster> purchaseMasters => Set<PurchaseMaster>();
        public DbSet<PurchaseDetails> purchaseDetails => Set<PurchaseDetails>();
        public DbSet<User> Users => Set<User>();
    }
}