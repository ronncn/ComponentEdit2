namespace ComponentEdit2
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.撤销ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.恢复ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加元件到库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加接口到库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.视图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.元件库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.接口库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTop = new System.Windows.Forms.ToolStrip();
            this.新建ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.打开ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.保存ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.撤销ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.恢复ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.适应尺寸oolStripButton = new System.Windows.Forms.ToolStripButton();
            this.放大ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.缩小ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.属性ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.网格ToolStripSplitButton = new System.Windows.Forms.ToolStripSplitButton();
            this.无网格ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.点状网格ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.线状网格ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.删除ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.保存 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripLeft = new System.Windows.Forms.ToolStrip();
            this.元件库ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.接口库ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.选择ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.连线ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.抓手ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.文字ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.panelLibrary = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageListLibrary = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Canvas = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.toolStripTop.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStripLeft.SuspendLayout();
            this.panelLibrary.SuspendLayout();
            this.panel1.SuspendLayout();
            this.Canvas.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.编辑ToolStripMenuItem,
            this.视图ToolStripMenuItem,
            this.库ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1350, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建ToolStripMenuItem,
            this.打开ToolStripMenuItem,
            this.保存ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 新建ToolStripMenuItem
            // 
            this.新建ToolStripMenuItem.Name = "新建ToolStripMenuItem";
            this.新建ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.新建ToolStripMenuItem.Text = "新建";
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.打开ToolStripMenuItem.Text = "打开";
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.保存ToolStripMenuItem.Text = "保存";
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.撤销ToolStripMenuItem,
            this.恢复ToolStripMenuItem,
            this.添加元件到库ToolStripMenuItem,
            this.添加接口到库ToolStripMenuItem});
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.编辑ToolStripMenuItem.Text = "编辑";
            // 
            // 撤销ToolStripMenuItem
            // 
            this.撤销ToolStripMenuItem.Name = "撤销ToolStripMenuItem";
            this.撤销ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.撤销ToolStripMenuItem.Text = "撤销";
            // 
            // 恢复ToolStripMenuItem
            // 
            this.恢复ToolStripMenuItem.Name = "恢复ToolStripMenuItem";
            this.恢复ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.恢复ToolStripMenuItem.Text = "恢复";
            // 
            // 添加元件到库ToolStripMenuItem
            // 
            this.添加元件到库ToolStripMenuItem.Name = "添加元件到库ToolStripMenuItem";
            this.添加元件到库ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.添加元件到库ToolStripMenuItem.Text = "添加元件到库";
            // 
            // 添加接口到库ToolStripMenuItem
            // 
            this.添加接口到库ToolStripMenuItem.Name = "添加接口到库ToolStripMenuItem";
            this.添加接口到库ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.添加接口到库ToolStripMenuItem.Text = "添加接口到库";
            // 
            // 视图ToolStripMenuItem
            // 
            this.视图ToolStripMenuItem.Name = "视图ToolStripMenuItem";
            this.视图ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.视图ToolStripMenuItem.Text = "视图";
            // 
            // 库ToolStripMenuItem
            // 
            this.库ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.元件库ToolStripMenuItem,
            this.接口库ToolStripMenuItem});
            this.库ToolStripMenuItem.Name = "库ToolStripMenuItem";
            this.库ToolStripMenuItem.Size = new System.Drawing.Size(32, 21);
            this.库ToolStripMenuItem.Text = "库";
            // 
            // 元件库ToolStripMenuItem
            // 
            this.元件库ToolStripMenuItem.Name = "元件库ToolStripMenuItem";
            this.元件库ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.元件库ToolStripMenuItem.Text = "元件库";
            // 
            // 接口库ToolStripMenuItem
            // 
            this.接口库ToolStripMenuItem.Name = "接口库ToolStripMenuItem";
            this.接口库ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.接口库ToolStripMenuItem.Text = "接口库";
            // 
            // toolStripTop
            // 
            this.toolStripTop.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolStripTop.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.toolStripTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建ToolStripButton,
            this.打开ToolStripButton,
            this.保存ToolStripButton,
            this.toolStripSeparator1,
            this.撤销ToolStripButton,
            this.恢复ToolStripButton,
            this.toolStripSeparator2,
            this.适应尺寸oolStripButton,
            this.放大ToolStripButton,
            this.缩小ToolStripButton,
            this.toolStripSeparator3,
            this.属性ToolStripButton,
            this.网格ToolStripSplitButton,
            this.toolStripSeparator5,
            this.删除ToolStripButton});
            this.toolStripTop.Location = new System.Drawing.Point(0, 25);
            this.toolStripTop.Name = "toolStripTop";
            this.toolStripTop.Size = new System.Drawing.Size(1350, 35);
            this.toolStripTop.TabIndex = 1;
            this.toolStripTop.Text = "toolStrip1";
            // 
            // 新建ToolStripButton
            // 
            this.新建ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.新建ToolStripButton.Image = global::ComponentEdit2.Properties.Resources.New_clip_art;
            this.新建ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.新建ToolStripButton.Name = "新建ToolStripButton";
            this.新建ToolStripButton.Padding = new System.Windows.Forms.Padding(5);
            this.新建ToolStripButton.Size = new System.Drawing.Size(32, 32);
            this.新建ToolStripButton.Text = "新建";
            // 
            // 打开ToolStripButton
            // 
            this.打开ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.打开ToolStripButton.Image = global::ComponentEdit2.Properties.Resources.Open_v2;
            this.打开ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.打开ToolStripButton.Name = "打开ToolStripButton";
            this.打开ToolStripButton.Padding = new System.Windows.Forms.Padding(5);
            this.打开ToolStripButton.Size = new System.Drawing.Size(32, 32);
            this.打开ToolStripButton.Text = "打开";
            // 
            // 保存ToolStripButton
            // 
            this.保存ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.保存ToolStripButton.Image = global::ComponentEdit2.Properties.Resources.Save;
            this.保存ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.保存ToolStripButton.Name = "保存ToolStripButton";
            this.保存ToolStripButton.Padding = new System.Windows.Forms.Padding(5);
            this.保存ToolStripButton.Size = new System.Drawing.Size(32, 32);
            this.保存ToolStripButton.Text = "保存";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Padding = new System.Windows.Forms.Padding(5);
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 35);
            // 
            // 撤销ToolStripButton
            // 
            this.撤销ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.撤销ToolStripButton.Image = global::ComponentEdit2.Properties.Resources.Undo;
            this.撤销ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.撤销ToolStripButton.Name = "撤销ToolStripButton";
            this.撤销ToolStripButton.Padding = new System.Windows.Forms.Padding(5);
            this.撤销ToolStripButton.Size = new System.Drawing.Size(32, 32);
            this.撤销ToolStripButton.Text = "撤销";
            this.撤销ToolStripButton.Click += new System.EventHandler(this.撤销ToolStripButton_Click);
            // 
            // 恢复ToolStripButton
            // 
            this.恢复ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.恢复ToolStripButton.Image = global::ComponentEdit2.Properties.Resources.Redo;
            this.恢复ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.恢复ToolStripButton.Name = "恢复ToolStripButton";
            this.恢复ToolStripButton.Padding = new System.Windows.Forms.Padding(5);
            this.恢复ToolStripButton.Size = new System.Drawing.Size(32, 32);
            this.恢复ToolStripButton.Text = "恢复";
            this.恢复ToolStripButton.ToolTipText = "恢复";
            this.恢复ToolStripButton.Click += new System.EventHandler(this.恢复ToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Padding = new System.Windows.Forms.Padding(5);
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 35);
            // 
            // 适应尺寸oolStripButton
            // 
            this.适应尺寸oolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.适应尺寸oolStripButton.Image = global::ComponentEdit2.Properties.Resources.Zoom;
            this.适应尺寸oolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.适应尺寸oolStripButton.Name = "适应尺寸oolStripButton";
            this.适应尺寸oolStripButton.Padding = new System.Windows.Forms.Padding(5);
            this.适应尺寸oolStripButton.Size = new System.Drawing.Size(32, 32);
            this.适应尺寸oolStripButton.Text = "适应尺寸";
            this.适应尺寸oolStripButton.Click += new System.EventHandler(this.适应尺寸oolStripButton_Click);
            // 
            // 放大ToolStripButton
            // 
            this.放大ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.放大ToolStripButton.Image = global::ComponentEdit2.Properties.Resources.Zoom_in;
            this.放大ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.放大ToolStripButton.Name = "放大ToolStripButton";
            this.放大ToolStripButton.Padding = new System.Windows.Forms.Padding(5);
            this.放大ToolStripButton.Size = new System.Drawing.Size(32, 32);
            this.放大ToolStripButton.Text = "放大";
            this.放大ToolStripButton.Click += new System.EventHandler(this.放大ToolStripButton_Click);
            // 
            // 缩小ToolStripButton
            // 
            this.缩小ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.缩小ToolStripButton.Image = global::ComponentEdit2.Properties.Resources.Zoom_out;
            this.缩小ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.缩小ToolStripButton.Name = "缩小ToolStripButton";
            this.缩小ToolStripButton.Padding = new System.Windows.Forms.Padding(5);
            this.缩小ToolStripButton.Size = new System.Drawing.Size(32, 32);
            this.缩小ToolStripButton.Text = "缩小";
            this.缩小ToolStripButton.Click += new System.EventHandler(this.缩小ToolStripButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Padding = new System.Windows.Forms.Padding(5);
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 35);
            // 
            // 属性ToolStripButton
            // 
            this.属性ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.属性ToolStripButton.Image = global::ComponentEdit2.Properties.Resources.Info;
            this.属性ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.属性ToolStripButton.Name = "属性ToolStripButton";
            this.属性ToolStripButton.Padding = new System.Windows.Forms.Padding(5);
            this.属性ToolStripButton.Size = new System.Drawing.Size(32, 32);
            this.属性ToolStripButton.Text = "属性";
            this.属性ToolStripButton.ToolTipText = "属性";
            // 
            // 网格ToolStripSplitButton
            // 
            this.网格ToolStripSplitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.网格ToolStripSplitButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.无网格ToolStripMenuItem,
            this.点状网格ToolStripMenuItem,
            this.线状网格ToolStripMenuItem});
            this.网格ToolStripSplitButton.Image = global::ComponentEdit2.Properties.Resources.Grid;
            this.网格ToolStripSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.网格ToolStripSplitButton.Name = "网格ToolStripSplitButton";
            this.网格ToolStripSplitButton.Padding = new System.Windows.Forms.Padding(5);
            this.网格ToolStripSplitButton.Size = new System.Drawing.Size(44, 32);
            this.网格ToolStripSplitButton.Text = "网格";
            this.网格ToolStripSplitButton.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.网格ToolStripSplitButton_DropDownItemClicked);
            // 
            // 无网格ToolStripMenuItem
            // 
            this.无网格ToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.无网格ToolStripMenuItem.Name = "无网格ToolStripMenuItem";
            this.无网格ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.无网格ToolStripMenuItem.Tag = "Null";
            this.无网格ToolStripMenuItem.Text = "无网格";
            this.无网格ToolStripMenuItem.Click += new System.EventHandler(this.无网格ToolStripMenuItem_Click);
            // 
            // 点状网格ToolStripMenuItem
            // 
            this.点状网格ToolStripMenuItem.Name = "点状网格ToolStripMenuItem";
            this.点状网格ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.点状网格ToolStripMenuItem.Tag = "Dot";
            this.点状网格ToolStripMenuItem.Text = "点状网格";
            this.点状网格ToolStripMenuItem.Click += new System.EventHandler(this.点状网格ToolStripMenuItem_Click);
            // 
            // 线状网格ToolStripMenuItem
            // 
            this.线状网格ToolStripMenuItem.Checked = true;
            this.线状网格ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.线状网格ToolStripMenuItem.Image = global::ComponentEdit2.Properties.Resources.Yes;
            this.线状网格ToolStripMenuItem.Name = "线状网格ToolStripMenuItem";
            this.线状网格ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.线状网格ToolStripMenuItem.Tag = "Line";
            this.线状网格ToolStripMenuItem.Text = "线状网格";
            this.线状网格ToolStripMenuItem.Click += new System.EventHandler(this.线状网格ToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Padding = new System.Windows.Forms.Padding(5);
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 35);
            // 
            // 删除ToolStripButton
            // 
            this.删除ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.删除ToolStripButton.Image = global::ComponentEdit2.Properties.Resources.Erase;
            this.删除ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.删除ToolStripButton.Name = "删除ToolStripButton";
            this.删除ToolStripButton.Padding = new System.Windows.Forms.Padding(5);
            this.删除ToolStripButton.Size = new System.Drawing.Size(32, 32);
            this.删除ToolStripButton.Text = "删除";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存});
            this.statusStrip1.Location = new System.Drawing.Point(0, 707);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1350, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // 保存
            // 
            this.保存.BackColor = System.Drawing.Color.Transparent;
            this.保存.Name = "保存";
            this.保存.Size = new System.Drawing.Size(32, 17);
            this.保存.Text = "保存";
            // 
            // toolStripLeft
            // 
            this.toolStripLeft.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolStripLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStripLeft.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripLeft.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.元件库ToolStripButton,
            this.接口库ToolStripButton,
            this.toolStripSeparator4,
            this.选择ToolStripButton,
            this.连线ToolStripButton,
            this.抓手ToolStripButton,
            this.文字ToolStripButton});
            this.toolStripLeft.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStripLeft.Location = new System.Drawing.Point(0, 60);
            this.toolStripLeft.Name = "toolStripLeft";
            this.toolStripLeft.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.toolStripLeft.Size = new System.Drawing.Size(33, 647);
            this.toolStripLeft.TabIndex = 3;
            this.toolStripLeft.Text = "toolStrip2";
            this.toolStripLeft.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripLeft_ItemClicked);
            // 
            // 元件库ToolStripButton
            // 
            this.元件库ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.元件库ToolStripButton.Image = global::ComponentEdit2.Properties.Resources.Objects;
            this.元件库ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.元件库ToolStripButton.Margin = new System.Windows.Forms.Padding(1, 0, 2, 0);
            this.元件库ToolStripButton.Name = "元件库ToolStripButton";
            this.元件库ToolStripButton.Padding = new System.Windows.Forms.Padding(3);
            this.元件库ToolStripButton.Size = new System.Drawing.Size(29, 30);
            this.元件库ToolStripButton.Tag = "com";
            this.元件库ToolStripButton.Text = "元件库";
            this.元件库ToolStripButton.CheckedChanged += new System.EventHandler(this.库ToolStripButton_CheckedChanged);
            this.元件库ToolStripButton.Click += new System.EventHandler(this.元件库ToolStripButton_Click);
            // 
            // 接口库ToolStripButton
            // 
            this.接口库ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.接口库ToolStripButton.Image = global::ComponentEdit2.Properties.Resources.Registry;
            this.接口库ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.接口库ToolStripButton.Name = "接口库ToolStripButton";
            this.接口库ToolStripButton.Padding = new System.Windows.Forms.Padding(3);
            this.接口库ToolStripButton.Size = new System.Drawing.Size(32, 30);
            this.接口库ToolStripButton.Tag = "inf";
            this.接口库ToolStripButton.Text = "接口库";
            this.接口库ToolStripButton.CheckedChanged += new System.EventHandler(this.库ToolStripButton_CheckedChanged);
            this.接口库ToolStripButton.Click += new System.EventHandler(this.接口库ToolStripButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Padding = new System.Windows.Forms.Padding(3);
            this.toolStripSeparator4.Size = new System.Drawing.Size(32, 6);
            // 
            // 选择ToolStripButton
            // 
            this.选择ToolStripButton.Checked = true;
            this.选择ToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.选择ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.选择ToolStripButton.Image = global::ComponentEdit2.Properties.Resources.Mouse_pointer;
            this.选择ToolStripButton.ImageTransparentColor = System.Drawing.SystemColors.ActiveCaption;
            this.选择ToolStripButton.Name = "选择ToolStripButton";
            this.选择ToolStripButton.Padding = new System.Windows.Forms.Padding(3);
            this.选择ToolStripButton.Size = new System.Drawing.Size(32, 30);
            this.选择ToolStripButton.Tag = "select";
            this.选择ToolStripButton.Text = "选择";
            // 
            // 连线ToolStripButton
            // 
            this.连线ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.连线ToolStripButton.Image = global::ComponentEdit2.Properties.Resources.Curve_points;
            this.连线ToolStripButton.ImageTransparentColor = System.Drawing.SystemColors.ActiveCaption;
            this.连线ToolStripButton.Name = "连线ToolStripButton";
            this.连线ToolStripButton.Padding = new System.Windows.Forms.Padding(3);
            this.连线ToolStripButton.Size = new System.Drawing.Size(32, 30);
            this.连线ToolStripButton.Tag = "link";
            this.连线ToolStripButton.Text = "连线";
            // 
            // 抓手ToolStripButton
            // 
            this.抓手ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.抓手ToolStripButton.Image = global::ComponentEdit2.Properties.Resources.Move;
            this.抓手ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.抓手ToolStripButton.Name = "抓手ToolStripButton";
            this.抓手ToolStripButton.Padding = new System.Windows.Forms.Padding(3);
            this.抓手ToolStripButton.Size = new System.Drawing.Size(32, 30);
            this.抓手ToolStripButton.Tag = "move";
            this.抓手ToolStripButton.Text = "抓手";
            this.抓手ToolStripButton.Click += new System.EventHandler(this.抓手ToolStripButton_Click);
            // 
            // 文字ToolStripButton
            // 
            this.文字ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.文字ToolStripButton.Image = global::ComponentEdit2.Properties.Resources.Writing_pencil;
            this.文字ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.文字ToolStripButton.Name = "文字ToolStripButton";
            this.文字ToolStripButton.Padding = new System.Windows.Forms.Padding(3);
            this.文字ToolStripButton.Size = new System.Drawing.Size(32, 30);
            this.文字ToolStripButton.Tag = "text";
            this.文字ToolStripButton.Text = "文字";
            // 
            // panelLibrary
            // 
            this.panelLibrary.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelLibrary.Controls.Add(this.listView1);
            this.panelLibrary.Controls.Add(this.panel1);
            this.panelLibrary.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLibrary.Location = new System.Drawing.Point(33, 60);
            this.panelLibrary.Name = "panelLibrary";
            this.panelLibrary.Padding = new System.Windows.Forms.Padding(2);
            this.panelLibrary.Size = new System.Drawing.Size(210, 647);
            this.panelLibrary.TabIndex = 4;
            this.panelLibrary.Visible = false;
            // 
            // listView1
            // 
            this.listView1.AllowDrop = true;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.LargeImageList = this.imageListLibrary;
            this.listView1.Location = new System.Drawing.Point(2, 24);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.ShowItemToolTips = true;
            this.listView1.Size = new System.Drawing.Size(206, 621);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView1_ItemDrag);
            // 
            // imageListLibrary
            // 
            this.imageListLibrary.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListLibrary.ImageSize = new System.Drawing.Size(24, 24);
            this.imageListLibrary.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(206, 22);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // Canvas
            // 
            this.Canvas.AllowDrop = true;
            this.Canvas.Controls.Add(this.panel2);
            this.Canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Canvas.Location = new System.Drawing.Point(33, 60);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(1317, 647);
            this.Canvas.TabIndex = 5;
            this.Canvas.Click += new System.EventHandler(this.panel2_Click);
            this.Canvas.DragDrop += new System.Windows.Forms.DragEventHandler(this.Canvas_DragDrop);
            this.Canvas.DragEnter += new System.Windows.Forms.DragEventHandler(this.Canvas_DragEnter);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(1092, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 306);
            this.panel2.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Firebrick;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(182, 2);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(15, 15);
            this.button1.TabIndex = 0;
            this.button1.Text = "x";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.panelLibrary);
            this.Controls.Add(this.Canvas);
            this.Controls.Add(this.toolStripLeft);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStripTop);
            this.Controls.Add(this.menuStrip1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ComponentEdit2";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStripTop.ResumeLayout(false);
            this.toolStripTop.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStripLeft.ResumeLayout(false);
            this.toolStripLeft.PerformLayout();
            this.panelLibrary.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Canvas.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 视图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 库ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStripTop;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel 保存;
        private System.Windows.Forms.ToolStrip toolStripLeft;
        private System.Windows.Forms.ToolStripButton 新建ToolStripButton;
        private System.Windows.Forms.ToolStripButton 元件库ToolStripButton;
        private System.Windows.Forms.ToolStripButton 打开ToolStripButton;
        private System.Windows.Forms.ToolStripButton 保存ToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton 撤销ToolStripButton;
        private System.Windows.Forms.ToolStripButton 恢复ToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton 适应尺寸oolStripButton;
        private System.Windows.Forms.ToolStripButton 放大ToolStripButton;
        private System.Windows.Forms.ToolStripButton 缩小ToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton 属性ToolStripButton;
        private System.Windows.Forms.ToolStripButton 接口库ToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton 选择ToolStripButton;
        private System.Windows.Forms.ToolStripButton 连线ToolStripButton;
        private System.Windows.Forms.ToolStripButton 抓手ToolStripButton;
        private System.Windows.Forms.ToolStripButton 文字ToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton 删除ToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem 新建ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 撤销ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 恢复ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加元件到库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加接口到库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 元件库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 接口库ToolStripMenuItem;
        private System.Windows.Forms.Panel panelLibrary;
        private System.Windows.Forms.Panel Canvas;
        private System.Windows.Forms.ToolStripSplitButton 网格ToolStripSplitButton;
        private System.Windows.Forms.ToolStripMenuItem 无网格ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 点状网格ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 线状网格ToolStripMenuItem;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList imageListLibrary;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
    }
}

