using JWTTemplateAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JWTTemplateAPI.Repositories
{
    public static class UserRepository
    {
        public static User GetUserByEmail(string email)
        {
            var users = new List<User>
            {
                new User
                {
                    Id=Guid.Parse("3f5cd4e8-288f-48bf-9006-65790e0aaf57"),
                    Email="pedro@octavio.com",
                    Password="pedropassword"
                },
                new User
                {
                    Id=Guid.Parse("f24e8836-0549-48f4-b9b0-c00b8ea0f9cf"),
                    Email="igor@silva.com",
                    Password="igorpassword"
                }
            };

            return users.Where(x => x.Email == email).FirstOrDefault();
        }
    }
}
