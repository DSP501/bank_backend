using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bank_backend.Models
{
    public class Transaction
    {
        [Key]
        public int trans_id { get; set; }
        public string user_id { get; set; }
        public long to_acc_no { get; set; }
        public string to_ifsc { get; set; }
        public string to_name { get; set; }
        public string to_bank { get; set; }
        public decimal amount { get; set; }
        public DateTime trans_date { get; set; }
        public string trans_type { get; set; }
        public string remark { get; set; }
        public string trans_mode { get; set; }
        public string crdr { get; set; }


    }
}
