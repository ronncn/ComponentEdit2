using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentEdit2
{
    public class ToolContext
    {
        private ToolStrategy toolStrategy;
        private Canvas canvas;
        public ToolContext(Canvas canvas)
        {
            this.canvas = canvas;
        }


        public void SetToolStrategy(CanvasToolStyle style)
        {
            switch (style)
            {
                case CanvasToolStyle.Select:
                    toolStrategy = new SelectToolStrategy();
                    break;
                case CanvasToolStyle.Connect:
                    break;
                case CanvasToolStyle.Drag:
                    toolStrategy = new DragToolStrategy(canvas);
                    break;
                case CanvasToolStyle.Text:
                    break;
                default:
                    toolStrategy = new SelectToolStrategy();
                    break;
            }
        }

        #region 公开的变量

        public ToolStrategy ToolStrategy
        {
            get { return toolStrategy; }
        }

        #endregion
    }
}
