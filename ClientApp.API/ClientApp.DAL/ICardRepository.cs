using ClientApp.API.ClientApp.Data.Entities;

namespace ClientApp.API.ClientApp.DAL
{
    public interface ICardRepository    {
        
        Card GetCardById(int Id);
    }
}