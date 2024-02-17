namespace Contacts.UseCases.UseCases
{
    public class ViewContactUseCase : IViewContactUseCase
    {
        private readonly IContactRepository _contactRepository;
        public ViewContactUseCase(IContactRepository contactRepository)
        {

            _contactRepository = contactRepository;

        }
        public async Task<Contact> ExecuteAsync(int id)
        {
            return await _contactRepository.GetContactByIdAsync(id);
        }
    }
}
