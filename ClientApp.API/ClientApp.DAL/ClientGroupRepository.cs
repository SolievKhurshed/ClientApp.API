using ClientApp.API.ClientApp.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ClientApp.API.ClientApp.DAL
{
    public class ClientGroupRepository : IClientGroupRepository
    {
        private readonly ApplicationContext _dbContext;

        public ClientGroupRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ClientGroup GetClientGroupById(int clientGroupId)
        {
            return _dbContext.ClientGroups
                .Where(c => c.Id == clientGroupId)
                .FirstOrDefault();
        }

        public IEnumerable<ClientGroup> GetClientGroups()
        {
            return _dbContext.ClientGroups;
        }
    }
}
