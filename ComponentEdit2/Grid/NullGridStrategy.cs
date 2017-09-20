using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ComponentEdit2
{
    public class NullGridStrategy : GridStrategy
    {
        public NullGridStrategy()
        {

        }
        
        public override void Draw(Graphics g,Rectangle rect)
        {
            this.gGrid = g;
            this.GridRect = rect;
            gGrid.FillRectangle(Brushes.White, GridRect);
        }
    }
}
