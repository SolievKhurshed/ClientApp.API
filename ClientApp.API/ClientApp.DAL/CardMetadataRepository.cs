using ClientApp.API.ClientApp.Data.Entities;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClientApp.API.ClientApp.DAL
{
    public class CardMetadataRepository : ICardMetadataRepository
    {
        private readonly ApplicationContext _dbContext;
        private IMemoryCache _cache;

        public CardMetadataRepository(ApplicationContext dbContext, IMemoryCache cache)
        {
            _dbContext = dbContext;
            _cache = cache;
        }
        public CardMetadata GetCardMetadataById(int Id)
        {
            return GetAllCardsMetadata().Where(c => c.Id == Id).FirstOrDefault();
        }

        private IEnumerable<CardMetadata> GetAllCardsMetadata()
        {
            var key = "cards";
            var cachedCardsMetadata = _cache.Get<IEnumerable<CardMetadata>>(key);

            if (cachedCardsMetadata != null)
            {
                return cachedCardsMetadata;
            }
            else
            {
                var cardsMetadataFromDb = _dbContext.CardsMetadata.ToList();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromSeconds(60))
                        .SetSize(1024);

                _cache.Set(key, cardsMetadataFromDb, cacheEntryOptions);

                return cardsMetadataFromDb;
            }
        }
    }
}
