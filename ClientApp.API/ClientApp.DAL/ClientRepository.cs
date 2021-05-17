using ClientApp.API.ClientApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;

namespace ClientApp.API.ClientApp.DAL
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationContext _dbContext;
        private IMemoryCache _cache;

        public ClientRepository(ApplicationContext dbContext, IMemoryCache cache)
        {
            _dbContext = dbContext;
            _cache = cache;
        }

        public Client GetClientById(int Id)
        {
            return _dbContext.Clients
                        .Where(c => c.Id == Id)
                        .Include(s => s.Card)
                        .Include(s => s.ClientGroup)
                        .Include(s => s.ClientType)
                        .Include(s => s.ClientContact)
                        .Include(s => s.User)
                        .FirstOrDefault();
        }

        public Card GetCardForClient(int cardId)
        {
            return _dbContext.Cards.Where(c => c.Id == cardId).FirstOrDefault();
        }

        public IEnumerable<Client> GetClientsByGroupId(int groupId)
        {
            return _dbContext.Clients
                        .Where(c => c.ClientGroup.Id == groupId)
                        .Include(s => s.ClientGroup)
                        .Include(s => s.ClientType)
                        .OrderByDescending(c => c.LastViewedDt)
                        .Take(20).ToList();
        }

        public IEnumerable<Client> GetLastViewedClientsByUserId(int userId)
        {
            return _dbContext.Clients
                        .Where(c => c.User.Id == userId)
                        .Include(s => s.ClientGroup)
                        .Include(s => s.ClientType)
                        .OrderByDescending(c => c.LastViewedDt)
                        .Take(20).ToList();
        }

        public bool IsClientExists(int Id)
        {
            return _dbContext.Clients.Any(c => c.Id == Id);
        }

        public void UpdateClient(Client client)
        { }

        public bool Save()
        {
            return (_dbContext.SaveChanges() >= 0);
        }
    }
}
