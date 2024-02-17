namespace Contacts.Maui.Views_Mvvm;

public partial class ContactsMvvmPage : ContentPage
{
	private readonly ContactsViewModel _contactsViewModel;
	public ContactsMvvmPage(ContactsViewModel viewModel)
	{
		InitializeComponent();
		_contactsViewModel = viewModel;
		this.BindingContext = _contactsViewModel;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
		await _contactsViewModel.LoadContactsAsync();
    }
}