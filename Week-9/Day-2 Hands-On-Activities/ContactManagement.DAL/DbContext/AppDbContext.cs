using Microsoft.EntityFrameworkCore;
using ContactManagement.DAL11.Models;

namespace ContactManagement.DAL11.DbContext
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // 🔹 DbSets
        public DbSet<ContactInfo> Contacts { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<AppUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 🔥 COMPANY → CONTACT (1-MANY)
            modelBuilder.Entity<Company>()
                .HasMany(c => c.Contacts)
                .WithOne(c => c.Company)
                .HasForeignKey(c => c.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            // 🔥 DEPARTMENT → CONTACT (1-MANY)
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Contacts)
                .WithOne(c => c.Department)
                .HasForeignKey(c => c.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // 🔐 USERS (optional safety config)
            modelBuilder.Entity<AppUser>()
                .Property(u => u.Email)
                .IsRequired();

            modelBuilder.Entity<AppUser>()
                .Property(u => u.Password)
                .IsRequired();

            modelBuilder.Entity<AppUser>()
                .Property(u => u.Role)
                .IsRequired();
        }
    }
}