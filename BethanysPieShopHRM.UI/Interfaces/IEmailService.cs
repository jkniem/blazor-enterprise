using BethanysPieShopHRM.Shared;

namespace BethanysPieShopHRM.UI.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(Email email);
    }
}
