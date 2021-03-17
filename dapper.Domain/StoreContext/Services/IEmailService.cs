namespace dapper.Domain.StoreContext.Services
{
    public interface IEmailService
    {
        void send(string to, string from, string subject, string body);
    }
}
