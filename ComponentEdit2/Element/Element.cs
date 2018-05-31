using System;
using System.Drawing;

namespace ComponentEdit2
{
    [Serializable]
    public abstract class Element
    {
        public Int32 Id;
        public Attdisp Attdisp = new Attdisp();
        public String Name { get { return Attdisp.name; } set { Attdisp.name = value; } }
        public Size Size { get { return Attdisp.size; } set { Attdisp.size = value; } }
        public Point Location { get { return Attdisp.location; } set { Attdisp.location = value; } }

        public abstract void Display(Graphics g);
        public abstract void Move(Point p);
    }
}
