
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Security.Claims;

namespace EntityFrameworkTutorial.Entities.DBContexts
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options) {}
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Relationships
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Manager)
                .WithMany(d => d.Subordinates)
                .HasForeignKey(e => e.ManagerId)
                .OnDelete(DeleteBehavior.NoAction);


            //Constraints
            var properties = typeof(Register).GetProperties();
            foreach (var prop in properties)
            {
                if (prop.PropertyType == typeof(string))
                {
                    modelBuilder.Entity<Register>()
                        .Property(prop.Name)
                        .HasMaxLength(50)
                        .IsRequired();
                }
            }
            modelBuilder.Entity<Register>().HasNoKey();
            
            
            //Primary Keys
            modelBuilder.Entity<Employee>().HasKey(e => e.Id);
        }
    }
}
