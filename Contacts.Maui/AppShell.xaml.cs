using Contacts.Maui.Views;
using Contacts.Maui.Views_Mvvm;

namespace Contacts.Maui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(ContactPage), typeof(ContactPage));
            Routing.RegisterRoute(nameof(EditContactPage), typeof(EditContactPage));
            Routing.RegisterRoute(nameof(AddContactPage), typeof(AddContactPage));
            Routing.RegisterRoute(nameof(ContactsMvvmPage), typeof(ContactsMvvmPage));
        }
    }
}
