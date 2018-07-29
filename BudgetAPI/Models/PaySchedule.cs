using System;
using System.Collections.Generic;

namespace BudgetAPI.Models
{
    public class PaySchedule
    {
        public int PayScheduleId { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime NextPaidDate { get; set; }
    }
}