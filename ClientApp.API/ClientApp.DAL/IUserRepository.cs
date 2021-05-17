using ClientApp.API.ClientApp.Data.Entities;
using System.Collections.Generic;

namespace ClientApp.API.ClientApp.DAL
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
    }
}
