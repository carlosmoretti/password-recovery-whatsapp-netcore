using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace WhatsAppHelper.Impl
{
    public class WhatsAppService : IWhatsAppService
    {
        IConfiguration _config;
        public WhatsAppService(IConfiguration config)
        {
            _config = config;
        }
        public void Send(string phonenumber, string token)
        {
            var accountSid = _config.GetSection("TwilioAccountSid").Value;
            var authToken = _config.GetSection("TwilioAuthToken").Value;
            var origin = _config.GetSection("TwilioOrigin").Value;
            var messageToken = $"O seu token para alteração de senha é {token}, faça a troca de senha pela aplicação. Este token é válido por 1 hora. Obrigado =)";

            TwilioClient.Init(accountSid, authToken);

            var messageOptions = new CreateMessageOptions(
                new PhoneNumber($"whatsapp:{phonenumber}"));
            messageOptions.From = new PhoneNumber(origin);
            messageOptions.Body = messageToken;

            var message = MessageResource.Create(messageOptions);
            Console.WriteLine(message.Body);
        }
    }
}
