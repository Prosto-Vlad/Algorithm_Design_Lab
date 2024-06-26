﻿using System;
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
        private int num;
        
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
