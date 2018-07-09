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
        private readonly ApiDBContext _db;
        public BillController(ApiDBContext context)
        {
            _db = context;
        }

        [HttpGet]
        public ActionResult<List<Bill>> GetAll()
        {
            return _db.Bills.ToList();
        }

        [HttpGet("{id}", Name = "GetBill")]
        public ActionResult<Bill> GetBill(int id)
        {
            var bill = _db.Bills.Find(id);
            if(bill == null)
            {
                return NotFound();
            }
            return bill;
        }

        [HttpPost]
        public IActionResult AddBill(Bill bill)
        {
            _db.Bills.Add(bill);
            _db.SaveChanges();
            return CreatedAtRoute("GetBill", new {id = bill.BillID}, bill);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBill(int billID, Bill bill)
        {
            var dbBill = _db.Bills.Find(billID);
            if(dbBill == null)
            {
                return NotFound();
            }

            dbBill.BillBalance = bill.BillBalance;
            dbBill.DueDate = bill.DueDate;
            dbBill.MinimumPayment = bill.MinimumPayment;
            dbBill.PayAmount = bill.PayAmount;
            dbBill.BillName = bill.BillName;

            _db.Bills.Update(dbBill);
            _db.SaveChanges();
            return NoContent();
        }
    }
}