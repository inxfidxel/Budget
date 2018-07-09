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
        public ActionResult<PaySchedule> GetSchedule(DateTime paidDate, DateTime nextPaidDate, decimal currentCash, DateTime currentDate)
        {
            var schedule = new PaySchedule
            {
                PaidDate = paidDate,
                NextPaidDate = nextPaidDate,
            };

            schedule. _db.Bills.Sum(x => x.MinimumPayment);

        }
    }
}