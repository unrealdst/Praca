using ProjectsRepositorie.Models;

namespace ProjectsRepositorie.Interfaces
{
    public interface IClientRepositorie
    {
        ClientStorageModel GetClient(int id);
    }
}