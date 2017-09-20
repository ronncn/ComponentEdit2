using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ComponentEdit2
{
    public class DotGridStrategy : GridStrategy
    {
        public DotGridStrategy()
        {

        }
        public override void Draw(Graphics g, Rectangle rect)
        {
            this.gGrid = g;
            this.GridRect = rect;
            Pen gridPen = new Pen(GridColor, 0.5f);
            gGrid.FillRectangle(Brushes.White, GridRect);
            for (int i = GridRect.X; i < GridRect.Width + GridRect.X; i += GridInterval)
            {
                for (int j = GridRect.Y; j < GridRect.Height + GridRect.Y; j += GridInterval)
                {
                    gGrid.DrawLine(gridPen, new Point(i - 1, j), new Point(i + 1, j));
                    gGrid.DrawLine(gridPen, new Point(i, j - 1), new Point(i, j + 1));
                }
            }
            gridPen.Dispose();
        }
    }
}
