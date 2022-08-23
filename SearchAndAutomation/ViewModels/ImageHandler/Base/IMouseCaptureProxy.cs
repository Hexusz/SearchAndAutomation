using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAndAutomation.ViewModels.ImageHandler.Base
{
    public interface IMouseCaptureProxy
    {
        event EventHandler Capture;
        event EventHandler Release;

        void OnMouseDown(object sender, MouseCaptureArgs e);
        void OnMouseMove(object sender, MouseCaptureArgs e);
        void OnMouseUp(object sender, MouseCaptureArgs e);
    }
}
