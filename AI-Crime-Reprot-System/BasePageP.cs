using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AIFaceDrawing
{
    public class BasePageP: Page
    {
        PoliceWindow _parentWindowP;
        public PoliceWindow ParentWinP
        {
            get { return _parentWindowP; }
            set { _parentWindowP = value; }
        }
    }
}
