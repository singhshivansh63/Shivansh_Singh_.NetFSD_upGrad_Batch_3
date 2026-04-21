using System.ComponentModel.DataAnnotations;

namespace ContactManagement.API.Models
{
    public class ContactInfo
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string MobileNumber { get; set; } = string.Empty;

        [StringLength(100)]
        public string Designation { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "CompanyId must be greater than 0")]
        public int CompanyId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "DepartmentId must be greater than 0")]
        public int DepartmentId { get; set; }

        // Soft Delete
        public bool IsDeleted { get; set; } = false;
    }
}