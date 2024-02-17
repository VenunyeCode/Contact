namespace Contacts.UseCases.UseCases
{
    public class AddContactUseCase : IAddContactUseCase
    {
        private readonly IContactRepository _contactRepository;
        public AddContactUseCase(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task ExecuteAsync(Contact contact)
        {
            await _contactRepository.AddContactAsync(contact);
        }
    }
}
