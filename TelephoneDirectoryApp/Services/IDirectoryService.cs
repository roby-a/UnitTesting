using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelephoneDirectoryApp.Models;

namespace TelephoneDirectoryApp.Services
{
    public interface IDirectoryService
    {
        IEnumerable<TelephoneUser> GetAllUsers();
        int AddDetails(TelephoneUser detail);
        TelephoneUser GetUser(int id);
        int UpdateUser(TelephoneUser detail);
        int DeleteUser(int id);
    }
}
