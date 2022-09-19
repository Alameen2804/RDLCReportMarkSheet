using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TaskRDLCReportMarkSheet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string FileName = "TaskRDLCReportMarkSheet";
        string FilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//RDLCDemo";

        List<CollegeDetails> CollegeData = new List<CollegeDetails>();
        List<StudentDetails> StudentData = new List<StudentDetails>();
        List<MarkDetails> MarksData = new List<MarkDetails>();
        List<GradePart> GradeData = new List<GradePart>();

        public MainWindow()
        {
            InitializeComponent();
            LoadCollegeData();
            LoadStudentData();
            LoadMarksData();
            LoadGradeData();
            Process();
        }

        void Process()
        {
            //STEP 1
            DataTable dt1 = new DataTable();
            dt1 = ConvertToDataTable(CollegeData);

            DataTable dt2 = new DataTable();
            dt2 = ConvertToDataTable(StudentData);

            DataTable dt3 = new DataTable();
            dt3 = ConvertToDataTable(MarksData);

            DataTable dt4 = new DataTable();
            dt4 = ConvertToDataTable(GradeData);

             //STEP 2
            ReportDataSource reportdata1 = new ReportDataSource();
            reportdata1.Name = "DataSet1";
            reportdata1.Value = dt1;

            ReportDataSource reportdata2 = new ReportDataSource();
            reportdata2.Name = "DataSet2";
            reportdata2.Value = dt2;

            ReportDataSource reportdata3 = new ReportDataSource();
            reportdata3.Name = "DataSet3";
            reportdata3.Value = dt3;

            ReportDataSource reportdata4 = new ReportDataSource();
            reportdata4.Name = "DataSet4";
            reportdata4.Value = dt4;

            //STEP 3: MAIN PROCESS
            ReportViewer rv1 = new ReportViewer();
            rv1.LocalReport.ReportEmbeddedResource = "TaskRDLCReportMarkSheet.Report1.rdlc";
            rv1.LocalReport.DataSources.Add(reportdata1);
            rv1.LocalReport.DataSources.Add(reportdata2);
            rv1.LocalReport.DataSources.Add(reportdata3);
            rv1.LocalReport.DataSources.Add(reportdata4);
            rv1.RefreshReport();
            rv1.ProcessingMode = ProcessingMode.Local;

            //STEP 4
            Warning[] warnings1;
            string[] streamids1;
            string mimeType1;
            string encoding1;
            string extension1;
            try
            {
                byte[] bytes = rv1.LocalReport.Render("PDF", null, out mimeType1, out encoding1, out extension1, out streamids1, out warnings1);
                string fullpath = System.IO.Path.Combine(FilePath + "\\" + FileName + ".pdf");
                FileStream fs = new FileStream(fullpath, FileMode.Create);
                var temps = fs.ToString();
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        void LoadCollegeData()
        {
            CollegeData.Add(new CollegeDetails("JAMAL MOHAMED COLLEGE",
                "Accredited (3rd cycle) with 'A' Grade by NAAC", "DBT Star College Scheme & DST-FIST Funded",
                "(Affiliated to Bharathidasan University)", "TIRUCHIRAMPPALLI- 620 020"));
        }

        void LoadStudentData()
        {
            StudentData.Add(new StudentDetails("ALAMEEN U","M.C.A","Computer Application",
                "19MCA024","28/04/1999","November-2019"));
        }

        void LoadMarksData()
        {
            MarksData.Add(new MarkDetails("1",6,"Algorithm",7.6,6.7,7.6,6.7,8.2,54,74,"P"));
            MarksData.Add(new MarkDetails("1",6,"Java",6.6,5.7,5.6,5.7,6.2,54,43,"P"));
            MarksData.Add(new MarkDetails("1",6,"MySQL",7.6,1.7,2.6,2.7,5.2,45,54,"F"));
        }
        
        void LoadGradeData()
        {
            GradeData.Add(new GradePart(8.7,"                   A+",7.6,7.6,6,7));
        }
    }
}
