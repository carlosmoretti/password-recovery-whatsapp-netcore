using System;

namespace WhatsAppHelper
{
    public interface IWhatsAppService
    {
        void Send(string phonenumber, string token);
    }
}
