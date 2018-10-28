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
    /// BugEnterWin.xaml 的交互逻辑
    /// </summary>
    public partial class BugEnterWin : Window
    {
        public BugEnterWin()
        {
            InitializeComponent();
        }
        //This window is for witness and police to input bugs
        public void Yes_Click(object sender, RoutedEventArgs e)
        {
            DateTime dt = new DateTime();
            dt = DateTime.Now.Date;
            string rn = dt.ToString();
            string path = @"C:\Users\rella\Documents\Visual Studio 2015\Projects\AIFaceDrawing\AIFaceDrawing\Databases\BugsDatabase\123.txt";
            FileStream fs = new FileStream(path, FileMode.CreateNew);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(textBox.Text);
            sw.Flush();
            sw.Close();
            fs.Close();
            this.Close();
        }

    }
}
