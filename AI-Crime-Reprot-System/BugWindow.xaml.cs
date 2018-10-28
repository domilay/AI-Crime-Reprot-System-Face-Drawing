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
using System.Windows.Shapes;

namespace AIFaceDrawing
{
    /// <summary>
    /// BugWindow.xaml 的交互逻辑
    /// </summary>
    public partial class BugWindow : Window
    {
        public static string Path;
        public BugWindow()
        {
            InitializeComponent();
            //传递事件，把内容路径传过来，得到path
            //打开文件读取信息
            Path = TechnicalPages.BugsCheck.selectPath;
            StreamReader reader = new StreamReader(Path, true);
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                tb.Text += line + "\r\n";
            }
            reader.Close();
        }

        public void Clear_Click(object sender, RoutedEventArgs e)
        {
            //打开BugsDatabase,把对应的txt文件删除
            if (File.Exists(Path))
            {
                File.Delete(Path);
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show("Not exists");
            }
            
        }

    }
}
