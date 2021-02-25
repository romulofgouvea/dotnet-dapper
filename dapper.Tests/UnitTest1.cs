using dapper.Domain.StoreContext.Entities;
using dapper.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dapper.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var name = new Name("Dotnet", "Dapper");
            var email = new Email("dapper@email.com");
            var document = new Document("12345678900");

            var c = new Customer(name, email, document, "");

            var order = new Order(c);

            //Criar os produtos
            var mouse = new Product("Mouse", "rato", "img.png", 10, 10);

            //Adicionar nos pedidos
            order.AddItem(mouse, 5);

            //Pagar o pedido
            order.Pay();

            //Enviar o pedido
            order.Ship();

            //Cancelar o pedido
            order.Cancel();
        }
    }
}
