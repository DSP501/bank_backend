using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bank_backend.Models
{
    public class LoginUser
    {
        [Key]
        public int login_id { get; set; }
        public int user_ref_id { get; set; }
        public string user_id { get; set; }
        public string password { get; set; }
        public string tpassword { get; set; }
        public DateTime last_login_date { get; set; }
        public int count { get; set; }
        public bool islocked { get; set; }
        public bool isfirstlogin { get; set; }


    }
}
