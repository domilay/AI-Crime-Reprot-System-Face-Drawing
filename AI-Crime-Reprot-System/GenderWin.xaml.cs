using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Diagnostics;

namespace AIFaceDrawing
{
    /// <summary>
    /// GenderWin.xaml 的交互逻辑
    /// </summary>
    public partial class GenderWin : Window
    {
        public GenderWin()
        {
            InitializeComponent();
        }

        private void Male_Click(object sender, RoutedEventArgs e)
        {
            string path = @"C:\Users\rella\Desktop\AutoMaleFace";
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            if(process != null)
            {
                process.StartInfo.FileName = "automale.exe";
                process.StartInfo.WorkingDirectory = path;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                process.Start();
                process.WaitForExit();
            }
            else
            {
                if (process.HasExited)
                {
                    process.Start();
                    process.WaitForExit();
                }
            }
            
            //TextWindow tw = new TextWindow();
            //tw.Show();
        }

        private void Female_Click(object sender, RoutedEventArgs e)
        {
            string path = @"C:\Users\rella\Desktop\AutoFemaleFace";
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            if (process != null)
            {
                process.StartInfo.FileName = "autofemale.exe";
                process.StartInfo.WorkingDirectory = path;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                process.Start();
                process.WaitForExit();
            }
            else
            {
                if (process.HasExited)
                {
                    process.Start();
                    process.WaitForExit();
                }
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            TextWindow tw = new TextWindow();
            tw.Show();
        }
    }
}
