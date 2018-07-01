using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using BudgetAPI.Models;

namespace BudgetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly ApiDBContext _dbContext;
        public BillController(ApiDBContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public ActionResult<List<Bill>> GetAll()
        {
            return _dbContext.Bills.ToList();
        }

        [HttpGet("{id}", Name = "GetBill")]
        public ActionResult<Bill> GetBill(int id)
        {
            var bill = _dbContext.Bills.Find(id);
            if(bill == null)
            {
                return NotFound();
            }
            return bill;
        }

        [HttpPost]
        public IActionResult AddBill(Bill bill)
        {
            _dbContext.Bills.Add(bill);
            _dbContext.SaveChanges();
            return CreatedAtRoute("GetBill", new {id = bill.BillID}, bill);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBill(int billID, Bill bill)
        {
            var dbBill = _dbContext.Bills.Find(billID);
            if(dbBill == null)
            {
                return NotFound();
            }

            dbBill.BillBalance = bill.BillBalance;
            dbBill.DueDate = bill.DueDate;
            dbBill.MinimumAmount = bill.MinimumAmount;
            dbBill.PayAmount = bill.PayAmount;
            dbBill.BillName = bill.BillName;

            _dbContext.Bills.Update(dbBill);
            _dbContext.SaveChanges();
            return NoContent();
        }
    }
}