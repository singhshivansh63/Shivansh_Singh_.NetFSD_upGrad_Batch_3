using ContactManagement.DAL11.Models;
using System.ComponentModel.DataAnnotations;

namespace ContactManagement.DAL11.Models
{
    public class ContactInfo
    {
        [Key]
        public int ContactId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string EmailId { get; set; } = string.Empty;

        [Required]
        public long MobileNo { get; set; }

        [Required]
        [MaxLength(100)]
        public string Designation { get; set; } = string.Empty;

        // 🔥 Foreign Key - Company
        [Required]
        public int CompanyId { get; set; }

        // Navigation Property
        public Company Company { get; set; } = null!;

        // 🔥 Foreign Key - Department
        [Required]
        public int DepartmentId { get; set; }

        // Navigation Property
        public Department Department { get; set; } = null!;
    }
}