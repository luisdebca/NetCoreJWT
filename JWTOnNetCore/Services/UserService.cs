using System;
using System.Collections.Generic;
using System.Linq;
using JWTOnNetCore.Models;

namespace JWTOnNetCore.Services
{
    public interface IUserService
    {
        User FindById(long id);
        IList<User> FindAll();
    }
    
    public class UserService : IUserService
    {
        private DbContext _context;

        public UserService()
        {
            _context = new DbContext();
        }

        public User FindById(long id)
        {
            try
            {
                return _context.Users().First(u => u.Id == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public IList<User> FindAll()
        {
            try
            {
                return _context.Users();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}