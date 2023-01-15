using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab5
{
    class Node
    {
        private int weight = 0;
        private int num;


        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        public int Num
        {
            get { return num; }
            set { num = value; }
        }

        public Node(Node node)
        {
            this.weight = node.weight;
        }

        public Node(int weight)
        {
            this.weight = weight;
        }
    }
}
