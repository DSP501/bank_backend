using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bank_backend.Models
{
    public class Account
    {
        [Key]
        public long acc_no { get; set; }
        public int user_ref_id { get; set; }
        public string branch_name { get; set; }
        public decimal balance { get; set; }
        public string ifsc_code { get; set; }
        public DateTime acc_creation_date { get; set; }
    }
}
