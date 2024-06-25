using Inventory.Client.Shared;
using Inventory.Shared.Data;
using Inventory.Shared.Model;

namespace Inventory.Client.Services
{
    public interface IUserService
    {
        User User {get; }
        Task Initialize();
        Task Login(Login model);
        Task Logout();
        Task<PagedResultT<User>> GetUsers(string? name, string page);
        Task<User> GetUser(int id);
        Task DeleteUser(int id);
        Task AddUser(User user);
        Task UpdateUser(User user);
    }
}