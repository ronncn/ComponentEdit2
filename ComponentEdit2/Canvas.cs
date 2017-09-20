using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ComponentEdit2
{
    public partial class Canvas : Panel
    {
        // canvas half width
        private static readonly int CW = 120;

        // canvas half height
        private static readonly int CH = 80;

        private Kernel kernel;

        private Size imageSize;
        private Size canvasSizeMin;
        private Size canvasSizeActual;
        private Rectangle rectImageOutLine;
        private Rectangle rectImage;

        private float Multiple = 1.0f;

        private ToolContext toolContext;

        public Canvas()
        {
            base.SetStyle(ControlStyles.UserPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.SupportsTransparentBackColor |
                ControlStyles.OptimizedDoubleBuffer, true);
            base.ResizeRedraw = true;
            base.BorderStyle = BorderStyle.FixedSingle;
            base.AutoScrollMinSize = Size.Empty;

            InitialValue();
        }

        public Canvas(Size size)
        {
            base.SetStyle(ControlStyles.UserPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.SupportsTransparentBackColor |
                ControlStyles.OptimizedDoubleBuffer, true);
            base.ResizeRedraw = true;
            base.BorderStyle = BorderStyle.FixedSingle;
            base.AutoScrollMinSize = Size.Empty;

            InitialValue();
        }

        public GridContext gridContext;

        private void InitialValue()
        {
            this.BackColor = Color.LightGray;
            this.Dock = DockStyle.Fill;
            kernel = new Kernel(new Size(1024, 768));
            this.imageSize = kernel.FinalBitmap.Size;
            this.toolContext = new ToolContext(this);

            //这里的参数可以用配置文件进行设置，记住上一次打开的设置
            TransformGrid(GridStyle.Line);

            RecalculateCanvas();
            WhenImageSizeChanged();

        }

        private bool dragFlag = false;
        private Point startPoint;
        private Point startAutoScrollPoint;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            /*
             * 
            Rectangle rect = new Rectangle(rectImage.X + AutoScrollPosition.X, rectImage.Y + AutoScrollPosition.Y,
                                            rectImage.Width,rectImage.Height);
            if(rect.Contains(e.Location))
            {
                kernel.Draws(TransformScreenPoint(e.Location));
                base.Invalidate();
            }
            *
            * */
            //cmdManager.ExecuteCommand(new CreatComponentCmd(kernel, TransformScreenPoint(e.Location)));
            if (CanvasTool.Tool == CanvasToolStyle.Drag || (Control.ModifierKeys & Keys.Alt) == Keys.Alt)
            {
                dragFlag = true;
                startPoint = e.Location;
                startAutoScrollPoint = this.AutoScrollPosition;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if(dragFlag)
            {
                this.AutoScrollPosition = new Point(-(e.X - startPoint.X + startAutoScrollPoint.X),
                                                    -(e.Y - startPoint.Y + startAutoScrollPoint.Y));
                //base.Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            dragFlag = false;
        }


        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                if (e.Delta > 0)
                {
                    IncreaseMultiple();
                }
                else
                {
                    DecreaseMultiple();
                }
            }
        }

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            RecalculateCanvas();
        }
        LineGridStrategy line = new LineGridStrategy();
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.HighSpeed;             //取消抗锯齿
            e.Graphics.TranslateTransform(AutoScrollPosition.X, AutoScrollPosition.Y);

            //dot.Draw(e.Graphics,rectImage);
            //line.Draw(e.Graphics, rectImage,Multiple);
            gridContext.DrawGrid(e.Graphics,rectImage);
            
            e.Graphics.DrawRectangle(Pens.Gray, rectImageOutLine);

            e.Graphics.DrawImage(kernel.FinalBitmap, rectImage);

            e.Graphics.ResetTransform();

            e.Graphics.TranslateTransform(
                rectImage.Location.X + AutoScrollPosition.X,
                rectImage.Location.Y + AutoScrollPosition.Y);
            
            //if (kernel.IsInSelecting)
            //{
            //    kernel.DrawSelectToolSelectingRect(e.Graphics);
            //}

            // draw selected rect
            //if (kernel.SelectedShapesCount > 0)
            //{
            //    kernel.DrawSizableRects(e.Graphics);
            //}

            e.Graphics.ResetTransform();
        }

        private void RecalculateCanvas()
        {
            imageSize = new Size((int)(kernel.FinalBitmap.Size.Width * Multiple), (int)(kernel.FinalBitmap.Size.Height * Multiple));
            int w = (ClientSize.Width - imageSize.Width) / 2;
            int h = (ClientSize.Height - imageSize.Height) / 2;
            int cw = Math.Max(w, (int)(CW * Multiple));
            int ch = Math.Max(h, (int)(CH * Multiple));
            canvasSizeActual = new Size(imageSize.Width + cw * 2,imageSize.Height + ch * 2);

            rectImage = new Rectangle(new Point(cw , ch),imageSize);
            rectImageOutLine = new Rectangle(cw - 1, ch - 1, imageSize.Width + 1, imageSize.Height + 1);
        }

        private void WhenImageSizeChanged()
        {
            canvasSizeMin = new Size(imageSize.Width + (int)(CW * Multiple) * 2, imageSize.Height + (int)(CH * Multiple) * 2);
            base.AutoScrollMinSize = canvasSizeMin;
        }

        private Point TransformScreenPoint(Point pos)
        {
            pos.Offset(-rectImage.Location.X - AutoScrollPosition.X,
                       -rectImage.Location.Y - AutoScrollPosition.Y);
            pos.X = (int)(pos.X / Multiple);
            pos.Y = (int)(pos.Y / Multiple);
            return pos;
        }

        #region Canvas 外部调用的一些方法 

        /// <summary>
        /// 增大视图倍数
        /// </summary>
        public void IncreaseMultiple()
        {
            if(this.Multiple <= 2.0f)
            {
                this.Multiple = this.Multiple + 0.1f;
                RecalculateCanvas();
                WhenImageSizeChanged();
                base.Invalidate();
            }
        }
        /// <summary>
        /// 减小视图倍数
        /// </summary>
        public void DecreaseMultiple()
        {
            if(this.Multiple >= 0.1f)
            {
                this.Multiple = this.Multiple - 0.1f;
                RecalculateCanvas();
                WhenImageSizeChanged();
                base.Invalidate();
            }
        }
        /// <summary>
        /// 恢复倍数到1.0f
        /// </summary>
        public void ResetMultiple()
        {
            this.Multiple = 1.0f;
            RecalculateCanvas();
            WhenImageSizeChanged();
            base.Invalidate();
        }
        /// <summary>
        /// 切换网格
        /// </summary>
        /// <param name="gridstyle"></param>
        public void TransformGrid(GridStyle gridstyle)
        {
            gridContext = new GridContext(gridstyle);
            base.Invalidate();
        }

        CommandManager cmdManager = new CommandManager();
        public void _DragDrop(DragEventArgs e)
        {
            Component component = new Component();
            component = (Component)e.Data.GetData(typeof(Component));
            Point ClientPoint = this.PointToClient(new Point(e.X, e.Y));
            component.DesignProperty.Location = TransformScreenPoint(ClientPoint);
            cmdManager.ExecuteCommand(new CreatComponentCmd(component));
            base.Invalidate();
        }

        public void Redo()
        {
            this.kernel.Redo();
            base.Invalidate();
        }

        public void Undo()
        {
            this.kernel.Undo();
            base.Invalidate();
        }

        #endregion

        #region 公开的变量

        //public Kernel Kernel { get { return kernel; } }

        #endregion
    }
}
