using ClientApp.API.ClientApp.Data.Entities;
using System.Collections.Generic;

namespace ClientApp.API.ClientApp.DAL
{
    public interface IClientGroupRepository
    {
        IEnumerable<ClientGroup> GetClientGroups();
        ClientGroup GetClientGroupById(int clientGroupId);
    }
}