using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AIFaceDrawing
{
    public class BasePageT: Page
    {
        AIFaceDrawing.TechnicalWindow _parentWindowT;
        public TechnicalWindow ParentWin
        {
            get { return _parentWindowT; }
            set { _parentWindowT = value; }
        }
    }
}
