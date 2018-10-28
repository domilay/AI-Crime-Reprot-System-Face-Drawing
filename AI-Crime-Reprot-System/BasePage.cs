using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AIFaceDrawing
{
    public class BasePage: Page
    {
        MainWindow _parentWindow;
        public MainWindow ParentWin
        {
            get { return _parentWindow; }
            set { _parentWindow = value; }
        }
    }
}
