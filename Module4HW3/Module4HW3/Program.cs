using System;
using Microsoft.Extensions.Configuration;

namespace Module4HW3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var bankContext = new BankContext();
            bankContext.SaveChanges();
        }
    }
}
