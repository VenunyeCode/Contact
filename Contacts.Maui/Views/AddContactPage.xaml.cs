namespace Contacts.Maui.Views;

using Contacts.Maui.Models;

public partial class AddContactPage : ContentPage
{
    private readonly IAddContactUseCase _addContactUseCase;
	public AddContactPage(IAddContactUseCase addContactUseCase)
	{
        InitializeComponent();
        _addContactUseCase = addContactUseCase;
	}

    private void cancelBtn_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync($"//{nameof(ContactPage)}");
    }

    private async void contactControl_OnSave(object sender, EventArgs e)
    {

        await _addContactUseCase.ExecuteAsync(new Contact
        {
            Name = contactControl.Name,
            Phone = contactControl.Phone,
            Email = contactControl.Email,
            Address = contactControl.Address
        });
       await Shell.Current.GoToAsync($"//{nameof(ContactPage)}");
    }

    private void contactControl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "Ok");
    }
}