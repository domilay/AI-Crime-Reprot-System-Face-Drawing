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
using System.Xml;

using Microsoft.Office.Interop.Word;
using System.Xml.Linq;
using System.Windows.Xps.Packaging;

namespace AIFaceDrawing
{
    /// <summary>
    /// ReportWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ReportWindow : System.Windows.Window
    {
        public static string ReportPath;
        public ReportWindow()
        {
            InitializeComponent();
        }

        private XpsDocument ConvertWordToXPS(string wordDocName, string xpsDocName)
        {
            // Change the .doc file into .xps file, and return this document
            Microsoft.Office.Interop.Word.Application wordApplication = new Microsoft.Office.Interop.Word.Application();
            try
            {
                wordApplication.Documents.Open(wordDocName);
                wordApplication.Application.Visible = false;
                wordApplication.WindowState = WdWindowState.wdWindowStateMinimize;
                Document doc = wordApplication.ActiveDocument;
                doc.SaveAs2(xpsDocName, WdSaveFormat.wdFormatXPS);
                XpsDocument xpsDocument = new XpsDocument(xpsDocName, FileAccess.Read);
                return xpsDocument;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error, the error message is " + ex.ToString());
                return null;
            }
            finally
            {
                wordApplication.Documents.Close();
                ((_Application)wordApplication).Quit(WdSaveOptions.wdDoNotSaveChanges);
            }
            
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Succeed Submit!");
        }

        private void Contact_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Contacting..."); 
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ReportPath = PolicePages.NewReport.reportPath;
            //然后打开doc文件，读取里面内容
            //把内容加载到框里
            if(string.IsNullOrEmpty(ReportPath) || !File.Exists(ReportPath))
            {
                MessageBox.Show("The file is invalid.");
            }
            else
            {
                string convertedXpsDoc = string.Concat(System.IO.Path.GetTempPath(), "\\", Guid.NewGuid().ToString(), ".xps");
                XpsDocument xpsDocument = ConvertWordToXPS(ReportPath, convertedXpsDoc);
                if(xpsDocument == null)
                {
                    return;
                }
                docViewer.Document = xpsDocument.GetFixedDocumentSequence();
                docViewer.FitToWidth();
            }
            
        }
    }
}
