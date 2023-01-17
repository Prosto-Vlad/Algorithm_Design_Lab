using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    internal class AntColony
    {
        Graph graph;

        List<Ant> ants = new List<Ant>();
        List<Node> Tbest = new List<Node>();
        private double[,] pher_matrix;
        private double[,] visib_matrix;
        private int antCount;
        private int A;
        private int B;
        private double Q;
        private int Lbest; 
        private int Lmin;
        private int time;

        public List<Node> tbest
        {
            get { return Tbest; }
        }

        public AntColony(int antCount, int time, Graph graph, int lmin)
        {
            this.antCount = antCount;
            for (int i = 0; i < antCount; i++)
            {
                Ant temp = new Ant();
                ants.Add(temp);
            }
            this.time = time;
            this.graph = graph;

            pher_matrix = new double[graph.Size, graph.Size];
            visib_matrix = new double[graph.Size, graph.Size];
            this.Lmin = lmin;
        }

        private bool isUnicNode(int ant_num)
        {
            for (int j = 0; j < antCount; j++)
            {
                if (ants[ant_num].node == ants[j].node && ant_num != j)
                {
                    return false;
                }
            }
            return true;
        }

        public int start_algo(int A, int B, double Q)
        {
            this.A = A;
            this.B = B;
            this.Q = Q;

            for (int i = 0; i < graph.Size; i++)
            {
                for (int j = 0; j < graph.Size; j++)
                {
                    if (j != i)
                    {
                        visib_matrix[i, j] = 1 / graph.Matrix[i, j];

                        pher_matrix[i, j] = (double)new Random().Next(1, 5) / 10;
                    }
                }
            }

            Lbest = int.MaxValue;

            List<int> start = new List<int>();
            for (int i = 0; i < antCount; i++)
            {
                do
                {
                    ants[i].node = new Random().Next(graph.Size);
                } while (!isUnicNode(i));
                start.Add(ants[i].node);
            }

            int iter = 0;
            //List<Node> Tt = new List<Node>();
            //int Lt = 0;
            while (iter <= time)
            {
                foreach (Ant ant in ants)
                {
                    makeTravel(ant);
                }

                int temp = ants[0].Lenght;
                int best = 0;
                for (int i = 1; i < antCount; i++)
                {
                    if (ants[i].Lenght < temp)
                    {
                        temp = ants[i].Lenght;
                        best = i;
                    }
                }

                if (temp < Lbest)
                {
                    Lbest = temp;

                    Tbest.Clear();
                    for (int i = 0; i < ants[best].memory.Count; i++)
                    {
                        Tbest.Add(ants[best].memory[i]);
                    }
                }

                //Console.Write(Lbest + " ");
                //Console.WriteLine();
                updPher(ants, Lmin);
                for (int i = 0; i < antCount; i++)
                {
                    ants[i].memory.Clear();
                    ants[i].Lenght = 0;
                    ants[i].node = start[i];
                }
                iter++;
            }

            return Lbest;
        }

        private void updPher(List<Ant> ants, int Lmin)
        {
            double tu;
            foreach (Ant ant in ants)
            {
                tu = Lmin / ant.Lenght;

                for (int i = 0; i < ant.memory.Count-1; i++)
                {
                    pher_matrix[ant.memory[i].Num, ant.memory[i + 1].Num] = (1 - Q) * pher_matrix[ant.memory[i].Num, ant.memory[i + 1].Num] + tu;
                }
                pher_matrix[ant.memory[ant.memory.Count - 1].Num, ant.memory[0].Num] = (1 - Q) * pher_matrix[ant.memory[ant.memory.Count - 1].Num, ant.memory[0].Num] + tu;
            }
        }

        private List<Node> findFreeNode(Ant ant)
        {
            List<Node> res = new List<Node>();

            for (int i = 0; i < graph.Nodes.Count; i++)
            {
                if (ant.memory.IndexOf(graph.Nodes[i]) == -1 && ant.node != i)
                {
                    res.Add(graph.Nodes[i]);
                }
            }

            return res;
        }

        private double Esum(List<Node> list, int from)
        {
            double res = 0;

            for (int i = 0; i < list.Count; i++)
            {
                res += Math.Pow(A, pher_matrix[from, list[i].Num]) * Math.Pow(B, visib_matrix[from, list[i].Num]);
            }

            return res;
        }

        private double findP(int from, int to, double E)
        {
            double res;

            res = (Math.Pow(A, pher_matrix[from, to]) * Math.Pow(B, visib_matrix[from, to])) / E;

            return res;
        }

        private int makeChoice(double[] P)
        {
            double chank = 0;
            double res = new Random().NextDouble();

            for (int i = 0; i < P.Length; i++)
            {
                if (res > chank && res <= chank + P[i])
                {

                    return i;
                }
                chank += P[i];
            }
            return 0;
        }

        private void makeTravel(Ant ant)
        {
            //List<Node> res = new List<Node>();
            //res.Add(graph.Nodes[ant.node]);

            while (ant.memory.Count < graph.Nodes.Count)
            {
                List<Node> freeNode = findFreeNode(ant);
                if (freeNode.Count == 0)
                {
                    ant.memory.Add(graph.Nodes[ant.node]);
                    ant.Lenght += graph.Matrix[ant.memory[ant.memory.Count - 1].Num, ant.memory[0].Num];
                    break;
                }
                double[] P = new double[freeNode.Count];
                for (int i = 0; i < freeNode.Count; i++)
                {
                    P[i] = findP(ant.node, freeNode[i].Num, Esum(freeNode, ant.node));
                }

                int next = freeNode[makeChoice(P)].Num;
                ant.Lenght += graph.Matrix[ant.node, next];
                //res.Add(graph.Nodes[next]);
                ant.memory.Add(graph.Nodes[ant.node]);
                ant.node = next;
            }
        }

        private int greedy()
        {
            int index = 0;
            int cur = 0;
            int L = 0;
            List<int> mem = new List<int>();
            while (index < graph.Size)
            {
                
                List<int> rel_cost = new List<int>();
                List<int> rel_index = new List<int>();
                for (int i = 0; i < graph.Size; i++)
                {
                    
                    if (mem.IndexOf(i) == -1 && cur != i)
                    {
                        rel_cost.Add(graph.Matrix[cur, i]);
                        rel_index.Add(i);
                    }
                }
                if (rel_cost.Count == 0)
                    break;
                L += rel_cost.Min();

                cur = rel_index[rel_cost.IndexOf(rel_cost.Min())];
                mem.Add(cur);
                index++;
            }
            return L;
        }
    }
}
