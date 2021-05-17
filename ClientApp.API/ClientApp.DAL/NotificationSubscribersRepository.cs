using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ClientApp.API.ClientApp.DAL
{
    public class NotificationSubscribersRepository : INotificationSubscribersRepository
    {
        private readonly ApplicationContext _dbContext;
        public NotificationSubscribersRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<string> GetSubscribersForClient(int clientId)
        {
            var subscribersFromDb = _dbContext.NotificationSubscribers
                            .Where(c => c.Client.Id == clientId && c.IsActive == true)
                            .Include(u => u.User);

            List<string> subscribers = new List<string>();
            foreach (var sub in subscribersFromDb)
            {
                subscribers.Add(sub.User.Email);
            }

            return subscribers;
        }
    }
}
