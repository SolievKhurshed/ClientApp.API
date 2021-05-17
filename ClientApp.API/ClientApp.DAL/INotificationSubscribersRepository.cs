using System.Collections.Generic;

namespace ClientApp.API.ClientApp.DAL
{
    public interface INotificationSubscribersRepository
    {
        List<string> GetSubscribersForClient(int clientId);
    }
}