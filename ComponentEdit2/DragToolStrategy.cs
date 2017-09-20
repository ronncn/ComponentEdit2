using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComponentEdit2
{
    public class DragToolStrategy : ToolStrategy
    {
        private Canvas canvas;
        public DragToolStrategy(Canvas canvas)
        {
            this.canvas = canvas;
        }

        private bool dragFlag = false;
        private Point startPoint;
        private Point startAutoScrollPoint;

        public override void Down(Point p)
        {
            if ((Control.ModifierKeys & Keys.Control) == Keys.Alt)
            {
                dragFlag = true;
                startPoint = p;
                startAutoScrollPoint = canvas.AutoScrollPosition;
                MessageBox.Show("ctrl");
            }
        }

        public override void Move(Point p)
        {
            if (dragFlag)
            {
                canvas.AutoScrollPosition = new Point(-(p.X - startPoint.X + startAutoScrollPoint.X),
                                                    -(p.Y - startPoint.Y + startAutoScrollPoint.Y));
            }
        }

        public override void Up(Point p)
        {
            dragFlag = false;
        }
    }
}
