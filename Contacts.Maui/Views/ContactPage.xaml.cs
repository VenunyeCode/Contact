namespace Contacts.Maui.Views;
using ContactRepository = Contacts.Maui.Models.ContactRepository;
using System.Collections.ObjectModel;

public partial class ContactPage : ContentPage 
{
    private readonly IViewContactsUseCase _viewContactsUseCase;
    private readonly IDeleteContactUseCase _deleteContactUseCase;
	public ContactPage(IViewContactsUseCase viewContactsUseCase, 
        IDeleteContactUseCase deleteContactUseCase)
	{
		InitializeComponent();
        _viewContactsUseCase = viewContactsUseCase;
        _deleteContactUseCase = deleteContactUseCase;
        LoadContacts();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        searchBar.Text = string.Empty;
        LoadContacts();
    }

    private async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        // Logic here.
        if(listContacts.SelectedItem != null)
            await Shell.Current.
                GoToAsync($"{nameof(EditContactPage)}?Id={((Contact)listContacts.SelectedItem).Id}");
    }
    private void listContacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        //Always deselect the selected item in the itemtapped event.
        listContacts.SelectedItem = null;
    }
    private async void addContact_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddContactPage));
    }

    private async void Delete_Clicked(object sender, EventArgs e)
    {
        var menuItem = sender as MenuItem;
        var contact = menuItem.CommandParameter as Contact;
        //ContactRepository.Delete(contact.Id);
        await _deleteContactUseCase.ExecuteAsync(contact.Id);

         LoadContacts();
    }

    private async void LoadContacts()
    {
        var contacts = new ObservableCollection<Contact>(await _viewContactsUseCase.ExecuteAsync(string.Empty));
        listContacts.ItemsSource = contacts;
    }

    private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        var result = new ObservableCollection<Contact>(
            await _viewContactsUseCase.ExecuteAsync(((SearchBar)sender).Text));
        listContacts.ItemsSource = result;
    }
}