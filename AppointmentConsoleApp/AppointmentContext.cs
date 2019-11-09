using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentConsoleApp
{
    public class AppointmentContext:DbContext
    {
        public DbSet<AppointmentInfo> Appointments { get; set; }
        public DbSet<UserInfo> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AppointmentDB;Integrated Security=True;Connect Timeout=30;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppointmentInfo>(e =>
            {
                e.HasKey(a => a.AppointmentID).HasName("PK_Appointments");
                e.Property(a => a.AppointmentID).ValueGeneratedOnAdd();
                e.Property(a => a.HostUser).IsRequired();
                e.Property(a => a.GuestUser).IsRequired();
                e.Property(a => a.Subject).HasMaxLength(100);
                e.HasOne(t => t.User).WithMany().HasForeignKey(t=>t.HostUserID);
                e.ToTable("Appointments");
            });
            modelBuilder.Entity<UserInfo>(e =>
            {
                e.HasKey(a => a.UserId).HasName("PK_Users");
                e.Property(a => a.UserId).ValueGeneratedOnAdd();
                e.Property(a => a.UserName).IsRequired();
                e.Property(a => a.Password).IsRequired();
                e.Property(a => a.FirstName).IsRequired();
                e.Property(a => a.EmailID).IsRequired().HasMaxLength(100);
                e.ToTable("Users");
            });
                
        }
    }
}
