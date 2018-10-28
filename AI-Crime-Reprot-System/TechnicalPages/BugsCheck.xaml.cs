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

namespace AIFaceDrawing.TechnicalPages
{
    /// <summary>
    /// BugsCheck.xaml 的交互逻辑
    /// </summary>
    public partial class BugsCheck : BasePageT
    {
        public List<Text> bugs = new List<Text>();
        public static string selectPath;
        public BugsCheck()
        {
            InitializeComponent();
            this.InitBug();
        }

        public void InitBug()
        {
            GetAllBugsPath(@"C:\Users\rella\documents\visual studio 2015\Projects\AIFaceDrawing\AIFaceDrawing\Databases\BugsDatabase");
            listBugs.ItemsSource = bugs;
        }

        public void GetAllBugsPath(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] files = di.GetFiles("*.*", SearchOption.AllDirectories);
            if (files != null && files.Length > 0)
            {
                foreach (var file in files)
                {
                    if (file.Extension == (".txt") || file.Extension == (".TXT"))
                    {
                        bugs.Add(new Text()
                        {
                            FullPath = file.FullName
                        });
                    }
                }
            }
        }

        public void Bug_Click(object sender, MouseButtonEventArgs e)
        {
            //显示bug, clear button，新窗口，添加事件传递string
            //怎么获取点击的内容的路径啊
            //string selectPath = listBugs.SelectedItem.ToString();
            int t = listBugs.SelectedIndex;
            string path = bugs[t].FullPath.ToString();
            selectPath = path;
            BugWindow bw = new BugWindow();
            bw.Show();
        }

        

    }

    public class Text
    {
        public string FullPath { get; set; }
    }
}
