using Microsoft.Msagl.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    class Graph
    { 
        private int size;
        private int[,] matrix;
        private List<Node> nodes = new List<Node>();
        private int crhome_num;

        public List<Node> Nodes
        {
            get {
                List<Node> list = new List<Node>();
                for (int i = 0; i < nodes.Count; i++)
                {
                    list.Add(nodes[i]);
                }
                return list;
            }
            set { nodes = value; }
        }
        public int[,] Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }
        public int Size
        {
            get { return size; }
            set { size = value; }
        }
        public int Crhome_num
        {
            get { return crhome_num; }
            set { crhome_num = value; }
        }

        private bool IsRelated(int first, int second)
        {
            if (matrix[first, second] == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool IsEnd()
        {
            int count = 0;

            for (int i = 0; i < size; i++)
            {
                count = 0;
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i,j] == 0)
                    {
                        count++;
                    }
                }
                if (count >= size-2)
                {
                    return false;
                }
            }

            return true;
        }

        public Graph()
        {

        }

        public Graph(Graph cop)
        {
            this.size = cop.Size;
            this.matrix = cop.Matrix;
            this.crhome_num = cop.Crhome_num;
            for (int i = 0; i < cop.Nodes.Count; i++)
            {
                Node node = new Node(cop.nodes[i]);
                this.nodes.Add(node);
            }
        }
        public Graph(int size)
        {
            matrix = new int[size, size];
            this.size = size;
            crhome_num = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = 0;
                }
            }

            for (int i = 0; i < size; i++)
            {
                Node temp = new Node(0);
                nodes.Add(temp);
            }
        }

        /*
        public void print_matrix()
        {
            Console.Write("   ");
            for (int i = 0; i < size; i++)
            {
                if (nodes[i].Color != null)
                {
                    Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), nodes[i].Color, true);
                }
                if (i >= 10)
                {
                    Console.Write(i + " ");
                }
                else
                {
                    Console.Write("0" + i + " ");
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine();

            for (int i = 0; i < size; i++)
            {
                if (i >= 10)
                {
                    Console.Write(i + " ");
                }
                else
                {
                    Console.Write(i + "  ");
                }
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i,j] == 0)
                    {
                        Console.Write(" 0 ");
                    }
                    else
                    {
                        Console.Write(" " + matrix[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        */
        public int getSize()
        {
            return size;
        }

        public void add_relation(int first, int secod)
        {
            matrix[first, secod] = 1;
            nodes[first].Weight++;
            matrix[secod, first] = 1;
            nodes[secod].Weight++;
        }

        public void generate_relations()
        {
            bool end = false;
            Random rand = new Random();
            int first, second;

            while(!end)
            {
                first = rand.Next(0, size);
                second = rand.Next(0, size);

                if (first != second && !IsRelated(first, second))
                {
                    add_relation(first, second);
                }

                if (IsEnd())
                {
                    end = true;
                }
            }


        }

        public List<Node> FindRelate(Node node)
        {
            List<Node> nodes = new List<Node>();
            int num = Nodes.IndexOf(node);
            for (int i = 0; i < Size; i++)
            {
                if (Matrix[num, i] == 1)
                {
                    nodes.Add(Nodes[i]);
                }
            }
            return nodes;
        }
    }
}
