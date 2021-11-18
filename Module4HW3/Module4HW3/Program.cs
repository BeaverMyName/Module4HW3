using System;
using System.Linq;
using DatabaseAccess;
using DatabaseAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BankApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var bankContextFactory = new BankContextFactory();

            using (var bankContext = bankContextFactory.CreateDbContext(args))
            {
                var leftJoin = (from o in bankContext.Offices
                                join e in bankContext.Employees on o.Id equals e.OfficeId into officesEmployes
                                from oe in officesEmployes.DefaultIfEmpty()
                                select new { Id = o.Id, OfficeLocation = o.Location, EmployeeName = oe.FirstName, TitleId = oe.TitleId })
                                .Join(
                    bankContext.Titles,
                    oe => oe.TitleId,
                    t => t.Id,
                    (oe, t) => new { Id = oe.Id, OfficeLocation = oe.OfficeLocation, EmployeeName = oe.EmployeeName, TitleName = t.Name })
                                .ToList();

                var dateDifference = bankContext.Employees.Select(e => DateTime.UtcNow - e.HiredDate);

                var employees = bankContext.Employees.ToList();
                employees[0].FirstName = "Tom";
                employees[1].LastName = "Asket";
                bankContext.Employees.Update(employees[0]);
                bankContext.Employees.Update(employees[1]);

                var newEmployee = new Employee() { FirstName = "Max", LastName = "Kekov", HiredDate = new DateTime(2021, 9, 12), OfficeId = 2, TitleId = 1 };
                var newProject = new Project() { Name = "AsusDuo", Budget = 48000000, StartedDate = DateTime.UtcNow, ClientId = 2 };

                bankContext.Employees.Add(newEmployee);
                bankContext.Projects.Add(newProject);

                bankContext.Employees.Remove(employees[1]);

                var title = bankContext.Employees.ToList().GroupBy(e => e.Title.Name).Select(x => x.Key).FirstOrDefault(k => !k.Contains('a'));
                bankContext.SaveChanges();
            }
        }
    }
}