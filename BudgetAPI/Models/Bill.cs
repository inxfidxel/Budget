using System;

namespace BudgetAPI.Models
{
    public class Bill
    {
        public int BillID { get; set; }
        public DateTime DueDate { get; set; }
        public decimal MinimumAmount { get; set; }
        public decimal PayAmount { get; set; }
        public decimal? BillBalance { get; set; }
    }
}