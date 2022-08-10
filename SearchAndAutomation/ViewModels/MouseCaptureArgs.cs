using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAndAutomation.ViewModels
{
    public class MouseCaptureArgs
    {
        public double X { get; set; }
        public double Y { get; set; }
        public bool LeftButton { get; set; }
        public bool RightButton { get; set; }
    }
}
