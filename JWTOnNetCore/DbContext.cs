using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using JWTOnNetCore.Models;

namespace JWTOnNetCore
{
    public class DbContext
    {
        private readonly IList<User> _dbUser;

        public DbContext()
        {
            _dbUser = new Collection<User> {
                new User()
                {
                    Id = 1,
                    Email = "admin@abc.com",
                    Username = "admin",
                    Password = "abc125",
                    IsEmailValidate = true,
                    JoinAt = DateTime.Now,
                    LastLogin = DateTime.Now,
                    Roles = new []{"ADMIN"}
                },
                new User()
                {
                    Id = 2,
                    Email = "client@abc.com",
                    Username = "client",
                    Password = "abc125",
                    IsEmailValidate = true,
                    JoinAt = DateTime.Now,
                    LastLogin = DateTime.Now,
                    Roles = new []{"USER"}
                }
            };
        }

        public IList<User> Users()
        {
            return _dbUser;
        }
    }
}