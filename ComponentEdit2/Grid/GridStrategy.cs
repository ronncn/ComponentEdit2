using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ComponentEdit2
{
    public abstract class GridStrategy
    {
        public Color GridColor = Color.LightGray;
        public int GridInterval = 20;
        public Graphics gGrid;
        public Rectangle GridRect;

        public abstract void Draw(Graphics g,Rectangle rect);
    }
}
