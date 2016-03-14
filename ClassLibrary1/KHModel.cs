namespace ClassLibrary1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class KHModel : DbContext
    {
        public KHModel()
            : base("name=KHModel")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<FormEntry> FormEntries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(e => e.FormEntries)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.Customer_CustID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.Department)
                .HasForeignKey(e => e.Department_DeptID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.FormEntries)
                .WithRequired(e => e.Employee)
                .HasForeignKey(e => e.Employee_EmpID)
                .WillCascadeOnDelete(false);
        }
    }
}
