using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentEdit2
{
    public class Link : Element
    {
        public Interface[] Node = new Interface[2];
        public GraphicsPath path;

        public Link()
        {
            path = new GraphicsPath();
        }

        public override void Display(Graphics g)
        {

        }

        public override void Move()
        {

        }
        
    }
}
