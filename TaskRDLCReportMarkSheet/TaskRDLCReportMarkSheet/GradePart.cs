using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskRDLCReportMarkSheet
{
    public class GradePart
    {

        public double GPA { get; set; }
        public string Grade { get; set; }
        public double WAM { get; set; }
        public double CGPA { get; set; }
        public double GradeRange { get; set; }
        public double CWAM { get; set; }

        public GradePart(double gpa, string grade, double wam, double cgpa, double graderange, double cwam)
        {
            this.GPA = gpa;
            this.Grade = grade;
            this.WAM = wam;
            this.CGPA = cgpa;
            this.GradeRange = GradeRange;
            this.CWAM = cwam;
        }
    }
}
