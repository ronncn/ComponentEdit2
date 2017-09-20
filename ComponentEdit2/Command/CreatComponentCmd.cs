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
        Component _component;
        public CreatComponentCmd(Component com)
        {
            this._component = com;
        }

        public override void Execute()
        {

        }

        public override void Undo()
        {

        }
    }
}
