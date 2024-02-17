namespace Contacts.UseCases.Interfaces
{
    public interface IViewContactsUseCase
    {
        Task<List<Contact>> ExecuteAsync(string filterText);
    }
}