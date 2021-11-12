using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DatabaseAccess;

namespace BankApplication
{
    public class BankContextFactory : IDesignTimeDbContextFactory<BankContext>
    {
        public BankContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            var optionsBuilder = new DbContextOptionsBuilder();

            var connectionString = configuration.GetConnectionString("Bank");

            optionsBuilder.UseSqlServer(connectionString);

            return new BankContext(optionsBuilder.Options);
        }
    }
}
