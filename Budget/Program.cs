using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBudget
{
    class Program
    {
        static void Main(string[] args)
        {
            var transaction = ProcessFile("USAATransactions.csv");

            var query = transaction.OrderBy(t => t.Description);

            foreach (var line in query)
            {
                Console.WriteLine($"{line.Amount} \tfrom\t{line.Description}");
            }

            Console.WriteLine("\n\n\n");


            var costQuerey = transaction.OrderBy(t => t.Amount);

            foreach (var line in costQuerey)
            {
                Console.WriteLine($"{line.Amount} \tfrom\t{line.Description} \ton\t {line.Date}");
            }

            var dateQuerey =
                    from line in transaction
                    orderby line.Date
                    select line;


            foreach (var line in dateQuerey)
            {
                Console.WriteLine($"{line.Date}");
            }


            Console.ReadKey();
        }


        /*
         *Method passed the path of the CSV and returns a Generic List of
         * type Transaction
        */
        private static List<Transaction> ProcessFile(string path)
        {
            return
                 File.ReadAllLines(path)
                     .Where(line => line.Length > 1)
                     .Select(Transaction.parseFromCSV)
                     .ToList();

        }
    }

}
