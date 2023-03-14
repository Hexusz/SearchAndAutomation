using SAAlib.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAAlib.Actions
{
    public class MousePosition : IAutoAction
    {
        public Point Position;

        public MousePosition(Point position)
        {
            Position = position;
        }

        public void StartAction()
        {
            throw new NotImplementedException();
        }
    }
}
