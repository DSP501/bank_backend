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

        [Route("getUserByRefId/{id}")]
        [HttpGet("{id}")]
        public IActionResult getUserByRefId(int id)
        {
            var data = _context.UserDetails.FirstOrDefault(u => u.user_ref_id == id);
            return Ok(data);
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
                return StatusCode(200);
            }
            else
            {
                return null;
            }
            
        }

        [Route("getUserById")]
        [HttpPost]
        public ActionResult getUserById(User id)
        {
            var data = _context.UserDetails.Where(e => e.email == id.email).FirstOrDefault();
            if (data == null)
            {
                return StatusCode(200, "-1"); 
            }
            else
            {
                return Ok(data);
            }
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