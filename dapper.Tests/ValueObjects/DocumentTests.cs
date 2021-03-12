using dapper.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dapper.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        [TestMethod]
        public void ShouldReturnNotificationWhenDocumentIsNotValid()
        {
            var document = new Document("12345678900");

            Assert.AreEqual(false, document.Valid);
            Assert.AreEqual(1, document.Notifications.Count);
        }

        [TestMethod]
        public void ShouldReturnNotificationWhenDocumentIsValid()
        {
            var document = new Document("05921461032");

            Assert.AreEqual(true, document.Valid);
            Assert.AreEqual(0, document.Notifications.Count);
        }

    }
}
