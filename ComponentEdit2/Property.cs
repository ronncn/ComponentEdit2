using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ComponentEdit2
{
    public abstract class Property
    {
        public String Name;                 //属性名称
    }

    public class DesignProperty : Property
    {
        public int Width = 50;                   //宽度
        public int Height = 50;                  //高度
        public Size Size;                   //尺寸大小
        public Point Location;              //位置
        public Color BackColor;             //背景颜色
        public Color ForeColor;             //字体颜色
        public Image BackImage;

        public DesignProperty()
        {
            this.Name = "设计属性";
            this.Size = new Size(this.Width, this.Height);
            this.Location = new Point(0, 0);
            this.BackColor = Color.White;
        }
    }

    public class FunctionProperty : Property
    {
        public String Function;

        public FunctionProperty()
        {
            this.Name = "功能属性";
        }
    }
}
