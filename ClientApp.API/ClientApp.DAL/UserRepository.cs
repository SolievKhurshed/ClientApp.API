using ClientApp.API.ClientApp.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ClientApp.API.ClientApp.DAL
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _dbContext;

        public UserRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<User> GetUsers()
        {
            return _dbContext.Users.ToList();
        }
    }
}
