using ClientApp.API.ClientApp.Data.Entities;
using System.Collections.Generic;

namespace ClientApp.API.ClientApp.DAL
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetLastViewedClientsByUserId(int userId);
        IEnumerable<Client> GetClientsByGroupId(int groupId);
        Client GetClientById(int Id);
        void UpdateClient(Client client);
        bool IsClientExists(int Id);
        bool Save();
    }
}
