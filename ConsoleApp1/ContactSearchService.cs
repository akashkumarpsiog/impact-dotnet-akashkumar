using System;

namespace ContactCardApp
{
    public static class ContactSearchService
    {
        public static ContactCard? FindContact(
            ContactCard[] contacts,
            string searchName)
        {
            ArgumentNullException.ThrowIfNull(contacts);
            ArgumentNullException.ThrowIfNull(searchName);

            foreach (ContactCard contact in contacts)
            {
                if (string.Equals(
                    contact.name,
                    searchName,
                    StringComparison.OrdinalIgnoreCase))
                {
                    return contact;
                }
            }

            return null;
        }
    }
}