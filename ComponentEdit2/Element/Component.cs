using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml;
using System.Xml.Serialization;

namespace ComponentEdit2
{
    [XmlInclude(typeof(Bitmap))]
    [Serializable]
    public class Component :Element
    {
        public int Width { get { return Size.Width; } set { this.Size = new Size(value, Size.Height); } }
        public int Height { get { return Size.Height; }set { this.Size = new Size(Size.Width, value); } }

        public Point LeftTopPoint
        {
            get
            {
                return new Point(Location.X - Width / 2, Location.Y - Height / 2);
            }
        }

        public List<Interface> listInterface;               //该元件的接口列表
        public List<Component> listChildren;                //子元件的列表
        
        public Component()
        {
            listInterface = new List<Interface>();
            listChildren = new List<Component>();
        }
        public override void Display(Graphics g)
        {
            Bitmap map;
            if (listInterface.Count == 0)
                map = new Bitmap(this.Width, this.Height);
            else
                map = new Bitmap(this.Width + 30, this.Height + 30);
            Graphics gBuffer = Graphics.FromImage(map);
            gBuffer.TranslateTransform(map.Width / 2,map.Height / 2);
            gBuffer.Clear(Color.Transparent);
            Rectangle rect = new Rectangle(new Point(-this.Width / 2,-this.Height / 2),
                new Size(this.Width,this.Height));
            if (this.Attdisp.backImage != null)
            {
                gBuffer.DrawImage(this.Attdisp.backImage,rect);
            }
            else if(!this.Attdisp.backColor.IsEmpty)
            {
                SolidBrush brush = new SolidBrush(this.Attdisp.backColor);
                gBuffer.FillRectangle(brush,rect);
                Font font = new Font("黑体", 10);
                StringFormat format = new StringFormat();
                format.LineAlignment = StringAlignment.Center;  // 垂直居中
                format.Alignment = StringAlignment.Center;      // 水平居中
                gBuffer.DrawString(this.Name,font,Brushes.White,rect,format);
            }
            else
            {
                SolidBrush brush = new SolidBrush(Color.Gray);
                gBuffer.FillRectangle(brush, rect);
                Font font = new Font("黑体", 12);
                StringFormat format = new StringFormat();
                format.LineAlignment = StringAlignment.Center;  // 垂直居中
                format.Alignment = StringAlignment.Center;      // 水平居中
                gBuffer.DrawString(this.Name, font, Brushes.White, rect, format);
            }
            this.DrawInterface(gBuffer);
            g.DrawImage(map, new Point(this.Location.X - map.Width / 2,
                this.Location.Y - map.Height / 2));
            gBuffer.Dispose();
            map.Dispose();
        }

        private void DrawInterface(Graphics g)
        {
            //绘制元件上的接口元素
            if(listInterface.Count == 0)
            {
                return;
            }
            foreach(Interface inf in listInterface)
            {
                inf.Display(g);
            }
        }
        
        public override void Move(Point p)
        {
            this.Location = new Point(this.Location.X + p.X,
                this.Location.Y + p.Y);
        }

        public void AddInf(Interface inf)
        {
            listInterface.Add(inf);
        }

        public void RemoveInf(Interface inf)
        {
            listInterface.Remove(inf);
        }

        public void Add(Component component)
        {
            listChildren.Add(component);
        }

        public void Remove(Component component)
        {
            listChildren.Remove(component);
        }
    }
}
