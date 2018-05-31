using System;
using System.Collections.Generic;
using System.Drawing;

namespace ComponentEdit2
{
    [Serializable]
    public class Interface : Element
    {
        public int Width { get { return Size.Width; } set { this.Size = new Size(value, Size.Height); } }
        public int Height { get { return Size.Height; } set { this.Size = new Size(Size.Width, value); } }

        public Point CenterPoint
        {
            get
            {
                return new Point(Location.X + Width / 2, Location.Y + Height / 2);
            }
        }

        public Network Network = null;
        public Component Parent = null;

        public Interface()
        {

        }

        public override void Display(Graphics g)
        {
            Bitmap infMap = new Bitmap(this.Width, this.Height);
            Graphics gBuffer = Graphics.FromImage(infMap);
            gBuffer.Clear(Color.Transparent);
            Rectangle rect = new Rectangle(new Point(0, 0), new Size(this.Width, this.Height));
            if(this.Attdisp.backImage != null)
            {
                gBuffer.DrawImage(this.Attdisp.backImage,rect);
            }
            else if (!this.Attdisp.backColor.IsEmpty)
            {
                SolidBrush brush = new SolidBrush(this.Attdisp.backColor);
                gBuffer.FillRectangle(brush, rect);
                brush.Dispose();
            }
            else
            {
                SolidBrush brush = new SolidBrush(Color.AliceBlue);
                gBuffer.FillRectangle(brush, rect);
                brush.Dispose();
            }
            g.DrawImage(infMap, this.Location);
            gBuffer.Dispose();
            infMap.Dispose();
        }

        public override void Move(Point p)
        {
            //暂时禁止移动，开放时也只能上下或者左右移动。
        }
    }
}
