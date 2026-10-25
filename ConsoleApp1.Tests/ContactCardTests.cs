
using System;
using ContactCardApp;
using Xunit;

namespace ConsoleApp1.Tests
{
    public class ContactCardTests
    {
        private static ContactCard[] CreateContacts()
        {
            return new ContactCard[]
            {
                new ContactCard
                {
                    name = "Akash",
                    PhNo = 9334445588L,
                    email = "akash@gmail.com"
                },
                new ContactCard
                {
                    name = "Sidharth",
                    PhNo = 9876543210L,
                    email = "sidharth@gmail.com"
                },
                new ContactCard
                {
                    name = "Rahul",
                    PhNo = 9125456780L,
                    email = "rahul@gmail.com"
                },
                new ContactCard
                {
                    name = "Meera",
                    PhNo = 9188776655L,
                    email = "meera@gmail.com"
                },
                new ContactCard
                {
                    name = "Arun",
                    PhNo = 9090909093L,
                    email = "arun@gmail.com"
                }
            };
        }

        [Fact]
        public void FindContact_WhenNameExists_ReturnsContact()
        {
            // Arrange
            var contacts = CreateContacts();

            // Act
            var result = ContactSearchService.FindContact(
                contacts, "Akash");

            // Assert
            Assert.True(result.HasValue);
            Assert.Equal("Akash", result.Value.name);
            Assert.Equal(9334445588L, result.Value.PhNo);
            Assert.Equal("akash@gmail.com", result.Value.email);
        }

        [Theory]
        [InlineData("akash")]
        [InlineData("AKASH")]
        [InlineData("aKaSh")]
        public void FindContact_IsCaseInsensitive(string searchName)
        {
            // Arrange
            var contacts = CreateContacts();

            // Act
            var result = ContactSearchService.FindContact(
                contacts, searchName);

            // Assert
            Assert.True(result.HasValue);
            Assert.Equal("Akash", result.Value.name);
        }

        [Fact]
        public void FindContact_WhenNameDoesNotExist_ReturnsNull()
        {
            // Arrange
            var contacts = CreateContacts();

            // Act
            var result = ContactSearchService.FindContact(
                contacts, "Priya");

            // Assert
            Assert.False(result.HasValue);
        }

        [Fact]
        public void FindContact_WithEmptyArray_ReturnsNull()
        {
            // Arrange
            var contacts = Array.Empty<ContactCard>();

            // Act
            var result = ContactSearchService.FindContact(
                contacts, "Akash");

            // Assert
            Assert.False(result.HasValue);
        }

        [Fact]
        public void FindContact_WithEmptySearchName_ReturnsNull()
        {
            // Arrange
            var contacts = CreateContacts();

            // Act
            var result = ContactSearchService.FindContact(
                contacts, "");

            // Assert
            Assert.False(result.HasValue);
        }

        [Fact]
        public void FindContact_WhenContactsIsNull_ThrowsException()
        {
            // Arrange
            ContactCard[] contacts = null!;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(
                () => ContactSearchService.FindContact(
                    contacts, "Akash"));
        }

        [Fact]
        public void FindContact_WhenSearchNameIsNull_ThrowsException()
        {
            // Arrange
            var contacts = CreateContacts();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(
                () => ContactSearchService.FindContact(
                    contacts, null!));
        }
    }
}
