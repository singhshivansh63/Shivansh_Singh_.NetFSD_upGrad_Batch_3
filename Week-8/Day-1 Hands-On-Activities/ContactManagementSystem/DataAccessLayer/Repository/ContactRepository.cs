using Dapper;
using DataAccessLayer.Models;
using System.Data;

namespace DataAccessLayer.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly DapperContext _context;

        public ContactRepository(DapperContext context)
        {
            _context = context;
        }

        public List<ContactInfo> GetAllContacts()
        {
            string query = @"
                SELECT c.*, comp.CompanyName, dept.DepartmentName 
                FROM ContactInfo c
                INNER JOIN Companies comp ON c.CompanyId = comp.CompanyId
                INNER JOIN Departments dept ON c.DepartmentId = dept.DepartmentId";

            using (var conn = _context.CreateConnection())
            {
                return conn.Query<ContactInfo>(query).ToList();
            }
        }

        public ContactInfo GetContactById(int id)
        {
            string sql = @"SELECT * FROM ContactInfo WHERE ContactId = @Id";

            using (var conn = _context.CreateConnection())
            {
                return conn.QuerySingleOrDefault<ContactInfo>(sql, new { Id = id });
            }
        }

        public void AddContact(ContactInfo contact)
        {
            string sql = @"INSERT INTO ContactInfo 
                           (FirstName, LastName, EmailId, MobileNo, Designation, CompanyId, DepartmentId)
                           VALUES (@FirstName, @LastName, @EmailId, @MobileNo, @Designation, @CompanyId, @DepartmentId)";

            using (var conn = _context.CreateConnection())
            {
                conn.Execute(sql, contact);
            }
        }

        public void UpdateContact(ContactInfo contact)
        {
            string sql = @"UPDATE ContactInfo SET
                           FirstName=@FirstName, LastName=@LastName, EmailId=@EmailId,
                           MobileNo=@MobileNo, Designation=@Designation,
                           CompanyId=@CompanyId, DepartmentId=@DepartmentId
                           WHERE ContactId=@ContactId";

            using (var conn = _context.CreateConnection())
            {
                conn.Execute(sql, contact);
            }
        }

        public void DeleteContact(int id)
        {
            string sql = "DELETE FROM ContactInfo WHERE ContactId=@Id";

            using (var conn = _context.CreateConnection())
            {
                conn.Execute(sql, new { Id = id });
            }
        }

        public List<Company> GetCompanies()
        {
            using (var conn = _context.CreateConnection())
            {
                return conn.Query<Company>("SELECT * FROM Companies").ToList();
            }
        }

        public List<Department> GetDepartments()
        {
            using (var conn = _context.CreateConnection())
            {
                return conn.Query<Department>("SELECT * FROM Departments").ToList();
            }
        }
    }
}