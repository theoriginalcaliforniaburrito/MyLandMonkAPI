using System;
using Contracts;
using Entities;
using Entities.Extensions;
using Entities.Models;
using System.Linq;
using System.Collections.Generic;

namespace Repository
{
    class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {
        }

        public IEnumerable<User> GetAllUsers()
        {
            return FindAll()
                .OrderBy(user => user.LastName);
        }
        public User GetUserById(int UserId)
        {
            return FindByCondition(account => account.Id.Equals(UserId))
            .DefaultIfEmpty(new User())
            .FirstOrDefault();
        }

        public void CreateUser(User user)
        {
            Create(user);
            Save();
        }


        public void UpdateUser(User dbUser, User user)
        {
            dbUser.Map(user);
            Update(dbUser);
            Save();
        }

        public void DeleteUser(User user)
        {
            Delete(user);
            Save();
        }

    }
}