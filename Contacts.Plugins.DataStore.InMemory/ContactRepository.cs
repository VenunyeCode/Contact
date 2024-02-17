namespace Contacts.Plugins.DataStore.InMemory
{
    // All the code in this file is included in all platforms.
    public class ContactRepository : IContactRepository
    {
        public static List<Contact> _contacts = Generate();
        public async Task<List<Contact>> GetContactsAsync(string filterText)
        {
            if(string.IsNullOrWhiteSpace(filterText))
            {
                return await Task.FromResult(_contacts);
            }
            var c = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Name) && (x.Name.StartsWith(filterText, StringComparison.OrdinalIgnoreCase) || x.Name.Contains(filterText, StringComparison.OrdinalIgnoreCase))).ToList();
            if (c == null || c.Count() == 0)
                c = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Phone) && x.Phone.StartsWith(filterText, StringComparison.OrdinalIgnoreCase) || x.Name.Contains(filterText, StringComparison.OrdinalIgnoreCase)).ToList();
            else return await Task.FromResult(c);
            if (c == null || c.Count() == 0)
                c = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Email) && x.Email.StartsWith(filterText, StringComparison.OrdinalIgnoreCase) || x.Name.Contains(filterText, StringComparison.OrdinalIgnoreCase)).ToList();
            else return await Task.FromResult(c);
            if (c == null || c.Count() == 0)
                c = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Address) && x.Address.StartsWith(filterText, StringComparison.OrdinalIgnoreCase) || x.Name.Contains(filterText, StringComparison.OrdinalIgnoreCase)).ToList();
            else return await Task.FromResult(c);

            return await Task.FromResult(c);
        }

        public static List<Contact> Generate()
        {
            var c = new List<Contact>();
            for (int i = 0; i < 5; i++)
            {
                c.Add(new Contact()
                    {
                        Id = i + 1,
                        Name = Faker.Name.FullName(),
                        Email = Faker.Internet.Email(),
                        Phone = Faker.Phone.Number(),
                        Address = Faker.Address.City() + ", " + Faker.Address.StreetName() + ", " + Faker.Address.StreetAddress()

                    }
                );
            }
            return c;
        }

        public async Task<Contact> GetContactByIdAsync(int id)
        {
            var contact = _contacts.FirstOrDefault(x => x.Id == id);
            if (contact is not null)
                return await Task.FromResult(new Contact()
                {
                    Id = contact.Id,
                    Name = contact.Name,
                    Phone = contact.Phone,
                    Email = contact.Email,
                    Address = contact.Address
                });

            return null;
        }

        public Task AddContactAsync(Contact contact)
        {
            if (_contacts.Count == 0 || _contacts is null)
                contact.Id = 1;
            else
                contact.Id = _contacts.Last().Id + 1;
            _contacts.Add(contact);

            return Task.CompletedTask;
        }

        public Task UpdateContactAsync(int id, Contact contact)
        {
            var contactToUpdate = _contacts.FirstOrDefault(x => x.Id == id);
            if (id != contact.Id) return Task.CompletedTask;
            if(contactToUpdate is not null)
            {
                contactToUpdate.Name = contact.Name;
                contactToUpdate.Email = contact.Email;
                contactToUpdate.Address = contact.Address;
                contactToUpdate.Phone = contact.Phone;  
            }
            return Task.CompletedTask;
        }

        public Task DeleteContactAsync(int id)
        {
            var result = _contacts.Where(x => x.Id == id).First();
            if (result is not null)
                _contacts.Remove(result);
            return Task.CompletedTask;
        }
    }
}
