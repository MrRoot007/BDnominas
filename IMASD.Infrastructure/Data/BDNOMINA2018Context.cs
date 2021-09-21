using Microsoft.EntityFrameworkCore;
using Nomina2018.Core.Entities;
using System.Reflection;

namespace Nomina2018.Infrastructure.Data
{
    public partial class BDNOMINA2018Context : DbContext
    {
        public BDNOMINA2018Context()
        {
        }

        public BDNOMINA2018Context(DbContextOptions<BDNOMINA2018Context> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);

        }
        //public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Security> Securitys { get; set; }

    }
}
