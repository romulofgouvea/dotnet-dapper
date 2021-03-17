using dapper.Domain.StoreContext.Entities;

namespace dapper.Domain.StoreContext.Repositories
{
    public interface ICustomerRepository
    {
        bool CheckExistsDocument(string cpf);
        bool CheckExistsEmail(string email);
        void Save(Customer customer);
    }
}
