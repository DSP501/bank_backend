using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bank_backend.Models
{
    public class Admin
    {
        [Key]
        public int emp_id { get; set; }
        public string emp_name { get; set; }
        public string designation { get; set; }
        public DateTime last_login_date_time { get; set; }

    }
}
