namespace Contacts.Maui.Models
{
    public static class ContactRepository
    {
        public static List<Contact> contacts = Add();

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
            => contacts.Remove(GetById(id));

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

        public static List<Contact> Add()
        {
            List<Contact> list = new List<Contact>();
            for (int i = 0; i<10; i++)
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
    }
}
