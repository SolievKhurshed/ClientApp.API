using System.Collections.Generic;

namespace ClientApp.API.Services.MailService
{
    public interface IMailService
    {
        void Send(string mailAddress, string messageText);
        void Send(List<string> mailAddresses, string messageText);
    }
}
