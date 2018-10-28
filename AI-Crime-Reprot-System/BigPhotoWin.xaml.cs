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

namespace AIFaceDrawing
{
    /// <summary>
    /// BigPhotoWin.xaml 的交互逻辑
    /// </summary>
    public partial class BigPhotoWin : Window
    {
        public static string PP;
        public BigPhotoWin()
        {
            InitializeComponent();
            PP = WitnessPages.WantedCheck.photoPath;
            imageS.Source = new BitmapImage(new Uri(PP));

        }

        
    }
}
