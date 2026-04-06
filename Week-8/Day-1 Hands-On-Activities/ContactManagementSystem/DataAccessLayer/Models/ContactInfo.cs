using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class ContactInfo
    {
        [Key]
        public int ContactId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string EmailId { get; set; }

        [Required]
        public long MobileNo { get; set; }

        public string Designation { get; set; }

       
        public int CompanyId { get; set; }
        public int DepartmentId { get; set; }

        
        public string CompanyName { get; set; }
        public string DepartmentName { get; set; }
    }
}