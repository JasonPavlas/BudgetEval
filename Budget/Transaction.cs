using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBudget
{
    class Transaction
    {

        public DateTime TransDate { get; set; }
        public string TransDescription { get; set; }
        public string TransType { get; set; }
        public double TransAmount { get; set; }




        internal static Transaction parseFromCSV(string line)
        {
           
            var columns = line.Split(',');

            
            return new Transaction
            {
                TransDate = DateTime.Parse(columns[0]),
                TransDescription = columns[1],
                TransType = columns[2],
                TransAmount = double.Parse(columns[3])
               
            };
        }

        

        
    }
}
