namespace Contacts.Maui.Views;
using Contacts.Maui.Models;
using System.Collections.ObjectModel;

public partial class ContactPage : ContentPage 
{
	public ContactPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var contacts = new ObservableCollection<Contact>(ContactRepository.GetAll());
        listContacts.ItemsSource = contacts;
    }

    private async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        // Logic here.
        if(listContacts.SelectedItem != null)
            await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={((Contact)listContacts.SelectedItem).Id}");
    }
    private void listContacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        //Always deselect the selected item in the itemtapped event.
        listContacts.SelectedItem = null;
    }

    private void addContact_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddContactPage));
    }
}