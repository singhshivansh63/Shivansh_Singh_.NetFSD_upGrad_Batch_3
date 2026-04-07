using Dapper;
using System.Data;
using System.Data.SqlClient;
using WebApplication12.Models;

namespace WebApplication12.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly string _connectionString;

        public ContactRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        private IDbConnection Connection => new SqlConnection(_connectionString);

        public IEnumerable<Contact> GetAll()
        {
            var sql = @"
                SELECT c.*, comp.CompanyId, comp.CompanyName,
                       d.DepartmentId, d.DepartmentName
                FROM Contacts c
                INNER JOIN Companies comp ON comp.CompanyId = c.CompanyId
                INNER JOIN Departments d ON d.DepartmentId = c.DepartmentId";

            using var conn = Connection;
            return conn.Query<Contact, Company, Department, Contact>(
                sql,
                (contact, company, department) =>
                {
                    contact.Company = company;
                    contact.Department = department;
                    return contact;
                },
                splitOn: "CompanyId,DepartmentId"
            );
        }

        public Contact? GetById(int id)
        {
            var sql = @"
                SELECT * FROM Contacts WHERE ContactId = @id";

            using var conn = Connection;
            return conn.QueryFirstOrDefault<Contact>(sql, new { id });
        }

        public void Add(Contact contact)
        {
            var sql = @"
                INSERT INTO Contacts
                (FirstName, LastName, EmailId, MobileNo, Designation, CompanyId, DepartmentId)
                VALUES (@FirstName, @LastName, @EmailId, @MobileNo, @Designation, @CompanyId, @DepartmentId)";

            using var conn = Connection;
            conn.Execute(sql, contact);
        }

        public void Update(Contact contact)
        {
            var sql = @"
                UPDATE Contacts SET
                    FirstName = @FirstName,
                    LastName = @LastName,
                    EmailId = @EmailId,
                    MobileNo = @MobileNo,
                    Designation = @Designation,
                    CompanyId = @CompanyId,
                    DepartmentId = @DepartmentId
                WHERE ContactId = @ContactId";

            using var conn = Connection;
            conn.Execute(sql, contact);
        }

        public void Delete(int id)
        {
            var sql = @"DELETE FROM Contacts WHERE ContactId = @id";
            using var conn = Connection;
            conn.Execute(sql, new { id });
        }
    }
}