using dapper.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dapper.Tests.Commands
{
    [TestClass]
    public class CreateCustomerCommandTests
    {

        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();

            command.FirstName = "Dapper";
            command.LastName = "Example";
            command.Document = "12345678901";
            command.Email = "dapper@example.com";
            command.Phone = "999999999999";

            Assert.AreEqual(true, command.Valid());
        }
    }
}
