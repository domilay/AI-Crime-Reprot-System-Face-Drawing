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
using MSWord = Microsoft.Office.Interop.Word;
using System.IO;

namespace AIFaceDrawing
{
    /// <summary>
    /// TextWindow.xaml 的交互逻辑
    /// </summary>
    public partial class TextWindow : System.Windows.Window
    {
        public static string Path;
        public TextWindow()
        {
            InitializeComponent();
            tb1.Text = "Please Submit More Details About The Case: \n" + "Best include: \n" + "1) Case Detail: When, Where, What\n2) Your Personal Information";
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (tb2.Text != null)
            {
                //生成报告上传
                Object nothing = System.Reflection.Missing.Value;
                Directory.CreateDirectory(@"C:\Users\rella\Documents\Visual Studio 2015\Projects\AIFaceDrawing\AIFaceDrawing\Databases\CriminalReportDatabase");
                string name = DateTime.Now.ToLongDateString() + DateTime.Now.Second.ToString() + ".doc";
                object filename = @"C:\Users\rella\Documents\Visual Studio 2015\Projects\AIFaceDrawing\AIFaceDrawing\Databases\CriminalReportDatabase\" + name;

                MSWord.Application wordApp = null;
                MSWord.Document wordDoc = null;
                wordApp = new MSWord.ApplicationClass();
                wordDoc = wordApp.Documents.Add(ref nothing, ref nothing, ref nothing, ref nothing);

                //报告内容
                //文本
                wordApp.Selection.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;
                wordApp.Selection.Font.Size = 30;
                wordApp.Selection.Font.Bold = 2;
                wordApp.Selection.TypeText("New Criminal Report");
                wordApp.Selection.TypeParagraph();
                wordApp.Selection.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphLeft;
                wordApp.Selection.Font.Size = 20;
                wordApp.Selection.Font.Bold = 2;
                wordApp.Selection.TypeText("1. Information: ");
                wordApp.Selection.TypeParagraph();
                wordApp.Selection.TypeText(tb2.Text);
                wordApp.Selection.TypeParagraph();

                //图片
                string imaMalePath = @"C:\Users\rella\Desktop\AutoMaleFace\humanface.jpg";
                string imaFemalePath = @"C:\Users\rella\Desktop\AutoFemaleFace\humanface.jpg";
                if (File.Exists(imaMalePath))
                {
                    object wordline = MSWord.WdUnits.wdLine;
                    object count = 3;
                    wordApp.Selection.MoveDown(ref wordline, count, nothing);
                    wordApp.Selection.TypeParagraph();
                    wordApp.Selection.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;
                    object LinkofFile = false;
                    object SaveDocument = true;
                    object range = wordApp.Selection.Range;
                    wordDoc.InlineShapes.AddPicture(imaMalePath, ref LinkofFile, ref SaveDocument, ref range);
                    wordApp.Selection.TypeParagraph();
                    File.Delete(imaMalePath);
                }
                else if (File.Exists(imaFemalePath))
                {
                    object wordline = MSWord.WdUnits.wdLine;
                    object count = 3;
                    wordApp.Selection.MoveDown(ref wordline, count, nothing);
                    wordApp.Selection.TypeParagraph();
                    wordApp.Selection.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;
                    object LinkofFile = false;
                    object SaveDocument = true;
                    object range = wordApp.Selection.Range;
                    wordDoc.InlineShapes.AddPicture(imaFemalePath, ref LinkofFile, ref SaveDocument, ref range);
                    wordApp.Selection.TypeParagraph();
                    File.Delete(imaFemalePath);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Lack of Picture.");
                }

                //文件保存
                wordDoc.SaveAs(ref filename, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing);
                wordDoc.Close(ref nothing, ref nothing, ref nothing);
                wordApp.Quit(ref nothing, ref nothing, ref nothing);
                System.Windows.Forms.MessageBox.Show("File" + name + " has already been saved.");
            }
            else
            {
                MessageBox.Show("Please Enter Details.");
            }
        }
    }
}
