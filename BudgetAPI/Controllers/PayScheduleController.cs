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
        public ActionResult<List<PaySchedule>> GetAllSchedules()
        {
            var schedules = _db.PaySchedules.ToList();

            foreach(var s in schedules)
            {
                s.Bills = _db.Bills.Where(b => b.PayScheduleId == s.PayScheduleId).ToList();
            }
            return schedules;
        }

        [HttpGet]
        public ActionResult<PaySchedule> GetSchedule(DateTime date)
        {

            var sched = _db.PaySchedules.Where(x => x.PaidDate <= date && date <= x.NextPaidDate).FirstOrDefault();

            sched.Bills = _db.Bills.Where(x => x.PayScheduleId == sched.PayScheduleId).ToList();

            return sched;

        }

        [HttpPost]
        public IActionResult CreateSchedule(PaySchedule paySchedule)
        {
            _db.PaySchedules.Add(paySchedule);
            _db.SaveChanges();
            return CreatedAtRoute("GetSchedule", new {id = paySchedule.PayScheduleId}, paySchedule);
        }
    }
}