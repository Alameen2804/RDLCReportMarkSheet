using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskRDLCReportMarkSheet
{
    public class StudentDetails
    {
        public string StdName { get; set; }
        public string Degree { get; set; }
        public string Branch { get; set; }
        public string RegNo { get; set; }
        public string DateOfBirth { get; set; }
        public string MonthAndYear { get; set; }

        public StudentDetails(string stdname, string degree, string branch, string regno, string dob, string monthandyear)
        {
            this.StdName = stdname;
            this.Degree = degree;
            this.Branch = branch;
            this.RegNo = regno;
            this.DateOfBirth = dob;
            this.MonthAndYear = monthandyear;
        }
    }
}
