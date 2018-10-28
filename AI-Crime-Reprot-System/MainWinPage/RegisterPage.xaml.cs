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

namespace AIFaceDrawing.MainWinPage
{
    /// <summary>
    /// RegisterPage.xaml 的交互逻辑
    /// </summary>
    public partial class RegisterPage : BasePage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void AddAcc_Click(object sender, RoutedEventArgs e)
        {
            //还得加一个验证是否已存在该用户
            int pl = pin.Password.Length;
            if(pl == 6)
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Users\rella\Documents\Visual Studio 2015\Projects\AIFaceDrawing\AIFaceDrawing\Databases\AccountDatabase.txt", true))
                {
                    if (w.IsChecked.Equals(true))
                    {
                        writer.WriteLine("w" + pin.Password + userName.Text);
                        MessageBox.Show("Success.");
                    }
                    else if (p.IsChecked.Equals(true))
                    {
                        writer.WriteLine("p" + pin.Password + userName.Text);
                        MessageBox.Show("Success.");
                    }
                    else if (t.IsChecked.Equals(true))
                    {
                        writer.WriteLine("t" + pin.Password + userName.Text);
                        MessageBox.Show("Success.");
                    }
                    else
                    {
                        MessageBox.Show("Sorry, you have not finished!");
                    }
                }
            }
            else
            {
                MessageBox.Show("PIN need 6 characters.");
            }
            
        }
    }
}
