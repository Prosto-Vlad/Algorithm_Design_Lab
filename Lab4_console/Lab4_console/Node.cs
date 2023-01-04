using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab4_console
{
    class Node
    {
        private int weight = 0;
        private int color = -1;
        private int num;


        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        public int Color
        {
            get { return color; }
            set { color = value; }
        }
        public int Num
        {
            get { return num; }
            set { num = value; }
        }

        public Node(Node node)
        {
            this.weight = node.weight;
            this.color = node.color;
        }

        public Node(int weight)
        {
            this.weight = weight;
        }
    }
}
