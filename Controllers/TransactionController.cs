using bank_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bank_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {

        public ModelContext _context { get; }

        public TransactionController(ModelContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IEnumerable<Account> getDetails()
        {
            var data = _context.AccountDetails.ToList();
            return data;
        }

        [Route("getAccByRefId/{id}")]
        [HttpGet("{id}")]
        public IActionResult getAccByRefId(int id)
        {
            var user_acc = _context.AccountDetails.FirstOrDefault(a => a.user_ref_id == id);
            return Ok(user_acc);

        }

        [Route("getTransaction")]
        [HttpGet]
        public IEnumerable<Transaction> getTransaction()
        {
            var res = _context.Transactions.ToList();
            return res;
        }


        [HttpPost]
        public IActionResult Add(Transaction trans)
        {
            if(trans != null)
            {
                var user = _context.UserDetails.FirstOrDefault(u => u.email == trans.user_id);

                var id = user.user_ref_id;

                var user_acc = _context.AccountDetails.FirstOrDefault(a => a.user_ref_id == id);

                if(user_acc.balance < trans.amount)
                {
                    return StatusCode(200, "0");
                }
                user_acc.balance = user_acc.balance - trans.amount;

                var acc_no = trans.to_acc_no;

                var payee = _context.AccountDetails.FirstOrDefault(u => u.acc_no == acc_no);

                if (payee != null)
                {
                    payee.balance = payee.balance + trans.amount;
                    _context.AccountDetails.Update(payee);
                    _context.SaveChanges();

                }

                _context.AccountDetails.Update(user_acc);

                _context.Transactions.Add(trans);

                FundTransfer ft = new FundTransfer()
                {
                    user_id = trans.user_id,
                    to_acc_no = trans.to_acc_no,
                    to_ifsc = trans.to_ifsc,
                    to_bank = trans.to_bank,
                    to_name = trans.to_name,
                    amount = trans.amount,
                    ft_date = trans.trans_date,
                    trans_type = trans.trans_type
                };

                _context.FundTransfer.Add(ft);

                _context.SaveChanges();

                return StatusCode(200, "1");
                    
            }
            return StatusCode(200, "-1");

        }


    }
}
