using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ComponentEdit2
{
    [Serializable]
    public partial class Canvas : Panel
    {
        // 画布类
        public int test = 1;
        private static readonly int CW = 120;       //画布外侧宽度
        private static readonly int CH = 80;        //画布外侧高度

        private Kernel kernel;                      //核心类

        private Size imageSize;                     //画面的尺寸
        private Size canvasSizeMin;                 //最小的画布尺寸
        private Size canvasSizeActual;              //实际的画布尺寸
        private Rectangle rectImageOutLine;         //矩形边框
        private Rectangle rectImage;                //矩形

        private float Multiple = 1.0f;              //画布放大的倍数
        
        private Attributes attributes;
        private ContextMenuStrip componentRightMenu;
        private IContainer components;
        private ToolStripMenuItem creatComLib;
        private ToolStripMenuItem addInterface;
        private ToolStripMenuItem DeleteComponent;
        public GridContext gridContext;

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
            this.Dock = DockStyle.Fill;

            InitialValue();             //初始化值
            InitialProperty();          //初始化属性
            InitializeComponent();      //初始化元件
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
            this.Dock = DockStyle.Fill;

            InitialValue();
            InitialProperty();
            InitializeComponent();
        }
        
        //初始化配置的值
        private void InitialValue()
        {
            //画布背景颜色
            this.BackColor = Color.LightGray;
            //画布核心的实例化
            kernel = new Kernel(new Size(1024, 768));
            kernel.CanvasPaint += new Kernel.CanvasPaintEventHandler(Reflesh);//重绘画布
            this.imageSize = kernel.FinalBitmap.Size;

            //这里的参数可以用配置文件进行设置，记住上一次打开的设置
            TransformGrid(GridStyle.Line);

            RecalculateCanvas();
            WhenImageSizeChanged();

        }
        public Panel Propertys;                 //属性容器
        private PropertyGrid propertyGrid;      
        private PropertyItem propertyItem;      
        //初始化属性
        private void InitialProperty()
        {
            this.attributes = new Attributes();
            this.propertyGrid = new PropertyGrid();
            this.propertyGrid.Size = new Size(180, 300);
            this.propertyGrid.Dock = DockStyle.Top;
            this.propertyGrid.Visible = true;
            this.propertyGrid.HelpVisible = false;
            this.propertyGrid.PropertyValueChanged += new PropertyValueChangedEventHandler(PropertyGridChanged);

            this.propertyItem = new PropertyItem(kernel);
            this.propertyItem.Dock = DockStyle.Top;
            
            this.Propertys = new Panel();
            this.Propertys.Dock = DockStyle.Fill;

        }
        
        //属性面板改变事件
        private void PropertyGridChanged(object sender,PropertyValueChangedEventArgs e)
        {
            this.kernel.DrawFinalBitmap();
            base.Invalidate();
        }
        
        //刷新属性
        private void ReflshProperty()
        {
            //最好做到--显示多元件属性

            this.propertyGrid.SelectedObject = null;            //初始化属性面板选择对象为空
            this.Propertys.Controls.Clear();

            //判断核心类中选中元素是否为空
            if (this.kernel.Active == null)
                return;

            this.propertyGrid.SelectedObject = this.kernel.Active.Attdisp;
            //显示选中元件时的属性
            if (this.kernel.Active.GetType() == typeof(Component))
            {
                Component component = (Component)kernel.Active;
                List<string> listNetName = new List<string>();
                this.propertyItem.comboBox_Inf.Items.Clear();
                this.propertyItem.comboBox_Net.Items.Clear();
                foreach (Interface inf in component.listInterface)
                {
                    this.propertyItem.comboBox_Inf.Items.Add(inf.Name);
                    if (inf.Network != null)
                    {
                        if (!listNetName.Contains(inf.Network.Name))
                        {
                            listNetName.Add(inf.Network.Name);
                        }
                    }
                }
                foreach (string str in listNetName)
                {
                    this.propertyItem.comboBox_Net.Items.Add(str);
                }
                if (component.listInterface.Count == 0)
                    this.propertyItem.comboBox_Inf.Text = "(无)";
                else
                    this.propertyItem.comboBox_Inf.SelectedIndex = 0;

                if (listNetName.Count == 0)
                {
                    this.propertyItem.comboBox_Net.Text = "(无)";
                }
                else
                {
                    this.propertyItem.comboBox_Net.SelectedIndex = 0;
                }

                this.Propertys.Controls.Add(propertyItem);
            }
            //选中接口显示的属性
            else if (this.kernel.Active.GetType() == typeof(Interface))
            {

            }
            else
            {
                //否则就是Network类型
            }
            this.Propertys.Controls.Add(this.propertyGrid);
        }
        
        private bool dragFlag = false;
        private Point startPoint;               //开始点的坐标
        private Point startAutoScrollPoint;
        
        //重绘画布
        private void Reflesh()
        {
            base.Invalidate();
        }

        //鼠标按下
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            startPoint = e.Location;            //开始点赋值为鼠标按下的点的坐标
            if(CanvasTool.Tool == CanvasToolStyle.Drag)
            {
                dragFlag = true;
                startAutoScrollPoint = this.AutoScrollPosition;
            }
            else
            {
                this.kernel.Mouse_Down(TransformScreenPoint(e.Location));//执行核心类鼠标按下事件函数
            }
        }

        //鼠标移动
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if(CanvasTool.Tool == CanvasToolStyle.Drag)
            {
                if (dragFlag)
                {
                    this.AutoScrollPosition = new Point(-(e.X - startPoint.X + startAutoScrollPoint.X),
                                                        -(e.Y - startPoint.Y + startAutoScrollPoint.Y));
                }
            }
            else
            {
                this.kernel.Mouse_Move(TransformScreenPoint(e.Location));
            }
        }

        //鼠标抬起
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (CanvasTool.Tool == CanvasToolStyle.Drag)
            {
                dragFlag = false;
            }
            else
            {
                this.kernel.Mouse_Up(TransformScreenPoint(e.Location));
                if(e.Button == MouseButtons.Right)
                {
                    if(this.kernel.Active != null && this.kernel.Active.GetType() == typeof(Component))
                        this.componentRightMenu.Show(this,e.Location);
                }
                this.ReflshProperty();
            }
        }
        
        //鼠标滚动
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

        //窗口变换
        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            RecalculateCanvas();
        }

        //绘制
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.HighSpeed;             //取消抗锯齿
            e.Graphics.TranslateTransform(AutoScrollPosition.X, AutoScrollPosition.Y);
            
            gridContext.DrawGrid(e.Graphics,rectImage);
            
            e.Graphics.DrawRectangle(Pens.Gray, rectImageOutLine);

            e.Graphics.DrawImage(kernel.FinalBitmap, rectImage);

            if (kernel.IsInTemp)
            {
                e.Graphics.DrawImage(kernel.TempBitmap, rectImage);
            }
            
            e.Graphics.ResetTransform();

            e.Graphics.TranslateTransform(
                rectImage.Location.X + AutoScrollPosition.X,
                rectImage.Location.Y + AutoScrollPosition.Y);
           
            // draw selected rect
            //if (kernel.SelectedShapesCount > 0)
            //{
            //    kernel.DrawSizableRects(e.Graphics);
            //}

            e.Graphics.ResetTransform();
        }
        
        //重新计算画布
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

        //当画布尺寸改变
        private void WhenImageSizeChanged()
        {
            canvasSizeMin = new Size(imageSize.Width + (int)(CW * Multiple) * 2, imageSize.Height + (int)(CH * Multiple) * 2);
            base.AutoScrollMinSize = canvasSizeMin;
        }

        //变换屏幕坐标
        private Point TransformScreenPoint(Point pos)
        {
            pos.Offset(-rectImage.Location.X - AutoScrollPosition.X,
                       -rectImage.Location.Y - AutoScrollPosition.Y);
            pos.X = (int)(pos.X / Multiple);
            pos.Y = (int)(pos.Y / Multiple);
            return pos;
        }

        private void creatComLib_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(this.kernel.CheckedComponent);
            f2.Show();
        }
        private void addInterface_Click(object sender,EventArgs e)
        {

        }
        private void DeleteComponent_Click(object sender,EventArgs e)
        {
            this.kernel.Remove();
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
        
        public void _DragDrop(DragEventArgs e)
        {
            string path = (string)e.Data.GetData(typeof(string));
            Point ClientPoint = this.PointToClient(new Point(e.X, e.Y));
            this.kernel.DragDrop(path,TransformScreenPoint(ClientPoint));
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

        public void Remove()
        {
            this.kernel.Remove();
            base.Invalidate();
        }

        public void Save()
        {
            this.kernel.Save();
        }

        public void Open()
        {
            this.kernel.Open();
            base.Invalidate();
        }

        public void OpenProperty()
        {
            if(this.kernel.Active != null)
            {
                this.propertyGrid.SelectedObject = this.kernel.Active.Attdisp;
            }
        }
        #endregion

        #region 公开的变量

        //public Kernel Kernel { get { return kernel; } }

        #endregion

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.componentRightMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.creatComLib = new System.Windows.Forms.ToolStripMenuItem();
            this.addInterface = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteComponent = new System.Windows.Forms.ToolStripMenuItem();
            this.componentRightMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // componentRightMenu
            // 
            this.componentRightMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.creatComLib,
            this.addInterface,
            this.DeleteComponent});
            this.componentRightMenu.Name = "componentRightMenu";
            this.componentRightMenu.Size = new System.Drawing.Size(149, 70);
            // 
            // creatComLib
            // 
            this.creatComLib.Name = "creatComLib";
            this.creatComLib.Size = new System.Drawing.Size(148, 22);
            this.creatComLib.Text = "新建元件到库";
            this.creatComLib.Click += new EventHandler(creatComLib_Click);
            // 
            // addInterface
            // 
            this.addInterface.Name = "addInterface";
            this.addInterface.Size = new System.Drawing.Size(148, 22);
            this.addInterface.Text = "添加接口";
            this.addInterface.Click += new EventHandler(addInterface_Click);
            // 
            // DeleteComponent
            // 
            this.DeleteComponent.Name = "DeleteComponent";
            this.DeleteComponent.Size = new System.Drawing.Size(148, 22);
            this.DeleteComponent.Text = "删除元件";
            this.componentRightMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.DeleteComponent.Click += new EventHandler(DeleteComponent_Click);

        }
    }
}
