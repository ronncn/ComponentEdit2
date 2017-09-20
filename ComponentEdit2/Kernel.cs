using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentEdit2
{
    public class Kernel
    {
        private Bitmap finalBitmap;
        private Graphics graphy;
        private ElementManager elementManager;

        public Kernel()
            :this(new Size(400,300))
        { }

        public Kernel(Size bitmapSize)
            :this(new Bitmap(bitmapSize.Width,bitmapSize.Height))
        { }

        public Kernel(Bitmap bitmap)
        {
            this.finalBitmap = bitmap;
            graphy = Graphics.FromImage(finalBitmap);
            InitialValue();
        }

        private void InitialValue()
        {
            graphy.SmoothingMode = SmoothingMode.HighQuality;
            elementManager = new ElementManager(this,graphy);
        }

        #region 公开的方法

        public void CreatComponent()
        {
        }

        public void RemoveComponent()
        {
            elementManager.RemoveComponent();
        }

        public void Redo()
        {
        }

        public void Undo()
        {
        }

        #endregion


        #region 公开的变量

        public Bitmap FinalBitmap
        {
            get { return finalBitmap; }
        }


        #endregion
    }
}
