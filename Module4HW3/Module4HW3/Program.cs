using System;
using DatabaseAccess;
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
                bankContext.SaveChanges();
            }
        }
    }
}
