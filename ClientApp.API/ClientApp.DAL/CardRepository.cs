using ClientApp.API.ClientApp.Data.Entities;
using System;

namespace ClientApp.API.ClientApp.DAL
{
    public class CardRepository : ICardRepository
    {
        private readonly ApplicationContext _dbContext;

        public CardRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Card GetCardById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
