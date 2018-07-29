using System;
using System.Collections.Generic;

namespace BudgetAPI.Models
{
    public class PayScheduleSummary 
    {
        public PaySchedule Schedule{ get; set; }
        public List<Bill> Bills { get; set; }
        public decimal TotalBills { get; set; }
        public decimal BillsPaidAmount { get; set; }
        public decimal CashLeftoverAmount { get; set; }
    }
}