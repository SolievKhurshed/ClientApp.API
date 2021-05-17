using ClientApp.API.ClientApp.Data.Entities;

namespace ClientApp.API.ClientApp.DAL
{
    public interface ICardMetadataRepository
    {
        CardMetadata GetCardMetadataById(int Id);
    }
}