using CsvHelper;
using CsvHelper.Configuration;
using DMS.Data;
using DMS.Data.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Service
{
    public class ReportsService
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly DMSContext _context;

        public ReportsService(DMSContext context, IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;
        }

        public IEnumerable<UserReport> GetCategoryUsersInfo(int categoryId)
        {
            List<UserReport> userReports = new List<UserReport>();

            var documents = _context.Documents.Where(d => d.CategoryId == categoryId).ToList();

            foreach(var document in documents)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Documents\\", document.DocumentName);
                var dateReportsFromCsv = ReadCsvData(path);

                var existingUserReport = userReports.Where(r => r.UserId == document.UserId).FirstOrDefault();
                if (existingUserReport != null)
                    existingUserReport.DateReports.ToList().AddRange(dateReportsFromCsv);
                else
                    userReports.Add(new UserReport() {
                        UserId = document.UserId, 
                        Username = _context.Users.FirstOrDefault(u => u.UserId == document.UserId).UserName, 
                        DateReports = dateReportsFromCsv
                    });
            }

            return userReports;
        }

        private List<DateReport> ReadCsvData(string path)
        {
            List<DateReport> records;

            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ";" }))
            {
                records = csv.GetRecords<DateReport>().ToList();
            }

            return records;
        }
    }
}
