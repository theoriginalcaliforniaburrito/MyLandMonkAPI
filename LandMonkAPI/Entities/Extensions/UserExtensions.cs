using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Extensions
{
    public static class UserExtensions
    {
        public static void Map(this User dbUser, User user)
        {
            dbUser.FirstName = user.FirstName;
            dbUser.LastName = user.LastName;
            dbUser.Email = user.Email;
            dbUser.Username = user.Username;
            dbUser.Password = user.Password;
        }
    }
}

