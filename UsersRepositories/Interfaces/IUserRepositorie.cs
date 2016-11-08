using System.Linq;
using UsersRepositories.Models;

namespace UsersRepositories.Interfaces
{
    public interface IUserRepositorie
    {
        UserStorageModel GetUser(string id);

        IQueryable<UserStorageModel> GetUsers();
    }
}
