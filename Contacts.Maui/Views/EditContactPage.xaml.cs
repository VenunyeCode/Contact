namespace Contacts.Maui.Views;

[QueryProperty(nameof(ContactId), "Id")]
public partial class EditContactPage : ContentPage
{
	private Contact contact;
    private readonly IViewContactUseCase _viewContactUseCase;
    private readonly IEditContactUseCase _editContactUseCase;
	public EditContactPage(IViewContactUseCase viewContactUseCase, IEditContactUseCase editContactUseCase)
    {
        InitializeComponent();
        _viewContactUseCase = viewContactUseCase;
        _editContactUseCase = editContactUseCase;
	}

    public string ContactId
    {
        set
        {
            contact = _viewContactUseCase.ExecuteAsync(int.Parse(value)).GetAwaiter().GetResult();
            contactControl.Name = contact.Name;
            contactControl.Address = contact.Address;
            contactControl.Email = contact.Email;
            contactControl.Phone = contact.Phone;
        }
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//{nameof(ContactPage)}");
    }

    private async void btnUpdate_Clicked(object sender, EventArgs e)
    {
        contact.Name = contactControl.Name;
        contact.Email = contactControl.Email;
        contact.Phone = contactControl.Phone;
        contact.Address = contactControl.Address;

        //ContactRepository.UpdateContactAsync(contact.Id, contact);
        await _editContactUseCase.ExecuteAsync(contact.Id, contact);
        await Shell.Current.GoToAsync($"//{nameof(ContactPage)}");
    }

    private void contactControl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "Ok");
    }
}