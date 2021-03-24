using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Data.ViewModels
{
    public class UserReport
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public int HoursTotal
        {   
            get
            {
                return DateReports.Sum(r => r.HoursWorked);
            }
        }
        public int CustomersTotal
        {
            get
            {
                return DateReports.Sum(r => r.CustomersNumber);
            }
        }
        public int OrdersTotal
        {
            get
            {
                return DateReports.Sum(r => r.OrdersNumber);
            }
        }

        public IEnumerable<DateReport> DateReports { get; set; } = new List<DateReport>();
    }
}
