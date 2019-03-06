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

            sortByTransAmount(transaction);
            sortByTransDescription(transaction);


            Console.ReadKey();
        }

        
        private static List<Transaction> ProcessFile(string path)
        {
            return
                 File.ReadAllLines(path)
                     .Where(line => line.Length > 1)
                     .Select(Transaction.parseFromCSV)
                     .ToList();

        }

        private static void sortByTransAmount(List<Transaction> transaction)
        {
            var querey = transaction.OrderBy(t => t.TransAmount);

            foreach (var line in querey)
            {
                Console.WriteLine($"{line.TransAmount}\tfrom\t{line.TransDescription} \ton\t {line.TransDate}");
            }
        }

        private static void sortByTransDescription(List<Transaction> transaction)
        {
            var query = transaction.OrderBy(t => t.TransDescription);

            foreach (var line in query)
            {
                Console.WriteLine($"{line.TransAmount} \tfrom\t{line.TransDescription}");
            }
        }

       
    }

}
