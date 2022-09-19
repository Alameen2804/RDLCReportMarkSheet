using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskRDLCReportMarkSheet
{
    public class MarkDetails
    {
        public string Part { get; set; }
        public int Sem { get; set; }
        public string Course { get; set; }
        public double IAMax { get; set; }
        public double IASec { get; set; }
        public double SEMax { get; set; }
        public double SESec { get; set; }
        public double TotalMax { get; set; }
        public double TotalSec { get; set; }
        public double CreditEarned { get; set; }
        public double GradePoint { get; set; }
        public double WeightedParts { get; set; }
        public string Result { get; set; }

        public MarkDetails(string part, int sem, string course, double iamax, double iasec, double semax,
            double sesec, double creditearned, double gradepoint, double weightedparts, string result)
        {
            this.Part = part;
            this.Sem = sem;
            this.Course = course;
            this.IAMax = iamax;
            this.IASec = iasec;
            this.SEMax = semax;
            this.SESec = sesec;
            this.TotalMax = IAMax + SEMax;
            this.TotalSec = IASec + SESec;
            this.CreditEarned = creditearned;
            this.GradePoint = gradepoint;
            this.WeightedParts = weightedparts;
            this.Result = result;
        }
    }
}
