using Contacts.Maui.Views_Mvvm;
using Contacts.UseCases.UseCases;

namespace Contacts.Maui.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services
                .AddSingleton<IContactRepository, ContactRepository>();

            services
                .AddSingleton<IViewContactsUseCase, ViewContactsUseCase>();

            services
                .AddSingleton<IViewContactUseCase, ViewContactUseCase>();

            services
                .AddTransient<IEditContactUseCase, EditContactUseCase>();

            services
                .AddTransient<IAddContactUseCase, AddContactUseCase>();

            services
                .AddTransient<IDeleteContactUseCase, DeleteContactUseCase>();
        }

        public static void ConfigurePages(this IServiceCollection pages)
        {
            pages
                .AddSingleton<EditContactPage>();

            pages
                .AddSingleton<ContactPage>();

            pages.
                AddSingleton<AddContactPage>();

            pages
                .AddSingleton<ContactsViewModel>(); 

            pages
                .AddSingleton<ContactsMvvmPage>();
        }   
    }
}
