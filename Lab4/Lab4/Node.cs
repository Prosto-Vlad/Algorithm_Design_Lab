using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.Msagl.Drawing;
using System.Drawing;

namespace Lab4
{
    class Node
    {
        private int weight = 0;
        private Color color = System.Drawing.Color.Black;
        private int p;
        
        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }
        public int P
        {
            get { return p; }
            set { p = value; }
        }

        public Node(int weight)
        {
            this.weight = weight;
        }
    }
}
