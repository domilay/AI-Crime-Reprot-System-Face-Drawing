using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AIFaceDrawing.PolicePages
{
    /// <summary>
    /// Wanted.xaml 的交互逻辑
    /// </summary>
    public partial class Wanted : BasePageP
    {
        public Wanted()
        {
            InitializeComponent();
        }

        public void Select_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "(*.jpg,*.png,*.jpeg,*.bmp,*.gif)|*.JPG;*.PNG;*.JPEG;*.BMP;*.GIF|All files(*.*)|*.*"
            };
            if (ofd.ShowDialog() == DialogResult.OK && ofd.CheckFileExists.Equals(true))
            {
                imageS.Source = new BitmapImage(new Uri(ofd.FileName));
            }
            ofd.Dispose();
        }

        public void Add_Click(object sender, RoutedEventArgs e)
        {
            if(imageS.Source != null)
            {
                //添加图片到WantedDatabase里
                if (!File.Exists(imageS.Source.ToString()))
                {
                    string newName = DateTime.Now.ToString("mmddhhmm") + ".jpg";
                    string destName = @"C:\Users\rella\Documents\Visual Studio 2015\Projects\AIFaceDrawing\AIFaceDrawing\Databases\WantedDatabase\"+ newName;
                    string path = imageS.Source.ToString().Remove(0, 8);
                    //FileStream fs = new FileStream()
                    using(MemoryStream ms = new MemoryStream())
                    {
                        Bitmap bmp = new Bitmap(path);
                        bmp.Save(destName);
                        bmp.Dispose();
                        System.Windows.Forms.MessageBox.Show("Save Success.");
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("This criminal has already been added.");
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No Photo.");
            }
        }

    }
}
