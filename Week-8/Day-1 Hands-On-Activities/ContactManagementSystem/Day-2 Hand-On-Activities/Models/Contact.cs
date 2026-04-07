using WebApplication12.Models;

namespace WebApplication12.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailId { get; set; }
        public string? MobileNo { get; set; }
        public string? Designation { get; set; }
        public int CompanyId { get; set; }
        public int DepartmentId { get; set; }

        // Navigation
        public Company? Company { get; set; }
        public Department? Department { get; set; }
    }
}