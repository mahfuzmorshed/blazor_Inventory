using Inventory.Server.Authorization;
using Inventory.Shared.Data;
using Inventory.Shared.Model;

namespace Inventory.Server.Models
{
    public interface IUserRepository
    {
        AuthenticateResponse Authenticate(AuthenticateRequest request);
        PagedResultT<User> GetUsers(string? name, int page);
        Task<User?> GetUser(int Id);
        Task<User> AddUser(User user);
        Task<User?> UpdateUser(User user);
        Task<User?> DeleteUser(int id);
    }
}