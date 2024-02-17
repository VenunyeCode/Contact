namespace Contacts.UseCases.UseCases
{
    // All the code in this file is included in all platforms.
    public class ViewContactsUseCase : IViewContactsUseCase
    {
        //One method per use case
        private readonly IContactRepository _contactRepository;
        public ViewContactsUseCase(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task<List<Contact>> ExecuteAsync(string filterText)
        {
            return await _contactRepository.GetContactsAsync(filterText);
        }
    }
}
