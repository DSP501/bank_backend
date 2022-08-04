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
    public class AdminController : ControllerBase
    {

        public ModelContext _context { get; }

        public AdminController(ModelContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public IEnumerable<User> getUnverifiedUser()
        {
            var data = _context.UserDetails.ToList().Where(e => e.isapproved == false);

            if (data != null)
                return data;

            return null;
        }


        [HttpPost]
        public IActionResult Login(Admin admin)
        {
            var data = _context.Employee.FirstOrDefault(e => e.emp_id == admin.emp_id);

            if(data != null)
            {
                if(data.designation == "Manager")
                {
                    return StatusCode(200, data);
                }
                else
                {
                    return StatusCode(200, "0");
                }
            }
            return StatusCode(200, "1");
        }

        [Route("getUserById/{id}")]
        [HttpGet]
        public ActionResult getUserById(int? id)
        {
            //Console.WriteLine(id);
            var data = _context.UserDetails.FirstOrDefault(e => e.user_ref_id == Convert.ToInt32(id));

            if(data != null )
            {
                return Ok(data);
            }
            else
            {
                return StatusCode(200, "-1");
            }
        }

        [Route("approveuser/{id}")]
        [HttpGet]
        public IActionResult approveUser(int id)
        {
            var data = _context.UserDetails.FirstOrDefault(e => e.user_ref_id == id);

            if (data != null && data.isapproved == false)
            {
                data.isapproved = true;
                _context.UserDetails.Update(data);
                _context.SaveChanges();


                DateTime dt = DateTime.Now;
                string account_no = dt.Year.ToString() + dt.Month + dt.Day + dt.Hour + dt.Minute + dt.Second;
                long  no = Convert.ToInt64(account_no);

                Account acc = new Account()
                {
                    acc_no = no,
                    user_ref_id = id,
                    branch_name = data.city,
                    balance = 2000,
                    ifsc_code = data.city + data.pincode,
                    acc_creation_date = DateTime.Now
                };
                _context.AccountDetails.Add(acc);
                _context.SaveChanges();

                string s = data.dob.Day.ToString() + data.dob.Month.ToString() + data.dob.Year.ToString() ;
               



                LoginUser login = new LoginUser()
                {
                    user_ref_id = id,
                    user_id = data.email,
                    password = s,
                    tpassword = s,
                    count = 0,
                    last_login_date = DateTime.Now,
                    islocked = false,
                    isfirstlogin = true


                };

                _context.LoginDetails.Add(login);
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
