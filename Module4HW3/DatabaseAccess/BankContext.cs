using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using DatabaseAccess.Models;
using Microsoft.Extensions.Configuration;
using DatabaseAccess.Configurations;

namespace DatabaseAccess
{
    public class BankContext : DbContext
    {
        public BankContext(DbContextOptions contextOptions)
            : base(contextOptions)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Title> Titles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeProjectConfiguration());
            modelBuilder.ApplyConfiguration(new OfficeConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new TitleConfiguration());

            modelBuilder.Entity<Office>().HasData(
                new Office[]
                {
                    new Office() { Id = 1, Title = "Kharkiv1", Location = "Kharkiv" },
                    new Office() { Id = 2, Title = "Kharkiv2", Location = "Kharkiv" },
                    new Office() { Id = 3, Title = "Kiev1", Location = "Kiev"}
                });

            modelBuilder.Entity<Title>().HasData(
                new Title[]
                {
                    new Title() { Id = 1, Name = "Programmer" },
                    new Title() { Id = 2, Name = "Manager" },
                    new Title() { Id = 3, Name = "PR" }
                });

            modelBuilder.Entity<Employee>().HasData(
                new Employee[]
                {
                    new Employee() { Id = 1, FirstName = "Igor", LastName = "Bobro", HiredDate = new DateTime(2019, 8, 11), OfficeId = 1, TitleId = 1 },
                    new Employee() { Id = 2, FirstName = "Dima", LastName = "Ivanov", HiredDate = new DateTime(2020, 11, 12), OfficeId = 1, TitleId = 1 },
                    new Employee() { Id = 3, FirstName = "Tonya", LastName = "Kekovna", HiredDate = new DateTime(2021, 8, 2), OfficeId = 2, TitleId = 3 }
                });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.LogTo(Console.WriteLine);
        }
    }
}
