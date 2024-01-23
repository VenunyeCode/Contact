using Contacts.Maui.Models;
using Contact = Contacts.Maui.Models.Contact;

namespace Contacts.Maui.Views;

[QueryProperty(nameof(ContactId), "Id")]
public partial class EditContactPage : ContentPage
{
	private Contact contact;
	public EditContactPage()
    { 
		InitializeComponent();
	}

    public string ContactId
    {
        set
        {
            contact = ContactRepository.GetById(int.Parse(value));
            entryName.Text = contact.Name;
            entryAddress.Text = contact.Address;
            entryEmail.Text = contact.Email;
            entryPhone.Text = contact.Phone;
        }
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//{nameof(ContactPage)}");
    }

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
        if (nameValidator.IsNotValid)
        {
            DisplayAlert("Error", "Name is required", "Ok");
            return;
        }
        if(emailValidator.IsNotValid) 
        {
            foreach(var error in emailValidator.Errors)
            {
                DisplayAlert("Error", error.ToString(), "Ok");
                return;
            }
        }
        contact.Name = entryName.Text;
        contact.Email = entryEmail.Text;
        contact.Phone = entryPhone.Text;
        contact.Address = entryAddress.Text;
        ContactRepository.Update(contact.Id, contact);
        Shell.Current.GoToAsync($"//{nameof(ContactPage)}");
    }
}