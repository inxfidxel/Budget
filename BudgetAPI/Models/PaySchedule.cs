using System;
using System.Collections.Generic;

namespace BudgetAPI.Models
{
    public class PaySchedule 
    {
        public DateTime PaidDate { get; set; }
        public DateTime NextPaidDate { get; set; }
        public List<Bill> Bills { get; set; }
        public decimal TotalBills { get; set; }
                

    }
}