using NUnit.Framework;
using Moq;
using Microsoft.Extensions.Logging;
using ContactManagement.API.Services;
using ContactManagement.API.Models;

namespace ContactManagement.Tests
{
    public class ContactServiceTests
    {
        private ContactService _service;
        private Mock<ILogger<ContactService>> _mockLogger;

        [SetUp]
        public void Setup()
        {
            _mockLogger = new Mock<ILogger<ContactService>>();
            _service = new ContactService(); // if no logger constructor
        }

        [Test]
        public void AddContact_ShouldAddSuccessfully()
        {
            var contact = new ContactInfo
            {
                FirstName = "Test",
                Email = "test@mail.com"
            };

            _service.AddContact(contact);

            var result = _service.GetAllContacts();

            Assert.AreEqual(1, result.Count);
        }
    }
}