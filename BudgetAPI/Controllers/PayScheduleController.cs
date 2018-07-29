using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using BudgetAPI.Models;
using System;

namespace BudgetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayScheduleController : ControllerBase
    {
        private readonly ApiDBContext _db;
        public PayScheduleController(ApiDBContext context)
        {
            _db = context;
        }

        [HttpGet]
        public ActionResult<PaySchedule> GetSchedule(DateTime date)
        {
            var sched = _db.PaySchedules.Where(x => x.PaidDate <= date && date <= x.NextPaidDate).FirstOrDefault();
            return sched;
        }

        [HttpPost]
        public IActionResult CreateSchedule(PaySchedule paySchedule)
        {
            _db.PaySchedules.Add(paySchedule);
            _db.SaveChanges();
            return CreatedAtRoute("GetSchedule", new {id = paySchedule.PayScheduleId}, paySchedule);
        }

        [HttpGet]
        public ActionResult<PayScheduleSummary> GetScheduleSummary(DateTime date)
        {
            var sched = _db.PaySchedules.Where(x => x.PaidDate <= date && date <= x.NextPaidDate).FirstOrDefault();
            var bills = _db.Bills.Where(b => b.DueDate >= sched.PaidDate && b.DueDate < sched.NextPaidDate).ToList();
            
            
            
            var summary = new PayScheduleSummary
            {
                Schedule = sched,
                Bills = bills,
                TotalBills = bills.Sum(b => b.MinimumPayment)
            };

            //calculate what should have been paid 
            var billsPaid = summary.Bills.Where(b => b.DueDate >= date).Sum(m => m.MinimumPayment);

            summary.BillsPaidAmount = billsPaid;
            summary.CashLeftoverAmount = summary.TotalBills - billsPaid;            
            return summary;
        }
    }
}