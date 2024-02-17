using System.Collections.ObjectModel;

namespace Contacts.Maui.ViewModels
{
    public partial class ContactsViewModel : ObservableObject
    {
        public ObservableCollection<Contact> Contacts { get; set; }
        private readonly IViewContactsUseCase _viewContactsUseCase;
        private readonly IDeleteContactUseCase _deleteContactUseCase;

        public ContactsViewModel(IViewContactsUseCase viewContactsUseCase, 
            IDeleteContactUseCase deleteContactUseCase)
        {
            _viewContactsUseCase = viewContactsUseCase;
            this.Contacts = new ObservableCollection<Contact>();
            _deleteContactUseCase = deleteContactUseCase;

        }

        public async Task LoadContactsAsync()
        {
            this.Contacts.Clear();
            var contacts = await _viewContactsUseCase.ExecuteAsync(string.Empty);

            if(contacts != null && contacts.Count > 0)
            {
                foreach (var item in contacts)
                {
                    this.Contacts.Add(item);
                }
            }
        }

        [RelayCommand]
        public async Task DeleteContact(int id)
        {
            await _deleteContactUseCase.ExecuteAsync(id);
            await LoadContactsAsync();
        }
    }
}
