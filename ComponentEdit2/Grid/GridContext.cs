using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ComponentEdit2
{
    public enum GridStyle{ Null,Dot,Line }
    public class GridContext
    {
        GridStrategy gridStrategy;
        public GridContext(GridStyle gridstyle)
        {
            if(gridstyle == GridStyle.Null)
            {
                this.gridStrategy = new NullGridStrategy();
            }
            else if(gridstyle == GridStyle.Dot)
            {
                this.gridStrategy = new DotGridStrategy();
            }
            else if(gridstyle == GridStyle.Line)
            {
                this.gridStrategy = new LineGridStrategy();
            }
        }
        
        public void DrawGrid(Graphics g, Rectangle rect)
        {
            gridStrategy.Draw(g, rect);
        }
    }
}
