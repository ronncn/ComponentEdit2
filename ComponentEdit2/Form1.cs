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
        private Canvas canvasMain;
        private LibraryRead libraryRead = new LibraryRead();

        public MainForm()
        {
            InitializeComponent();
        }

        private void toolStripLeft_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //点击toolScriptLeft上面的项（Item）时候发生
            ToolStripButton item = (ToolStripButton)e.ClickedItem;
            if(item.Tag.ToString() == "com")
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
                foreach(ToolStripItem button in toolStripLeft.Items)
                {
                    if(button.GetType() == typeof(ToolStripButton))
                    {
                        ToolStripButton btn = (ToolStripButton)button;
                        btn.Checked = false;
                    }
                }
                item.Checked = true;
            }
        }

        private void 库ToolStripButton_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripButton button = (ToolStripButton)sender;
            this.panelLibrary.Visible = button.Checked;
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            this.元件库ToolStripButton.Checked = false;
            this.接口库ToolStripButton.Checked = false;
        }

        private void 网格ToolStripSplitButton_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            foreach(ToolStripMenuItem item in 网格ToolStripSplitButton.DropDownItems)
            {
                item.Checked = false;
                item.Image = null;
            }
            ToolStripMenuItem menuitem = (ToolStripMenuItem)e.ClickedItem;
            menuitem.Checked = true;
            menuitem.Image = Properties.Resources.Yes;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            canvasMain = new ComponentEdit2.Canvas(this.Canvas.Size);
            canvasMain.Click += new EventHandler(panel2_Click);
            this.Canvas.Controls.Add(canvasMain);
        }

        private void 放大ToolStripButton_Click(object sender, EventArgs e)
        {
            canvasMain.IncreaseMultiple();
        }

        private void 缩小ToolStripButton_Click(object sender, EventArgs e)
        {
            canvasMain.DecreaseMultiple();
        }

        private void 适应尺寸oolStripButton_Click(object sender, EventArgs e)
        {
            canvasMain.ResetMultiple();
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

        private void 元件库ToolStripButton_Click(object sender, EventArgs e)
        {
            this.label1.Text = "ComponentLibrary";
            string path = Directory.GetCurrentDirectory() + "\\Library\\ComponentLibrary";
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

                    imageListLibrary.Images.Add(libraryRead.GetIcon(path + "\\" + file.Name));
                    item.ImageIndex = index; 
                    
                    listView1.Items.Add(item);
                    index++;
                }
            }
        }

        private void 接口库ToolStripButton_Click(object sender, EventArgs e)
        {
            this.label1.Text = "InterfaceLibrary";
            string path = Directory.GetCurrentDirectory() + "/Library/InterfaceLibrary";
            libraryRead.ReadFileCollection(path);

            listView1.Clear();
            if (libraryRead.fileCollection != null)
            {
                foreach (FileInfo file in libraryRead.fileCollection)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = file.Name;
                    listView1.Items.Add(item);
                }
            }
        }

        private void 抓手ToolStripButton_Click(object sender, EventArgs e)
        {
            CanvasTool.Tool = CanvasToolStyle.Drag;
        }
        
        private void 撤销ToolStripButton_Click(object sender, EventArgs e)
        {
            this.canvasMain.Undo();
        }

        private void 恢复ToolStripButton_Click(object sender, EventArgs e)
        {
            this.canvasMain.Redo();
        }

        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            string path = Directory.GetCurrentDirectory() + "\\Library\\ComponentLibrary";
            ListViewItem listitem = (ListViewItem)e.Item;
            Component component = libraryRead.ReadComponentXml(path+"\\"+listitem.Text.ToString());
            this.listView1.DoDragDrop(component, DragDropEffects.Move);
        }

        private void Canvas_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Component)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void Canvas_DragDrop(object sender, DragEventArgs e)
        {
            //e.Data.GetData(typeof(Component));
            canvasMain._DragDrop(e);
        }
    }
}
