using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
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
using System.ComponentModel;
using MSWord = Microsoft.Office.Interop.Word;



namespace AIFaceDrawing.PolicePages
{
    /// <summary>
    /// NewFace.xaml 的交互逻辑
    /// </summary>
    public partial class NewFace : BasePageP
    {
        
        public NewFace()
        {
            InitializeComponent();
        }

        public void Upload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "(*.jpg,*.png,*.jpeg,*.bmp,*.gif)|*.JPG;*.PNG;*.JPEG;*.BMP;*.GIF|All files(*.*)|*.*"
            };
            if(ofd.ShowDialog() == DialogResult.OK && ofd.CheckFileExists.Equals(true))
            {
                imageS.Source = new BitmapImage(new Uri(ofd.FileName));
            }
            ofd.Dispose();
        }

        

        public void Ensure_Click(object sender, RoutedEventArgs e)
        {
            if (imageS.Source != null && imagelist.Text != null)
            {
                //生成报告上传
                Object nothing = System.Reflection.Missing.Value;
                Directory.CreateDirectory(@"C:\Users\rella\Documents\Visual Studio 2015\Projects\AIFaceDrawing\AIFaceDrawing\Databases\NewFaceDatabase");
                string name = DateTime.Now.ToLongDateString() + ".doc";
                object filename = @"C:\Users\rella\Documents\Visual Studio 2015\Projects\AIFaceDrawing\AIFaceDrawing\Databases\NewFaceDatabase\" + name;

                MSWord.Application wordApp = null;
                MSWord.Document wordDoc = null;
                wordApp = new MSWord.ApplicationClass();
                wordDoc = wordApp.Documents.Add(ref nothing, ref nothing, ref nothing, ref nothing);

                //报告内容
                //文本
                wordApp.Selection.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;
                wordApp.Selection.Font.Size = 30;
                wordApp.Selection.Font.Bold = 2;
                wordApp.Selection.TypeText("New Resident Face Report");
                wordApp.Selection.TypeParagraph();
                wordApp.Selection.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphLeft;
                wordApp.Selection.Font.Size = 20;
                wordApp.Selection.Font.Bold = 2;
                wordApp.Selection.TypeText("1. Information: ");
                wordApp.Selection.TypeParagraph();
                wordApp.Selection.TypeText(imagelist.Text);
                wordApp.Selection.TypeParagraph();

                //图片
                if (imageS.Source != null)
                {
                    object wordline = MSWord.WdUnits.wdLine;
                    object count = 3;
                    wordApp.Selection.MoveDown(ref wordline, count, nothing);
                    wordApp.Selection.TypeParagraph();
                    wordApp.Selection.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;
                    object LinkofFile = false;
                    object SaveDocument = true;
                    object range = wordApp.Selection.Range;
                    wordDoc.InlineShapes.AddPicture(imageS.Source.ToString(), ref LinkofFile, ref SaveDocument, ref range);
                    wordApp.Selection.TypeParagraph();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Lack of Picture.");
                }

                //文件保存
                wordDoc.SaveAs(ref filename, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing);
                wordDoc.Close(ref nothing, ref nothing, ref nothing);
                wordApp.Quit(ref nothing, ref nothing, ref nothing);
                System.Windows.Forms.MessageBox.Show("File" + name + "has already been saved.");
                //System.Runtime.InteropServices.Marshal.FinalReleaseComObject(wordApp);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Lack of Information! Please try check! ");
            }
            
        }

        
    }


}
