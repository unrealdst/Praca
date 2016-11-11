using System;
using System.Linq;
using System.Linq.Expressions;
using DbContext.Models;
using ProjectsRepositorie.Interfaces;
using ProjectsRepositorie.Models;

namespace ProjectsRepositorie.Repositories
{
    public class ClientRepositorie : IClientRepositorie
    {
        private readonly ContextEntities dbContext;

        public ClientRepositorie(ContextEntities context)
        {
            dbContext = context;
        }

        public ClientStorageModel GetClient(int id)
        {
            return dbContext
                .Client
                .Where(x => x.Id == id)
                .AsEnumerable()
                .Select(MappingClientToStorageModel)
                .First();
        }

        public IQueryable<ClientStorageModel> GetClients()
        {
            return dbContext
                .Client
                .Select(MappingClientToStorageModel)
                .AsQueryable();
        }

        private static Func<Client, ClientStorageModel> MappingClientToStorageModel
        {
            get
            {
                return x => new ClientStorageModel()
                {
                    Adress = x.Adress,
                    Country = x.Country,
                    CurrencyId = x.CurrencyId,
                    Name = x.Name,
                    Id = x.Id
                };
            }
        }
    }
}