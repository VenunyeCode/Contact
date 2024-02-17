namespace Contacts.UseCases.Interfaces
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetContactsAsync(string filterText); 
        Task<Contact> GetContactByIdAsync(int id);
        Task AddContactAsync(Contact contact);
        Task UpdateContactAsync(int id, Contact contact);
        Task DeleteContactAsync(int id);
    }
}
