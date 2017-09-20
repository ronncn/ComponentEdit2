using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentEdit2
{
    public class ElementManager
    {
        private Graphics g;
        private Kernel kernel;

        public ElementManager(Kernel kernel, Graphics g)
        {
            this.g = g;
            this.kernel = kernel;
        }


        private List<Component> listComponents = new List<Component>();
        private List<Link> listLink = new List<Link>();

        private List<Element> listActive = new List<Element>();//选中的元素列表（元件、接口、链路）
        
        public void AddComponent(Component component)
        {
            listComponents.Add(component);
            component.Display(g);
            //当创建一个元件的时候，先清除选中列表，然后在将新添加的元件作为选中项
            listActive.Clear();
            listActive.Add(component);
        }

        public void AddComponent()
        {

        }

        public void RemoveComponent()
        {
            g.Clear(Color.Transparent);
            listComponents.Remove(listComponents.Last<Component>());

            foreach(Component com in listComponents)
            {
                com.Display(g);
            }
        }

        public void RemoveComponent(Component component)
        {
            g.Clear(Color.Transparent);
            listComponents.Remove(component);
            foreach (Component com in listComponents)
            {
                com.Display(g);
            }
        }

        public void AddLink(Link link)
        {
            listLink.Add(link);
        }
        public void RemoveLink(Link link)
        {
            listLink.Remove(link);
        }

        public void SelectComponent(Point point)
        {
            listActive.Clear();
            if (listComponents.Count != 0)
            {
                for(int i = 0;i < listComponents.Count; i++)
                {
                    Rectangle rect = new Rectangle(listComponents[i].DesignProperty.Location,
                        listComponents[i].DesignProperty.Size);
                    if (rect.Contains(point))
                    {
                        listActive.Add(listComponents[i]);
                    }
                }
            }
        }

        public void SelectComponent(Rectangle selectRect)
        {
            listActive.Clear();
            if (listComponents.Count != 0)
            {
                for(int i = 0; i < listComponents.Count; i++)
                {
                    Rectangle rect = new Rectangle(listComponents[i].DesignProperty.Location,
                        listComponents[i].DesignProperty.Size);
                    if(selectRect.IntersectsWith(rect))
                    {
                        listActive.Add(listComponents[i]);
                    }
                }
            }
        }

        public void SelectLink(Point point)
        {
            listActive.Clear();
            if (listLink.Count != 0)
            {
                for(int i = 0; i < listLink.Count; i++)
                {
                    GraphicsPath path = listLink[i].path;
                    if(path.IsVisible(point))
                    {
                        listActive.Add(listComponents[i]);
                    }
                }
            }
        }


    }
}
