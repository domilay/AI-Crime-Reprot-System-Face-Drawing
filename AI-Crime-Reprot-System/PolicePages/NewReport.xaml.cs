using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
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
using System.Windows.Xps.Packaging;

namespace AIFaceDrawing.PolicePages
{
    /// <summary>
    /// NewReport.xaml 的交互逻辑
    /// </summary>
    public partial class NewReport : BasePageP
    {
        public List<Report> reports = new List<Report>();
        public static string reportPath;
        public NewReport()
        {
            InitializeComponent();
            this.InitReport();
        }

        private void InitReport()
        {
            //FolderBrowserDialog fbd = new FolderBrowserDialog();
            //fbd.ShowDialog();
            //string rootPath = fbd.SelectedPath;
            GetAllReportPath(@"C:\Users\rella\documents\visual studio 2015\Projects\AIFaceDrawing\AIFaceDrawing\Databases\CriminalReportDatabase");
            listReports.ItemsSource = reports;
        }

        public void GetAllReportPath(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] files = di.GetFiles("*.*", SearchOption.AllDirectories);
            if (files != null && files.Length > 0)
            {
                foreach (var file in files)
                {
                    //此处还需改成report的格式 
                    if (file.Extension == (".doc"))
                    {
                        reports.Add(new Report()
                        {
                            FullPath = file.FullName,
                            Count = file.CreationTime.ToLongDateString()
                        });
                    }
                }
            }
            else
            {
                MessageBox.Show("No new report.");
            }
        }
        
        private void Report_Click(object sender, MouseButtonEventArgs e)
        {
            //建一个新窗口，弹出报告详情
            //需要传递报告的路径
            int t = listReports.SelectedIndex;
            if (t != -1)
            {
                string path = reports[t].FullPath.ToString();
                reportPath = path;
                ReportWindow rw = new ReportWindow();
                rw.Show();
            }
            else
            {
                MessageBox.Show("Please try again.");
            }
        }


    }

    public class Report
    {
        public string FullPath { get; set; }
        public string Count { get; set; }
    }

}
