using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bank_backend.Models
{
    public class User
    {
        [Key]
        public int user_ref_id { get; set; }

        public string title { get; set; }
        public string fname { get; set; }
        public string mname { get; set; }
        public string lname { get; set; }
        public string father_name { get; set; }

        public string mobile_no { get; set; }
        public string email { get; set; }

        public string aadhar_no { get; set; }
        public string pancard { get; set; }
        public DateTime dob { get; set; }

        public string occupation_type { get; set; }
        public string source_of_income { get; set; }
        public decimal gross_income { get; set; }

        public string add_line_1 { get; set; }
        public string add_line_2 { get; set; }
        public string landmark { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string pincode { get; set; }

        public string p_add_line_1 { get; set; }
        public string p_add_line_2 { get; set; }
        public string p_landmark { get; set; }
        public string p_state { get; set; }
        public string p_city { get; set; }
        public string p_pincode { get; set; }


        public DateTime reg_date { get; set; }

        public bool isapproved { get; set; }
        public bool has_debit_card { get; set; }
        public bool net_banking_active { get; set; }
        public bool addr_same { get; set; }


    }
}
