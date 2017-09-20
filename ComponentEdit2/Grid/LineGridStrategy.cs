using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentEdit2
{
    public class LineGridStrategy : GridStrategy
    {
        public LineGridStrategy()
        {

        }
        public override void Draw(Graphics g, Rectangle rect)
        {
            this.gGrid = g;
            this.GridRect = rect;
            Pen gridPen = new Pen(GridColor,1);
            gGrid.FillRectangle(Brushes.White, GridRect);
            for (int i = GridRect.X; i < GridRect.Width + GridRect.X; i += GridInterval)
            {
                gGrid.DrawLine(gridPen, new Point(i, GridRect.Y), new Point(i, GridRect.Height + GridRect.Y));
            }
            for (int j = GridRect.Y; j < GridRect.Height + GridRect.Y; j += GridInterval)
            {
                gGrid.DrawLine(gridPen, new Point(GridRect.X, j), new Point(GridRect.Width + GridRect.X, j));
            }
            gridPen.Dispose();
        }
    }
}
