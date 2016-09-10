using EFCoreConsoleDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreConsoleDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var context = new HPlusSportContext();
            var CustomerNames = context.Customer.Where(c => c.LastName.StartsWith("S"))
                .OrderBy(c => c.LastName)
                .Select(c => c.FirstName + " " + c.LastName)
                .ToList();

            CustomerNames.ForEach(cn => Console.WriteLine(cn));

            Console.ReadKey();
        }
    }
}
