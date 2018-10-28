using System;
using System.Collections.Generic;
using System.Data;
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
using System.Reflection;
using System.Windows.Forms;
using System.IO;


namespace AIFaceDrawing.WitnessPages
{
    /// <summary>
    /// WantedCheck.xaml 的交互逻辑
    /// </summary>
    public partial class WantedCheck : BasePageW
    {
        public List<Photo> photos = new List<Photo>();
        public static string photoPath;
        public WantedCheck()
        {
            InitializeComponent();
            this.InitPhoto();
        }

        private void InitPhoto()
        {
            //FolderBrowserDialog fbd = new FolderBrowserDialog();
            //fbd.ShowDialog();
            //string rootPath = fbd.SelectedPath;
            GetAllImagePath(@"C:\Users\rella\documents\visual studio 2015\Projects\AIFaceDrawing\AIFaceDrawing\Databases\WantedDatabase");
            listImages.ItemsSource = photos;
        }

        public void GetAllImagePath(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] files = di.GetFiles("*.*", SearchOption.AllDirectories);
            if (files != null && files.Length > 0)
            {
                foreach (var file in files)
                {
                    if (file.Extension == (".JPG") || file.Extension == (".PNG") || file.Extension == (".BMP") || file.Extension == (".GIF") || file.Extension == (".jpg") || file.Extension == (".png") || file.Extension == (".bmp"))
                    {
                        photos.Add(new Photo()
                        {
                            FullPath = file.FullName
                        });
                    }
                }
            }
        }

        private void Image_Click(object sender, MouseButtonEventArgs e)
        {
            //点击小图展示大图
            int t = listImages.SelectedIndex;
            if(t != -1)
            {
                string path = photos[t].FullPath.ToString();
                photoPath = path;
                BigPhotoWin bpw = new BigPhotoWin();
                bpw.Show();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Please try again.");
            }
            t = -1;
        }
    }

    public class Photo
    {
        public string FullPath { get; set; }
    }
}
