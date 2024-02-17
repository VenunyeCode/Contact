namespace Contacts.UseCases.UseCases
{
    public class EditContactUseCase : IEditContactUseCase
    {
        private readonly IContactRepository _contactRepository;
        public EditContactUseCase(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task ExecuteAsync(int contactId, Contact contact)
        {
            await _contactRepository.UpdateContactAsync(contactId, contact);
        }
    }
}
