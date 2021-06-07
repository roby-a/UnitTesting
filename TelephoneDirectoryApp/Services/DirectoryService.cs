using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelephoneDirectoryApp.Models;

namespace TelephoneDirectoryApp.Services
{
    public class DirectoryService : IDirectoryService
    {
        public List<TelephoneUser> GetAllUsers()
        {
            var result = new List<TelephoneUser>();

            result.Add(new TelephoneUser()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Number = 9495445975,
                Location = "USA"
            });

            result.Add(new TelephoneUser()
            {
                Id = 2,
                FirstName = "Thomas",
                LastName = "Stephen",
                Number = 9495445975,
                Location = "USA"
            });

            result.Add(new TelephoneUser()
            {
                Id = 3,
                FirstName = "Francis",
                LastName = "K",
                Number = 9495445975,
                Location = "USA"
            });

            result.Add(new TelephoneUser()
            {
                Id = 4,
                FirstName = "John",
                LastName = "Thomas",
                Number = 9495445975,
                Location = "USA"
            });

            result.Add(new TelephoneUser()
            {
                Id = 5,
                FirstName = "Tom",
                LastName = "Cruise",
                Number = 9495445975,
                Location = "USA"
            });

            result.Add(new TelephoneUser()
            {
                Id = 6,
                FirstName = "De",
                LastName = "Caprio",
                Number = 9495445975,
                Location = "USA"
            });

            return result;
        }
    }
}
