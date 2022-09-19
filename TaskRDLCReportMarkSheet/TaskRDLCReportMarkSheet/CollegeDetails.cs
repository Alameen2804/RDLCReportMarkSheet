using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskRDLCReportMarkSheet
{
    public class CollegeDetails
    {
        public string CollegeName { get; set; }
        public string NAAC { get; set; }
        public string SchemeAndFunded { get; set; }
        public string Affiliated { get; set; }
        public string Address { get; set; }
        public string Datetime { get; set; }


        public CollegeDetails(string clgname, string naac, string schemeandfunded, string affiliated, string address)
        {
            this.CollegeName = clgname;
            this.NAAC = naac;
            this.SchemeAndFunded = schemeandfunded;
            this.Affiliated = affiliated;
            this.Address = address;
            this.Datetime = DateTime.Now.ToShortDateString();
        }
    }
}
