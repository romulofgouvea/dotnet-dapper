using dapper.Shared.Commands;
using FluentValidator;

namespace dapper.Domain.StoreContext.Commands.AddressCommands.Inputs
{
    public class AddAddressComand : Notifiable, ICommand
    {
        public new bool Valid()
        {
            return base.Valid;
        }
    }
}
