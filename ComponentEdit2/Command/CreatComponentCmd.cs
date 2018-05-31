using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ComponentEdit2
{
    public class CreatComponentCmd : Command
    {
        private string path;
        private Point location;
        private Kernel kernel;
        public CreatComponentCmd(Kernel kernel, string path,Point p)
        {
            this.kernel = kernel;
            this.path = path;
            this.location = p;
        }

        Component component;
        public override void Execute()
        {
            component = new Component();
            LibraryRead.ReadComponentXml(path,component);
            component.Location = location;
            kernel.CreatElement(component);
        }

        public override void Undo()
        {
            kernel.RemoveElement(component);
        }
    }
}
