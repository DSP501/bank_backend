using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bank_backend.Models
{
    public class FundTransfer
    {
        [Key]
        public int ft_id { get; set; }
        public string user_id { get; set; }
        public long to_acc_no { get; set; }
        public string to_ifsc { get; set; }
        public string to_name { get; set; }
        public string to_bank { get; set; }
        public decimal amount { get; set; }
        public DateTime ft_date { get; set; }
        public string trans_type { get; set; }
        
    }
}
