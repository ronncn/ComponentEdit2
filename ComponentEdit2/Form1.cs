using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ComponentEdit2
{
    public partial class MainForm : Form
    {
        private Canvas canvasMain;                              //画布主体
        private LibraryRead libraryRead = new LibraryRead();    //读取库操作
        private CanvasToolStyle tempStyle;                      //画布工具样式
        public MainForm()
        {
            InitializeComponent();
        }
        
        //工具按钮的点击
        private void toolStripLeft_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //点击toolScriptLeft上面的项（Item）时候发生
            ToolStripButton item;
            if (e.ClickedItem.GetType() == typeof(ToolStripButton))
            {
                item = (ToolStripButton)e.ClickedItem;
                if (item.Tag.ToString() == "com")
                {
                    接口库ToolStripButton.Checked = false;
                    item.Checked = !item.Checked;
                }
                else if (item.Tag.ToString() == "inf")
                {
                    元件库ToolStripButton.Checked = false;
                    item.Checked = !item.Checked;
                }
                else
                {
                    foreach (ToolStripItem button in toolStripLeft.Items)
                    {
                        if (button.GetType() == typeof(ToolStripButton))
                        {
                            ToolStripButton btn = (ToolStripButton)button;
                            btn.Checked = false;
                        }
                    }
                    item.Checked = true;
                }
            }
        }
        
        //库的关闭函数
        private void Cool_Close(object sender, EventArgs e)
        {
            this.元件库ToolStripButton.Checked = false;
            this.接口库ToolStripButton.Checked = false;
        }

        private void 库ToolStripButton_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripButton button = (ToolStripButton)sender;
            this.panelLibrary.Visible = button.Checked;
        }

        private void 元件库ToolStripButton_Click(object sender, EventArgs e)
        {
            this.label1.Text = "ComponentLibrary";

            this.GetLibraryList(this.label1.Text);
        }
        
        private void 接口库ToolStripButton_Click(object sender, EventArgs e)
        {
            this.label1.Text = "InterfaceLibrary";

            this.GetLibraryList(this.label1.Text);
        }
        
        //获得库的列表
        private void GetLibraryList(string lib)
        {
            string path = Directory.GetCurrentDirectory() + "\\Library\\" + lib;
            libraryRead.ReadFileCollection(path);

            listView1.Clear();
            imageListLibrary.Images.Clear();
            if (libraryRead.fileCollection != null)
            {
                int index = 0;
                foreach (FileInfo file in libraryRead.fileCollection)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = file.Name;

                    if(file.Name.IndexOf(".xml") > -1)
                    {
                        imageListLibrary.Images.Add(libraryRead.GetIcon(lib, path + "\\" + file.Name));
                        item.ImageIndex = index;

                        listView1.Items.Add(item);
                        index++;
                    }
                }
            }
        }

        //选择工具
        private void 选择ToolStripButton_Click(object sender, EventArgs e)
        {
            CanvasTool.Tool = CanvasToolStyle.Select;
        }

        //抓手工具
        private void 抓手ToolStripButton_Click(object sender, EventArgs e)
        {
            CanvasTool.Tool = CanvasToolStyle.Drag;
        }
        
        //连线工具
        private void 连线ToolStripButton_Click(object sender, EventArgs e)
        {
            CanvasTool.Tool = CanvasToolStyle.Connect;
        }

        //文字工具
        private void 文字ToolStripButton_Click(object sender, EventArgs e)
        {
            CanvasTool.Tool = CanvasToolStyle.Text;
        }

        //撤销工具
        private void 撤销ToolStripButton_Click(object sender, EventArgs e)
        {
            this.canvasMain.Undo();
        }

        //恢复工具
        private void 恢复ToolStripButton_Click(object sender, EventArgs e)
        {
            this.canvasMain.Redo();
        }

        //放大工具
        private void 放大ToolStripButton_Click(object sender, EventArgs e)
        {
            canvasMain.IncreaseMultiple();
        }

        //缩小工具
        private void 缩小ToolStripButton_Click(object sender, EventArgs e)
        {
            canvasMain.DecreaseMultiple();
        }

        //适应尺寸
        private void 适应尺寸oolStripButton_Click(object sender, EventArgs e)
        {
            canvasMain.ResetMultiple();
        }

        //网格工具
        private void 网格ToolStripSplitButton_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            foreach (ToolStripMenuItem item in 网格ToolStripSplitButton.DropDownItems)
            {
                item.Checked = false;
                item.Image = null;
            }
            ToolStripMenuItem menuitem = (ToolStripMenuItem)e.ClickedItem;
            menuitem.Checked = true;
            menuitem.Image = Properties.Resources.Yes;
        }

        private void 无网格ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            canvasMain.TransformGrid(GridStyle.Null);
        }

        private void 点状网格ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            canvasMain.TransformGrid(GridStyle.Dot);
        }

        private void 线状网格ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            canvasMain.TransformGrid(GridStyle.Line);
        }

        //删除工具
        private void 删除ToolStripButton_Click(object sender, EventArgs e)
        {
            canvasMain.Remove();
        }

        //保存文件
        private void 保存ToolStripButton_Click(object sender, EventArgs e)
        {
            canvasMain.Save();
        }

        //打开文件
        private void 打开ToolStripButton_Click(object sender, EventArgs e)
        {
            canvasMain.Open();
        }

        //属性按钮
        private void 属性ToolStripButton_Click(object sender, EventArgs e)
        {
            //canvasMain.OpenProperty();
            propertyPanel.Visible = !propertyPanel.Visible;
            propertyPanel.Controls.Add(canvasMain.Propertys);
        }

        //元件接口项的拖动
        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            string path = Directory.GetCurrentDirectory() + "\\Library\\" + this.label1.Text;
            ListViewItem listitem = (ListViewItem)e.Item;
            this.listView1.DoDragDrop(path + "\\" + listitem.Text.ToString(), DragDropEffects.Move);
        }

        private void Canvas_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(string)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void Canvas_DragDrop(object sender, DragEventArgs e)
        {
            canvasMain._DragDrop(e);
        }
        
        //主程序键盘按下事件
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            tempStyle = CanvasTool.Tool;   
            if ((Control.ModifierKeys & Keys.Alt) == Keys.Alt)
            {
                CanvasTool.Tool = CanvasToolStyle.Drag;
            }
        }

        //主程序键盘抬起事件
        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
             CanvasTool.Tool = tempStyle;
        }

        //主程序加载
        private void MainForm_Load(object sender, EventArgs e)
        {
            canvasMain = new ComponentEdit2.Canvas(Canvas.Size);
            canvasMain.Click += new EventHandler(Cool_Close);
            this.Canvas.Controls.Add(canvasMain);
        }
    }
}
