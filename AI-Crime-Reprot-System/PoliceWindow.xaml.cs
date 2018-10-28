using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
    /// PoliceWindow.xaml 的交互逻辑
    /// </summary>
    public partial class PoliceWindow : Window
    {
        public PoliceWindow()
        {
            InitializeComponent();
        }

        public void Navigate_Click2(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Tag != null)
            {
                try
                {
                    string a = btn.Content.ToString();
                    string path = "AIFaceDrawing.PolicePages." + btn.Tag.ToString();
                    Type type = Type.GetType(path);
                    object obj = type.Assembly.CreateInstance(path);
                    Page p = obj as Page;
                    this.frmLayout.Content = p;
                    PropertyInfo[] infos = type.GetProperties();
                    foreach (PropertyInfo info in infos)
                    {
                        if (info.Name == "ParentWin")
                        {
                            info.SetValue(p, this, null);
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        


public void SendBug_Click(object sender, RoutedEventArgs e)
        {
            //写一个对话框，填入bug内容
            //生成随机名字，以时间命名好了，写入txt文件
            BugEnterWin bew = new BugEnterWin();
            bew.Show();
        }
    }
}
