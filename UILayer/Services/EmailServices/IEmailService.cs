namespace UILayer.Services.EmailServices
{
    public interface IEmailService
    {
        Task SendEmailAsync(string name, string email, string subject, string message);
    }

}
