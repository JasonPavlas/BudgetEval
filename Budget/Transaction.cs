using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBudget
{
    class Transaction
    {

        public string Date { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Amount { get; set; }




        internal static Transaction parseFromCSV(string line)
        {
            var columns = line.Split(',');

            //Get the date into an array
            var _date = columns[0].Split('/');
            
            //Converts dates from string to int
            int month = int.Parse(_date[0]);
            int day = int.Parse(_date[1]);
            int year = int.Parse(_date[2]);

            //Do some work on Amount
            double amount = double.Parse(columns[3]);

            return new Transaction
            {
                Date = (string.Format("{0:00}", month) + "/" + string.Format("{0:00}", day) + "/" + string.Format("{0:00}", year)),
                Description = columns[1],
                Type = columns[2],
                Amount = (string.Format("{0:0000.00}", amount.ToString("C")) )
 
            };
        }

        
    }
}
