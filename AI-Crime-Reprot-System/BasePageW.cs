using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AIFaceDrawing
{
    public class BasePageW: Page
    {
        WitnessWindow _parentWindowW;
        public WitnessWindow ParentWinW
        {
            get { return _parentWindowW; }
            set { _parentWindowW = value; }
        }
    }
}
