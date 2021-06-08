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
        public int AddDetails(TelephoneUser detail)
        {
            try
            {
                if (ValidateUser(detail))
                {
                    var lastId = GetAllUsers().LastOrDefault().Id;
                    var file = GetFile();
                    var worksheet = file.Item1;
                    var package = file.Item2;

                    // get number of rows and columns in the sheet
                    int newRow = worksheet.Dimension.Rows + 1;
                    worksheet.Cells[newRow, 1].Value = lastId + 1;
                    worksheet.Cells[newRow, 2].Value = detail.FirstName;
                    worksheet.Cells[newRow, 3].Value = detail.LastName;
                    worksheet.Cells[newRow, 4].Value = detail.Number;
                    worksheet.Cells[newRow, 5].Value = detail.Location;

                    package.Save();

                    return lastId + 1;
                }
                return -1;
            }
            catch
            {
                return -1;
            }
        }

        public int UpdateUser(TelephoneUser detail)
        {
            try
            {
                var user = GetUser(detail.Id);
                if (user != null && ValidateUser(detail))
                {
                    var file = GetFile();
                    var worksheet = file.Item1;
                    var package = file.Item2;
                    worksheet.Cells[user.RowId, 2].Value = detail.FirstName;
                    worksheet.Cells[user.RowId, 3].Value = detail.LastName;
                    worksheet.Cells[user.RowId, 4].Value = detail.Number;
                    worksheet.Cells[user.RowId, 5].Value = detail.Location;

                    package.Save();
                    return 3;
                }
                return 1;
            }
            catch
            {
                return 2;
            }
        }

        public int DeleteUser(int id)
        {
            try
            {
                var user = GetUser(id);
                if (user != null)
                {
                    var file = GetFile();
                    var ws = file.Item1;
                    var package = file.Item2;
                    ws.DeleteRow(user.RowId, 1, true);
                    package.Save();
                    return 3;
                }
                return 1;
            }
            catch
            {
                return 2;
            }
        }

        public IEnumerable<TelephoneUser> GetAllUsers()
        {
            var result = new List<TelephoneUser>();

            var file = GetFile();
            var worksheet = file.Item1;
            var package = file.Item2;

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
                    Location = worksheet.Cells[i, 5].Value.ToString(),
                    RowId = i
                };
                result.Add(item);
            }
            return result.OrderBy(x=>x.Id);
        }

        public TelephoneUser GetUser(int id)
        {
            return GetAllUsers().Where(x => x.Id == id).FirstOrDefault();
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

        private bool ValidateUser(TelephoneUser detail)
        {
            var check = String.IsNullOrWhiteSpace(detail.FirstName) ||
                        String.IsNullOrWhiteSpace(detail.Location) ||
                        String.IsNullOrWhiteSpace(detail.Number.ToString());

            if (!check)
                return true;
            return false;
        }

        private (ExcelWorksheet,ExcelPackage) GetFile()
        {
            string path = "D:/TelephoneDirectory.xlsx";
            FileInfo fileInfo = new FileInfo(path);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            ExcelPackage package = new ExcelPackage(fileInfo);
            ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
            return (worksheet,package);
        }
    }
}
