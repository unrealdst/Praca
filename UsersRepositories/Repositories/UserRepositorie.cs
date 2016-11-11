using System;
using System.Linq;
using System.Linq.Expressions;
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

        }

        public UserStorageModel GetUser(string id)
        {
            return dbContext
                .AspNetUsers
                .Where(x => x.Id.Equals(id))   
                .Select(MappingUserToStorageModel)             
                .First();
        }

        public IQueryable<UserStorageModel> GetUsers()
        {
            return dbContext
                .AspNetUsers
                .Select(MappingUserToStorageModel);
        }

        public IQueryable<UserStorageModel> GetManagers()
        {
            return GetUsers();
        }

        private static Expression<Func<AspNetUsers, UserStorageModel>> MappingUserToStorageModel
        {
            get
            {
                return x => new UserStorageModel()
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    AccessFailedCount = x.AccessFailedCount,
                    Email = x.Email,
                    EmailConfirmed = x.EmailConfirmed,
                    LockoutEnabled = x.LockoutEnabled,
                    LockoutEndDateUtc = x.LockoutEndDateUtc,
                    PasswordHash = x.PasswordHash,
                    PhoneNumber = x.PhoneNumber,
                    PhoneNumberConfirmed = x.PhoneNumberConfirmed,
                    SecurityStamp = x.SecurityStamp,
                    TwoFactorEnabled = x.TwoFactorEnabled
                };
            }
        }
    }
}
