using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TelephoneDirectoryApp.Models;
using OfficeOpenXml;
using System.Text;

namespace TelephoneDirectoryApp.Services
{
    public class DirectoryService : IDirectoryService
    {
        public bool AddDetails(TelephoneUser detail)
        {
            return true;
        }

        public IEnumerable<TelephoneUser> GetAllUsers()
        {
            var result = new List<TelephoneUser>();

            string path = "D:/TelephoneDirectory.xlsx";
            FileInfo fileInfo = new FileInfo(path);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            ExcelPackage package = new ExcelPackage(fileInfo);
            ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();

            // get number of rows and columns in the sheet
            int rows = worksheet.Dimension.Rows;
            // loop through the worksheet rows and columns
            for (int i = 2; i <= rows; i++)
            {
                var item = new TelephoneUser()
                {
                    Id = Convert.ToInt32(worksheet.Cells[i, 1].Value.ToString()),
                    FirstName = worksheet.Cells[i, 2].Value.ToString(),
                    LastName = worksheet.Cells[i, 3].Value.ToString(),
                    Number = Convert.ToDouble(worksheet.Cells[i, 4].Value.ToString()),
                    Location = worksheet.Cells[i, 5].Value.ToString()
                };
                result.Add(item);
            }
            return result;
        }

        public IEnumerable<TelephoneUser> GetDummyData()
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
