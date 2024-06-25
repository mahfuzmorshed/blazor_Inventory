using Inventory.Shared.Model;
using Bogus;
using Inventory.Server.Models;

namespace Inventory.Server.Model
{
    public class DataGenerator
    {
        public static void Initialize(AppDbContext appDbContext)
        {
            Randomizer.Seed = new Random(32321);
            appDbContext.Database.EnsureDeleted();
            appDbContext.Database.EnsureCreated();

            if (!(appDbContext.Users.Any()))
            {
                var testUsers = new Faker<User>()
                    .RuleFor(u => u.FirstName, u => u.Name.FirstName())
                    .RuleFor(u => u.LastName, u => u.Name.LastName())
                    .RuleFor(u => u.Username, u => u.Internet.UserName())
                    .RuleFor(u => u.Password, u => u.Internet.Password());
                var users = testUsers.Generate(4);

                User customUser = new User(){
                    FirstName = "Mahfuz",
                    LastName = "Morshed",
                    Username = "admin",
                    Password = "admin"
                };

                users.Add(customUser);

                foreach (User u in users)
                {
                    u.PasswordHash = BCrypt.Net.BCrypt.HashPassword(u.Password);
                    u.Password = "**********";
                    appDbContext.Users.Add(u);
                }
                appDbContext.SaveChanges();
            }
        }
    }
}