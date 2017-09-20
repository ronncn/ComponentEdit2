using System;
using System.Collections.Generic;
using System.Drawing;

namespace ComponentEdit2
{
    public class Interface : Element
    {
        public List<Link> listLink;

        public Interface()
        {
            listLink = new List<Link>();
        }

        public override void Display(Graphics g)
        {

        }

        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
}
