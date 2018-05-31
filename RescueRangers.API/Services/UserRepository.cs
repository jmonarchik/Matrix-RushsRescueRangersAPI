using Microsoft.EntityFrameworkCore;
using RescueRangers.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RescueRangers.API.Services
{
    public class UserRepository : IUserRepository
    {
        private WebApiDbContext _context;
        public UserRepository(WebApiDbContext context)
        {
            _context = context;
        }
        public void AddUser(User user)
        {
            _context.Users.Add(user);
        }
        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
 