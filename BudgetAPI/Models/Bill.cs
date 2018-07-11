using System;

namespace BudgetAPI.Models
{
    public class Bill
    {
        public int BillID { get; set; }
        public DateTime DueDate { get; set; }
        public decimal MinimumPayment { get; set; }
        public decimal PayAmount { get; set; }
        public decimal? BillBalance { get; set; }
        public string BillName { get; set; }
        public int PayScheduleId { get; set; }
    }
}