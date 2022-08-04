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
    public class PayeeController : ControllerBase
    {

        public ModelContext _context { get; }

        public PayeeController(ModelContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Add(Payee payee) {
            if (payee != null)
            {
                
                _context.Payee.Add(payee);
                _context.SaveChanges();
                return StatusCode(200, "1");
            }
            else
            {
                return StatusCode(200, "-1");
            }

        }

        [HttpGet("{id}")]
        public IEnumerable<Payee> getById(int? id)
        {
            var user = _context.UserDetails.FirstOrDefault(e => e.user_ref_id == id);

            if(user != null)
            {
                var payee = _context.Payee.Where(p => p.user_id == user.email).ToList();
                return payee;
            }
            else
            {
                return null; 
                    
            }
        }




    }
}
