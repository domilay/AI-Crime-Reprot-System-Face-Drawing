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
    /// LoginPage.xaml 的交互逻辑
    /// </summary>
    public partial class LoginPage : BasePage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        public int TxtLength()
        {
            int i = 0;
            using (StreamReader reader = new StreamReader(@"C:\Users\rella\Documents\Visual Studio 2015\Projects\AIFaceDrawing\AIFaceDrawing\Databases\AccountDatabase.txt", true))
            {
                string line = null;
                while((line = reader.ReadLine())!= null)
                {
                    i++;
                }
            }
            return i;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            //check account: username, pin, and acctype
            //according to acctype, go to the different window
            int l = TxtLength();
            string acc;
            using(StreamReader reader = new StreamReader(@"C:\Users\rella\Documents\Visual Studio 2015\Projects\AIFaceDrawing\AIFaceDrawing\Databases\AccountDatabase.txt", true))
            {
                bool isT = false;
                while ((acc = reader.ReadLine())!= null)
                {
                    string enter = pin.Password + userName.Text;
                    string t = acc[0].ToString();
                    if (acc.Substring(1) == enter)
                    {
                        if(t == "w")
                        {
                            AIFaceDrawing.WitnessWindow wittWin = new WitnessWindow();
                            wittWin.Show();
                            //this.Visibility = Visibility.Hidden;
                            isT = true;
                        }
                        else if (t == "p")
                        {
                            AIFaceDrawing.PoliceWindow policeWin = new PoliceWindow();
                            policeWin.Show();
                            
                            isT = true;
                        }
                        else
                        {
                            AIFaceDrawing.TechnicalWindow techWin = new TechnicalWindow();
                            techWin.Show();
                            isT = true;
                        }
                    }
                }
                if (isT == false)
                {
                    MessageBox.Show("Wrong!");
                }
            }
            
        }
    }
}
