using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ComponentEdit2
{
    public abstract class ToolStrategy
    {
        public abstract void Down(Point p);
        public abstract void Move(Point p);
        public abstract void Up(Point p);
    }
}
