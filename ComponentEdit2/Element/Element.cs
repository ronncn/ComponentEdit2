using System;
using System.Drawing;

namespace ComponentEdit2
{
    public abstract class Element
    {
        public Int32 Id;
        public String Name;
        public String Type;
        public DesignProperty DesignProperty;

        public abstract void Display(Graphics g);
        public abstract void Move();
    }
}
