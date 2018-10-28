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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AIFaceDrawing.WitnessPages
{
    /// <summary>
    /// CriminalReport.xaml 的交互逻辑
    /// </summary>
    public partial class CriminalReport : BasePageW
    {
        public static string PicturePath;
        public CriminalReport()
        {
            InitializeComponent();
        }

        private void FaceDrawing_Click(object sender, RoutedEventArgs e)
        {
            SelectGender();
            
        }

        public void SelectGender()
        {
            //create a new window to enter text
            //TextWindow tw = new TextWindow();
            //tw.Show();
            GenderWin gw = new GenderWin();
            gw.Show();
        }

    }
}
