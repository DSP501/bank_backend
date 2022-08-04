using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bank_backend.Models
{
    public class Payee
    {
        [Key]
        public int payee_id { get; set; }
        public string user_id { get; set; }
        public long account_no { get; set; }
        public string ifsc { get; set; }
        public string bank_name { get; set; }
        public string payee_name { get; set; }
        public string nickname { get; set; }


    }
}
