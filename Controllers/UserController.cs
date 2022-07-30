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
    public class UserController : ControllerBase
    {
        public ModelContext _context { get; }

        public UserController(ModelContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<User> getAllUser()
        {
            var data = _context.UserDetails.ToList();
            return data;
        }

        [HttpPost]
        public ActionResult Post(User user)
        {
            if (user != null)
            {
                user.reg_date = DateTime.Now;
                user.isapproved = false;
                user.net_banking_active = false;

                _context.UserDetails.Add(user);
                _context.SaveChanges();
                return Ok("Success");
            }
            else
            {
                return null;
            }
            
        }

        [HttpGet("{id}")]
        public ActionResult getUserById(int? id)
        {
            var data = _context.UserDetails.FirstOrDefault(e => e.user_ref_id == id);
            if (data == null)
            {
                return StatusCode(404); 
            }
            else
            {
                return Ok(data);
            }
        }

        

        [Route("getUnverifiedUser")]
        [HttpGet]
        public IEnumerable<User> getUnverifiedUser()
        {
            var data = _context.UserDetails.ToList().Where(e => e.isapproved == false);
            return data;
        }





    }
}






//[Route("getShortUserById")]
//[HttpGet("{id}")]
//public ActionResult<ShortUser> getShortUserById(int? id)
//{
//    var data = _context.UserDetails.FirstOrDefault(e => e.user_ref_id == id);


//    if (data == null)
//    {
//        return StatusCode(400);
//    }
//    else
//    {
//        var user = new ShortUser() { 
//            user_ref_id = data.user_ref_id,
//            fname = data.fname,
//            lname = data.lname,
//            reg_date = data.reg_date
//        };

//        return Ok(user);

//    }
//}