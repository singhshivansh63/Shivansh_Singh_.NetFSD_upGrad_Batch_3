namespace DataAccessLayer.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        public List<ContactInfo> Contacts { get; set; }
    }
}