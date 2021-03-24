using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Data.ViewModels
{
    public class DateReport
    {
        public DateTime Date { get; set; }
        public int HoursWorked { get; set; }
        public int CustomersNumber { get; set; }
        public int OrdersNumber { get; set; }
    }
}
