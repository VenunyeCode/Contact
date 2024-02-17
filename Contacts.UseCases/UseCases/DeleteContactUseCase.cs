namespace Contacts.UseCases.UseCases
{
    public class DeleteContactUseCase : IDeleteContactUseCase
    {
        private readonly IContactRepository _contactRepository;

        public DeleteContactUseCase(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task ExecuteAsync(int id)
        {
            await _contactRepository.DeleteContactAsync(id);
        }
    }
}
