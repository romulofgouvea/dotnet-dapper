using dapper.Domain.StoreContext.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dapper.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var c = new Customer(
                "Romulo",
                "Gouvea",
                "romulo@rom.com",
                "12345678900",
                "32999611396",
                "Rua do dapper"
            );

            var order = new Order(c);
        }
    }
}
