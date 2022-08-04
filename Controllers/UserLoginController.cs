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
    public class UserLoginController : ControllerBase
    {
        public ModelContext _context { get; }

        public UserLoginController(ModelContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<LoginUser> GetData()
        {
            var data = _context.LoginDetails.ToList();
            return data;
        }

        [HttpPost]
        public IActionResult Login(LoginUser user)
        {

            var data = _context.LoginDetails
                .Where(e => e.user_id == user.user_id).FirstOrDefault();

                
            if(data != null && data.islocked == false)     
            {

                if(user.password == data.password )
                {
                    if(data.isfirstlogin == true)
                    {
                        data.isfirstlogin = false;
                        _context.LoginDetails.Update(data);
                        _context.SaveChanges();
                        return StatusCode(200, "100");
                    }


                    var res = _context.UserDetails.FirstOrDefault(e => e.email == data.user_id);
                    data.last_login_date = DateTime.Now;
                    data.count = 0;
                    _context.LoginDetails.Update(data);
                    _context.SaveChanges();

                    return Ok(res);
                }
                else
                {
                    data.count++;

                    if (data.count == 3)
                    {
                       
                        data.islocked = true;
                        _context.LoginDetails.Update(data);
                        _context.SaveChanges();
                        return StatusCode(200, "-1");
                    }
                    else
                    {
                        _context.LoginDetails.Update(data);
                        _context.SaveChanges();
                        return StatusCode(200, "0");
                    }

                }
            }
            return StatusCode(200, "-1") ;
        }

        [Route("unlock")]
        [HttpPost]
        public IActionResult Unock(LoginUser user)
        {
            var data = _context.LoginDetails.Where(e => e.user_id == user.user_id).FirstOrDefault();

            if(data != null)
            {
                if (data.islocked == false)
                {
                    return StatusCode(200, "0");
                }

                data.islocked = false;
                data.count = 0;
                data.password = user.password;

                _context.LoginDetails.Update(data);
                _context.SaveChanges();
                return StatusCode(200, "1");
            }
            else
            {
                return NotFound();
            }

            


        }

        [Route("setcred")]
        [HttpPost]
        public IActionResult SetCred(LoginUser user)
        {
            var data = _context.LoginDetails.FirstOrDefault(e => e.user_id == user.user_id);

            if(data != null)
            {
                data.password = user.password;
                data.tpassword = user.tpassword;
                _context.LoginDetails.Update(data);
                _context.SaveChanges();
                return StatusCode(200, "1");
            }
            else
            {
                return StatusCode(200, "-1");
            }
        }




    }
}
