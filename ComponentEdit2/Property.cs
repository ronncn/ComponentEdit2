using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace ComponentEdit2
{
    [Serializable]
    public abstract class Property
    {
        public String Name;                 //属性名称
    }
    [Serializable]
    public class DesignProperty : Property
    {
        public DesignProperty()
        {
            this.Name = "设计属性";
            this.Location = new Point(0, 0);
            this.BackColor = Color.White;
        }

        #region 公开的属性变量

        [Description("元件的宽度"), Category("设计属性"), DefaultValue(50)]
        public int Width { get; set; }

        [Description("元件的高度"), Category("设计属性"), DefaultValue(50)]
        public int Height { get; set; }

        [Description("元件的尺寸"), Category("设计属性")]
        public Size Size { get { return new Size(Width, Height); } set { Width = value.Width; Height = value.Height; } }

        [Description("元件的位置"), Category("设计属性"), DefaultValue(typeof(Point),"0,0")]
        public Point Location { get; set; }

        [Description("元件的背景颜色"), Category("设计属性"), DefaultValue(typeof(Color), "0x808080")]
        public Color BackColor { get; set; }

        [Description("元件的字体颜色"), Category("设计属性"), DefaultValue(typeof(Color), "0xFFFFFF")]
        public Color ForeColor { get; set; }

        [Description("元件的背景图片"), Category("设计属性"), DefaultValue("无")]
        public Image BackImage { get; set; }

        #endregion

    }

    public class FunctionProperty : Property
    {
        public String Function;

        public FunctionProperty()
        {
            this.Name = "功能属性";
        }
    }

    public class Attributes : Property
    {
        public List<Property> listAttr;

        public Attributes()
        {
            listAttr = new List<Property>();
        }

        public void AddAttr(Property attr)
        {
            listAttr.Add(attr);
        }
        public void RemoveAttr(Property attr)
        {
            if(listAttr.Contains(attr))
            {
                listAttr.Remove(attr);
            }
        }
    }
}
