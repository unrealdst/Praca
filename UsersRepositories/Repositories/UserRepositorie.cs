using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DbContext.Models;
using UsersRepositories.Interfaces;
using UsersRepositories.Models;

namespace UsersRepositories.Repositories
{
    public class UserRepositorie : IUserRepositorie
    {
        private readonly ContextEntities dbContext;

        public UserRepositorie(ContextEntities dbContext)
        {
            this.dbContext = dbContext;

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<AspNetUsers, UserStorageModel>();
            });
        }

        public UserStorageModel GetUser(string id)
        {
            return dbContext
                .AspNetUsers
                .ProjectTo<UserStorageModel>()
                .Single(x => x.Id.Equals(id));
        }

        public IQueryable<UserStorageModel> GetUsers()
        {
            return dbContext
                .AspNetUsers
                .ProjectTo<UserStorageModel>();
        }
    }
}
