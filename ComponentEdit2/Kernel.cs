using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Collections.Generic;

namespace ComponentEdit2
{
    public class Kernel
    {
        private enum SelectToolInWhere { Blank, Component, Interface, Network }

        private Bitmap finalBitmap;                 //完成的图像
        private Bitmap selectBitmap;                //选中的图像
        private Bitmap tempBitmap;                  //临时的图像
        private Graphics gShow;                     //用于显示的画布
        private Graphics gSelect;                   //用于选择的画布
        private Graphics gTemp;                     //临时显示的画布
        public ElementManager elementManager;
        private Component activeComponent;
        private Element active;

        private SelectToolInWhere SelectedToolInWhere;
        private bool isInTemp = false;

        public Kernel()
            : this(new Size(400, 300))
        { }

        public Kernel(Size bitmapSize)
            : this(new Bitmap(bitmapSize.Width, bitmapSize.Height))
        { }

        public Kernel(Bitmap bitmap)
        {
            this.finalBitmap = bitmap;
            gShow = Graphics.FromImage(finalBitmap);
            InitialValue();
        }

        private void InitialValue()
        {
            gShow.SmoothingMode = SmoothingMode.HighQuality;
            selectBitmap = (Bitmap)finalBitmap.Clone();
            tempBitmap = (Bitmap)finalBitmap.Clone();
            gSelect = Graphics.FromImage(selectBitmap);
            gTemp = Graphics.FromImage(tempBitmap);
            elementManager = new ElementManager();
        }

        public void DrawFinalBitmap()
        {
            gShow.Clear(Color.Transparent);
            gSelect.Clear(Color.Transparent);
            foreach (Component com in elementManager.listComponents)
            {
                com.Display(gShow);
            }
            foreach(Network net in elementManager.listNetwork)
            {
                net.Display(gShow);
            }
            if(elementManager.listActive.Count == 0)
            {
                this.DrawBound(elementManager.activeElement);
            }
            else
            {
                foreach (Component com in elementManager.listActive)
                    DrawBound(com);
            }
            gShow.DrawImage(selectBitmap, 0, 0);
            OnCanvasPaint();
        }

        //绘制元素的选中时候的边框。
        private void DrawBound(Element element)
        {
            if (element == null)
            {
                gSelect.Clear(Color.Transparent);
                return;
            }
            if (element.GetType() == typeof(Component))
            {
                Component component = (Component)element;
                Rectangle rect = new Rectangle(new Point(component.Location.X - component.Width / 2,
                    component.Location.Y - component.Height / 2), component.Size);
                gSelect.DrawRectangle(Pens.Red, rect);
            }
            else if(element.GetType() == typeof(Interface))
            {
                Interface inf = (Interface)element;
                Rectangle rect = new Rectangle(new Point(inf.Parent.Location.X + inf.Location.X,
                    inf.Parent.Location.Y + inf.Location.Y), inf.Size);
                gSelect.DrawRectangle(Pens.Red, rect);
            }
            else if(element.GetType() == typeof(Network))
            {
                Network network = (Network)element;

                //选中网络时候简单的蚂蚁线，自定义线型。需要选中时带选中框。
                Pen pen = new Pen(Color.Black,2);
                pen.DashPattern = new float[] { 2, 5 };
                pen.DashStyle = DashStyle.Custom;

                gSelect.DrawPath(pen, network.path);
            }
        }

        //框选方法，并显示选中框。
        private void RectSelect(Point pt1, Point pt2)
        {
            int min_x, min_y, width, height;
            if (pt1.X < pt2.X) { min_x = pt1.X; } else { min_x = pt2.X; }
            if (pt1.Y < pt2.Y) { min_y = pt1.Y; } else { min_y = pt2.Y; }
            width = Math.Abs(pt1.X - pt2.X);
            height = Math.Abs(pt1.Y - pt2.Y);
            elementManager.listActive.Clear();
            Rectangle rect = new Rectangle(new Point(min_x, min_y), new Size(width, height));
            foreach(Component com in elementManager.listComponents)
            {
                Rectangle rectCom = new Rectangle(new Point(com.Location.X - com.Width / 2, com.Location.Y - com.Height / 2),
                    com.Size);
                if (rect.IntersectsWith(rectCom))
                {
                    elementManager.listActive.Add(com);
                }
            }
            DrawRectSelect(rect);
        }

        //绘制框选选中框。（临时）
        private void DrawRectSelect(Rectangle rect)
        {
            gTemp.Clear(Color.Transparent);
            Pen pen = new Pen(Color.Black);
            pen.DashStyle = DashStyle.Dot;
            gTemp.DrawRectangle(pen, rect);
            pen.Dispose();
        }

        #region 私有的方法

        private Point mouseDownLocation;
        private bool MovingToDetermine = false;


        private void Select_MouseDown(Point pt)
        {
            Element element = elementManager.SelectElementInWhere(pt);
            active = element;
            gSelect.Clear(Color.Transparent);
            elementManager.listActive.Clear();
            if(element == null)
            {
                SelectedToolInWhere = SelectToolInWhere.Blank;
                activeComponent = null;
                isInTemp = true;
            }
            else if(element.GetType() == typeof(Component))
            {
                SelectedToolInWhere = SelectToolInWhere.Component;
                activeComponent = (Component)element;
                isInTemp = true;
            }
            else if(element.GetType() == typeof(Interface))
            {
                SelectedToolInWhere = SelectToolInWhere.Interface;
            }
            else if(element.GetType() == typeof(Network))
            {
                SelectedToolInWhere = SelectToolInWhere.Network;
            }
            else
            {
                SelectedToolInWhere = SelectToolInWhere.Blank;
                activeComponent = null;
                isInTemp = true;
            }
        }

        private void Select_MouseMove(Point pt)
        {
            switch (SelectedToolInWhere)
            {
                case SelectToolInWhere.Blank:
                    if (isInTemp)
                    {
                        RectSelect(mouseDownLocation, pt);
                        OnCanvasPaint();
                    }
                    break;
                case SelectToolInWhere.Component:
                    if (isInTemp)
                    {
                        if(Math.Abs(pt.X - mouseDownLocation.X) > 0 || Math.Abs(pt.Y - mouseDownLocation.Y) > 0)
                        {
                            this.MoveFlaseComponent(pt, mouseDownLocation);
                            this.MovingToDetermine = true;
                            OnCanvasPaint();
                        }
                    }
                    break;
            }

        }

        private void Select_MouseUp(Point pt)
        {
            switch (SelectedToolInWhere)
            {
                case SelectToolInWhere.Blank:
                    isInTemp = false;
                    break;
                case SelectToolInWhere.Component:
                    if(MovingToDetermine)
                    {
                        MovingToDetermine = false;
                        Point p = new Point(pt.X - mouseDownLocation.X, pt.Y - mouseDownLocation.Y);
                        this.MoveComponent(p);
                    }
                    isInTemp = false;
                    OnCanvasPaint();
                    break;
                case SelectToolInWhere.Interface:
                    break;
                case SelectToolInWhere.Network:
                default:
                    break;
            }
            this.DrawFinalBitmap();
        }

        #endregion


        #region 公开的方法
        
        Interface firstInf = null;
        Interface lastInf = null;
        //鼠标按下函数
        public void Mouse_Down(Point pt)
        {
            mouseDownLocation = pt;
            switch(CanvasTool.Tool)
            {
                case CanvasToolStyle.Select:
                    this.Select_MouseDown(pt);
                    break;
                case CanvasToolStyle.Connect:
                    Element element = elementManager.SelectElementInWhere(pt);
                    if (element != null && element.GetType() == typeof(Interface))
                    {
                        if (firstInf == null)
                        {
                            firstInf = (Interface)element;
                            isInTemp = true;
                        }
                        else
                        {
                            lastInf = (Interface)element;
                            Network net;
                            if (firstInf.Network == null && lastInf.Network == null)
                            {
                                net = new Network();
                                net.listInf.Add(firstInf);
                                net.listInf.Add(lastInf);
                                firstInf.Network = net;
                                lastInf.Network = net;
                                elementManager.AddElement(net);
                            }
                            else if(firstInf.Network == null && lastInf.Network != null)
                            {
                                net = lastInf.Network;
                                net.listInf.Add(firstInf);
                                firstInf.Network = net;
                            }
                            else if(firstInf != null && lastInf.Network == null)
                            {
                                net = firstInf.Network;
                                net.listInf.Add(lastInf);
                                lastInf.Network = net;
                            }
                            else
                            {
                                if(firstInf.Network != lastInf.Network)
                                {
                                    net = firstInf.Network;
                                    elementManager.RemoveElement(lastInf.Network);
                                    foreach (Interface Inf in lastInf.Network.listInf)
                                    {
                                        net.listInf.Add(Inf);
                                        Inf.Network = net;
                                    }
                                }
                                else
                                {
                                    firstInf = null;
                                    lastInf = null;
                                    MessageBox.Show("接口在同一网络中，不需要连接");
                                }
                            }
                            isInTemp = false;
                        }
                    }
                    break;
                case CanvasToolStyle.Text:
                    break;
                default:
                    break;
            }
        }

        public void Mouse_Move(Point pt)
        {
            switch (CanvasTool.Tool)
            {
                case CanvasToolStyle.Select:
                    this.Select_MouseMove(pt);
                    break;
                case CanvasToolStyle.Connect:
                    if(isInTemp)
                    {
                        gTemp.Clear(Color.Transparent);
                        gTemp.DrawLine(Pens.Red,new Point(firstInf.Parent.Location.X + firstInf.Location.X,
                            firstInf.Parent.Location.Y + firstInf.Location.Y),pt);
                        OnCanvasPaint();
                    }
                    break;
                case CanvasToolStyle.Text:
                    break;
                default:
                    break;
            }
        }

        public void Mouse_Up(Point pt)
        {
            switch (CanvasTool.Tool)
            {
                case CanvasToolStyle.Select:
                    this.Select_MouseUp(pt);
                    break;
                case CanvasToolStyle.Connect:
                    if(firstInf != null && lastInf != null)
                    {
                        gTemp.Clear(Color.Transparent);
                        firstInf.Network.Display(gShow);
                        OnCanvasPaint();
                        firstInf = null;
                        lastInf = null;
                    }
                    this.DrawFinalBitmap();
                    break;
                case CanvasToolStyle.Text:
                    break;
                default:
                    break;
            }
        }

        CommandManager cmdManager = new CommandManager();
        public void DragDrop(string path,Point location)
        {
            if(path.Contains(Directory.GetCurrentDirectory() + "\\Library\\ComponentLibrary"))
            {
                cmdManager.ExecuteCommand(new CreatComponentCmd(this, path, location));
            }
            else if(path.Contains(Directory.GetCurrentDirectory() + "\\Library\\InterfaceLibrary"))
            {
                Element element = elementManager.SelectElementInWhere(location);
                if(element.GetType() == typeof(Component))
                {
                    Component component = (Component)element;
                    cmdManager.ExecuteCommand(new CreatInterfaceCmd(this, path, location, component));
                }
            }
        }

        public void OnPaintComponent(Component component)
        {
            component.Display(gShow);
        }

        public void CreatElement(Element element)
        {
            this.elementManager.AddElement(element);
            element.Display(gShow);
        }

        public void RemoveElement(Element element)
        {
            this.elementManager.RemoveElement(element);
            DrawFinalBitmap();
        }

        //创建删除元素的方法，在方法中判断元素的类型，进行相应的删除操作。

        public void R()
        {
            DrawFinalBitmap();
        }

        public void Remove()
        {
            cmdManager.ExecuteCommand(new RemoveComponentCmd(this));
        }

        public void Redo()
        {
            cmdManager.RedoCommand();
        }

        public void Undo()
        {
            cmdManager.UndoCommand();
        }

        public void Save()
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = @"电子图纸|*.cpet";
            save.FilterIndex = 2;
            save.RestoreDirectory = true;
            if (save.ShowDialog() == DialogResult.OK)
            {
                FileStream fileStream = new FileStream(save.FileName, FileMode.Create);
                byte[] data = SerializeHelper.SerializeToBinary(elementManager);
                fileStream.Write(data, 0, data.Length);
                fileStream.Close();
            }
        }

        public void Open()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = @"电子图纸|*.cpet";
            open.RestoreDirectory = true;
            if (open.ShowDialog() == DialogResult.OK)
            {
                FileStream fileStream = new FileStream(open.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                int fsLen = (int)fileStream.Length;
                byte[] heByte = new byte[fsLen];
                fileStream.Read(heByte, 0, heByte.Length);
                this.elementManager = SerializeHelper.DeserializeWithBinary<ElementManager>(heByte);
                fileStream.Close();
            }
            DrawFinalBitmap();
        }

        public void MoveComponent(Point pt)
        {
            elementManager.activeElement.Move(pt);
            DrawFinalBitmap();
        }

        public void MoveFlaseComponent(Point p,Point start)
        {
            //需要做框选多项时，同时拖动。
            if (elementManager.activeElement == null)
                return;

            int width, height, min_X, min_Y, max_X, max_Y;
            width = this.elementManager.activeElement.Size.Width;
            height = this.elementManager.activeElement.Size.Height;
            min_X = this.elementManager.activeElement.Location.X - width / 2;
            min_Y = this.elementManager.activeElement.Location.Y - height / 2;
            max_X = this.elementManager.activeElement.Location.X + width / 2;
            max_Y = this.elementManager.activeElement.Location.Y + height / 2;
            Point point = new Point(p.X - (start.X-min_X), p.Y - (start.Y-min_Y));
            Rectangle rect = new Rectangle(point, new Size(width,height));
            gTemp.Clear(Color.Transparent);
            gTemp.DrawRectangle(Pens.Black, rect);
        }

        #endregion

        /// <summary>
        /// 绘制临时画布层
        /// </summary>
        /// <param name="g"></param>
        public void DrawTempLayer(Graphics g)
        {
            g.DrawImage(tempBitmap, 0, 0);
        }

        public delegate void CanvasPaintEventHandler();
        public event CanvasPaintEventHandler CanvasPaint;
        protected virtual void OnCanvasPaint()
        {
            if(CanvasPaint != null)
            {
                CanvasPaint();
            }
        }

        #region 公开的变量

        public Bitmap FinalBitmap
        {
            get { return finalBitmap; }
        }
        public Bitmap TempBitmap
        {
            get { return tempBitmap; }
        }

        public Component CheckedComponent
        {
            get { return activeComponent; }
        }

        public Element Active
        {
            get { return active; }
        }


        public bool IsInTemp
        {
            get { return isInTemp; }
        }

        #endregion
    }
}
