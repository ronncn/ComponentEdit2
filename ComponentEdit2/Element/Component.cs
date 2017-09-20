using System;
using System.Collections.Generic;
using System.Drawing;

namespace ComponentEdit2
{
    public class Component :Element
    {
        public List<Interface> listInterface;               //该元件的接口列表
        private List<Component> listChildren;               //子元件的列表

        public Component()
        {
            listInterface = new List<Interface>();
            listChildren = new List<Component>();
            this.DesignProperty = new DesignProperty();     //实例化设计的属性
        }

        public override void Display(Graphics g)
        {
            Bitmap map = new Bitmap(DesignProperty.Width + 10, DesignProperty.Height + 10);
            Graphics gBuffer = Graphics.FromImage(map);
            gBuffer.TranslateTransform(map.Width / 2,map.Height / 2);
            gBuffer.Clear(Color.Transparent);
            Rectangle rect = new Rectangle(new Point(-this.DesignProperty.Width / 2,-this.DesignProperty.Height / 2),
                new Size(this.DesignProperty.Width,this.DesignProperty.Height));
            if (DesignProperty.BackImage != null)
            {
                gBuffer.DrawImage(DesignProperty.BackImage,rect);
            }
            else if(!DesignProperty.BackColor.IsEmpty)
            {
                SolidBrush brush = new SolidBrush(DesignProperty.BackColor);
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
            g.DrawImage(map,this.DesignProperty.Location);
            gBuffer.Dispose();
            map.Dispose();
        }

        private void DrawInterface(Graphics g)
        {
            //绘制元件上的接口元素
        }
        
        public override void Move()
        {

        }

        public void AddInf()
        {
            Interface inf = new Interface();

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
