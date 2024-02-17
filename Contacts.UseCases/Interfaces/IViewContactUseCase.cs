using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.UseCases.Interfaces
{
    public interface IViewContactUseCase
    {
        public Task<Contact> ExecuteAsync(int id);
    }
}
