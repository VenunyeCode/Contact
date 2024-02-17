namespace Contacts.Maui.Models
{
    public static class ContactRepository
    {
        public static List<Contact> contacts = Generate();

        public static List<Contact> GetAll()
            => contacts;

        public static Contact GetById(int id)
        {
            var contact = contacts.Where(x => x.Id == id).First();
            if(contact is not null)
            {
                return new Contact()
                {
                    Id = contact.Id,
                    Name = contact.Name,
                    Address = contact.Address,
                    Phone = contact.Phone,
                    Email = contact.Email
                };
            }
            return null;
        }

        public static void Delete(int id)
        {
            var contact = contacts.FirstOrDefault(x => x.Id == id);
            if(contact is not null)
                contacts.Remove(contact);
        }
        

        public static void Update(int id, Contact contact)
        {
            if (id != contact.Id) return;
            var contactToUpdate = contacts.Where(x => x.Id == id).First();
            if(contactToUpdate is not null) 
            {
                contactToUpdate.Name = contact.Name;
                contactToUpdate.Address = contact.Address;
                contactToUpdate.Phone = contact.Phone;
                contactToUpdate.Email = contact.Email;
            }

        }

        public static List<Contact> Generate()
        {
            List<Contact> list = new List<Contact>();
            for (int i = 0; i<5; i++)
            {
                list.Add(new Contact()
                {
                    Id = i + 1,
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    Phone = Faker.Phone.Number(),
                    Address = Faker.Address.City() + ", " + Faker.Address.StreetName() + ", " + Faker.Address.StreetAddress()

                });
            } 
            return list;
        }

        public static void Add(Contact contact)
        {
            contact.Id = contacts.Last().Id + 1;
            contacts.Add(contact);
        }

        public static List<Contact> SearchContacts(string text)
        {

            var c = contacts.Where(x => !string.IsNullOrWhiteSpace(x.Name) && (x.Name.StartsWith(text, StringComparison.OrdinalIgnoreCase) || x.Name.Contains(text, StringComparison.OrdinalIgnoreCase))).ToList();
            if (c == null || c.Count == 0)
                c = contacts.Where(x => !string.IsNullOrWhiteSpace(x.Phone) && x.Phone.StartsWith(text, StringComparison.OrdinalIgnoreCase)).ToList();
            else return c;

            if (c == null || c.Count == 0)
                c = contacts.Where(x => !string.IsNullOrWhiteSpace(x.Email) && x.Email.StartsWith(text, StringComparison.OrdinalIgnoreCase)).ToList();
            else return c;

            if (c == null || c.Count == 0)
                c = contacts.Where(x =>  !string.IsNullOrWhiteSpace(x.Address) && x.Address.StartsWith(text, StringComparison.OrdinalIgnoreCase)).ToList();
            else return c;

            return c;
        }
    }
}
