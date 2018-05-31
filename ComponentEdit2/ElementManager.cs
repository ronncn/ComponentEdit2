using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentEdit2
{
    [Serializable]
    public class ElementManager
    {
        public List<Component> listComponents = new List<Component>();  //元件的列表
        public List<Interface> listInterfaces = new List<Interface>();  //接口的列表
        public List<Network> listNetwork = new List<Network>();         //网络的列表

        public Element activeElement;                                   //选中的元素
        public List<Element> listActive = new List<Element>();          //选中的元素列表（元件、接口、链路）
        
        //选中画布上的元件、接口、网络
        public Element SelectElementInWhere(Point pt)
        {
            if(listComponents.Count == 0)
                return null;
            //遍历的所有元件的列表
            foreach(Component com in listComponents)
            {
                Rectangle rect = new Rectangle(com.LeftTopPoint,com.Size);
                Rectangle rectCom = new Rectangle(com.LeftTopPoint,com.Size);
                //这个地方应该判断接口最大的尺寸，增加最大尺寸。
                if(com.listInterface.Count != 0)
                    rect.Inflate(com.listInterface.Last<Interface>().Size);
                //判断点击的坐标是否在元件加接口的矩形中内
                if(rect.Contains(pt))
                {
                    //判断坐标是否在元件本身上
                    if(rectCom.Contains(pt))
                    {
                        activeElement = com;
                        return activeElement;
                    }
                    else if(com.listInterface.Count != 0)
                    {
                        foreach(Interface inf in com.listInterface)
                        {
                            Point leftTopPoint2 = new Point(com.Location.X + inf.Location.X, com.Location.Y + inf.Location.Y);
                            Rectangle rectInf = new Rectangle(leftTopPoint2, inf.Size);
                            if(rectInf.Contains(pt))
                            {
                                activeElement = inf;
                                return activeElement;
                            }
                        }
                    }
                }
            }
            //遍历网络的列表
            foreach(Network net in listNetwork)
            {
                for(int n = 0; n <= net.path.PointCount / 2; n += 2)
                {
                    if(GetPointIsInLine(pt,net.path.PathPoints[n],net.path.PathPoints[n+1],10))
                    {
                        activeElement = net;
                        return activeElement;
                    }
                }
            }
            activeElement = null;
            return activeElement;
        }

        //判断点是否在直线上
        private bool GetPointIsInLine(Point pf, PointF p1, PointF p2, double range)
        {
            //range 判断的的误差，不需要误差则赋值0
            
            //点在线段首尾两端之外则return false

            double cross = (p2.X - p1.X) * (pf.X - p1.X) + (p2.Y - p1.Y) * (pf.Y - p1.Y);
            if (cross <= 0) return false;
            double d2 = (p2.X - p1.X) * (p2.X - p1.X) + (p2.Y - p1.Y) * (p2.Y - p1.Y);
            if (cross >= d2) return false;
            
            double r = cross / d2;
            double px = p1.X + (p2.X - p1.X) * r;
            double py = p1.Y + (p2.Y - p1.Y) * r;

            //判断距离是否小于误差
            return Math.Sqrt((pf.X - px) * (pf.X - px) + (py - pf.Y) * (py - pf.Y)) <= range;
        }

        //添加元素
        public void AddElement(Element element)
        {
            if(element.GetType() == typeof(Component))
            {
                Component com = (Component)element;
                listActive.Clear();
                if (listComponents.Count == 0)
                    com.Id = 0;
                else
                    com.Id = listComponents.Last<Component>().Id + 1;

                listComponents.Add(com);
                activeElement = com;
            }
            else if(element.GetType() == typeof(Interface))
            {
                Interface inf = (Interface)element;
                listActive.Clear();
                if (listInterfaces.Count == 0)
                    inf.Id = 0;
                else
                    inf.Id = listInterfaces.Last<Interface>().Id + 1;
                inf.Name = "Inf-" + inf.Id.ToString();
                listInterfaces.Add(inf);
                activeElement = inf;
            }
            else if(element.GetType() == typeof(Network))
            {
                Network net = (Network)element;
                listActive.Clear();
                if (listNetwork.Count == 0)
                    net.Id = 0;
                else
                    net.Id = listNetwork.Last<Network>().Id + 1;
                net.Name = "Net-" + net.Id;
                Random r = new Random();
                Color c = Color.FromKnownColor((KnownColor)r.Next(1, 167));
                net.Attdisp.backColor = c;
                listNetwork.Add(net);
                activeElement = net;
            }
            else
            {
                listActive.Clear();
                activeElement = null;
            }
        }

        //删除一个元素
        public void RemoveElement(Element element)
        {
            if(element.GetType() == typeof(Component))
            {
                Component com = (Component)element;
                foreach(Interface inf in com.listInterface)
                {
                    com.RemoveInf(inf);
                }
                foreach(Element ele in com.listChildren)
                {
                    RemoveElement(ele);
                }
                listComponents.Remove(com);
            }
            else if(element.GetType() == typeof(Interface))
            {
                Interface inf = (Interface)element;
                inf.Parent.RemoveInf(inf);
                listInterfaces.Remove(inf);
            }
            else if(element.GetType() == typeof(Network))
            {
                Network net = (Network)element;
                foreach(Interface inf in net.listInf)
                {
                    inf.Network = null;
                }
                listNetwork.Remove(net);
            }
            activeElement = null;
        }
    }
}
