using System;
using System.Collections.Generic;

namespace ClientApp.API.Services.MailService
{
    public class MailService : IMailService
    {
        public void Send(string mailAddress, string messageText)
        {
            Send(new List<string> { mailAddress }, messageText);
        }

        public void Send(List<string> mailAddresses, string messageText)
        {
            //Отправка сообщения

            //MailMessage message = new MailMessage
            //{
            //    From = new MailAddress("noreply@clientapp.ru"),
            //    Body = messageText,
            //    Subject = "Изменение реквизитов клиента"
            //};

            //using (var smtp = new SmtpClient(GetSmtpHost()))...

            throw new NotImplementedException();
        }
    }
}
