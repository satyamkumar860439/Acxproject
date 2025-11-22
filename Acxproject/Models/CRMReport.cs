namespace Acxproject.Models
{
        public class CRMReport
        {
            public int TotalCustomers { get; set; }
            public int TotalEmployees { get; set; }

            public List<Customer> RecentCustomers { get; set; }
            public List<Employee> RecentEmployees { get; set; }
        }
    }