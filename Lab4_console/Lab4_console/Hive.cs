using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_console
{
    class Hive
    {
        private Graph initialGraph;
        private Graph graph;
        private Graph best_graph;

        private int free_bees;
        private int ranger_bees;
        private List<int> AllColor = new List<int>();
        private List<int> UsedColor = new List<int>();
        private List<Node> UnUsedNodes = new List<Node>();
        //private Color[] BestColor;

        private int max_crhome_num;
        private int max_iter;
        //private int best_chrom;

        public Hive(int max_iter, int all_bees, int ranger_bees, ref Graph graph, Graph inGraph, List<int> col, int max_crhome_num = int.MaxValue)
        {
            this.max_crhome_num = max_crhome_num;
            this.max_iter = max_iter;

            this.free_bees = all_bees - ranger_bees;
            this.ranger_bees = ranger_bees;

            this.initialGraph = new Graph(inGraph);
            this.graph = graph;
            UnUsedNodes = this.graph.Nodes;
            AllColor = col;
        }

        public List<int> ABC()
        {
            List<int> chorm_history = new List<int>();
            int best_chrom_num = FindChromNum();
            best_graph = new Graph(graph);
            chorm_history.Add(best_chrom_num);
            ResetAlg();

            for (int i = 0; i < max_iter; ++i)
            {
                int new_chrom = FindChromNum();
                if (new_chrom < best_chrom_num)
                {
                    best_chrom_num = new_chrom;
                    best_graph = new Graph(graph);
                }
                if (i%20 == 0)
                {
                    chorm_history.Add(best_chrom_num);
                }

                ResetAlg();
            }

            graph = best_graph;
            return chorm_history;
        }

        private int FindChromNum()
        {
            while (!IsGraphRightColored())
            {
                List<Node> RangerNodes = SendRangerBees();
                SendFreeBees(RangerNodes);
            }
            graph.Crhome_num = UsedColor.Count;
            return UsedColor.Count;
        }

        private void SendFreeBees(List<Node> RangerNodes)
        {
            int[] WageRangerNodes = new int[RangerNodes.Count];
            for (int i = 0; i < WageRangerNodes.Length; ++i)
            {
                WageRangerNodes[i] = graph.Nodes[graph.Nodes.IndexOf(RangerNodes[i])].Weight;
            }
            int[] FreeBeesSplit = SplitFreeBees(WageRangerNodes);


            for (int i = 0; i < RangerNodes.Count; ++i)
            {
                int free_bees_for_node = FreeBeesSplit[i];
                List<Node> relates = graph.FindRelate(RangerNodes[i]);
                for (int j = 0; j < relates.Count; ++j)
                {
                    if (j < free_bees_for_node)
                    {
                        ColorNode(relates[j]);
                    }
                }
                ColorNode(RangerNodes[i]);
            }
        }

        private void ColorNode(Node coloring)
        {
            List<int> colors = new List<int>();
            for (int i = 0; i < UsedColor.Count; ++i)
            {
                colors.Add(UsedColor[i]);
            }

            bool isEnd = false;

            while (isEnd != true)
            {
                if (colors.Count == 0)
                {
                    int new_col = AllColor[UsedColor.Count];
                    UsedColor.Add(new_col);
                    coloring.Color = new_col;
                    break;
                }
                int NewColor = colors[0];
                int OldColor = coloring.Color;
                coloring.Color = NewColor;
                colors.Remove(NewColor);
                isEnd = true;

                bool isValid = true;
                List<Node> relates = graph.FindRelate(coloring);
                for (int i = 0; i < relates.Count; i++)
                {
                    if (coloring.Color == relates[i].Color && coloring.Color != -1 && relates[i].Color != -1)
                        isValid = false;
                }
         
                //for (int i = 0; i < graph.Size; ++i)
                //{
                //    for (int j = 0; j < graph.Size; ++j)
                //    {
                //        if (graph.Matrix[i, j] == 1 && graph.Nodes[i].Color != Color.Black && graph.Nodes[i].Color == graph.Nodes[j].Color)
                //        {
                //            isValid = false;
                //        }
                //    }
                //}

                if (!isValid)
                {
                    coloring.Color = OldColor;
                    isEnd = false;
                }
            }
        }

        private int[] SplitFreeBees(int[] wages)
        {
            double[] Nectar = GetNectar(wages);
            int[]   res = new int[Nectar.Length];
            int freeB = free_bees;
            for (int i = 0; i < Nectar.Length; ++i)
            {
                res[i] = (int)(Nectar[i] * freeB);
                freeB -= res[i];
            }
            return res;
        }

        private double[] GetNectar(int[] wages)
        {
            double[] Nectar = new double[wages.Length];
            int total_wage = wages.Sum();
            for (int i = 0; i < wages.Length; ++i)
            {
                Nectar[i] = (double)wages[i] / total_wage;
            }
            return Nectar;
        }

        private List<Node> SendRangerBees()
        {
            List<Node> res = new List<Node>();

            for (int i = 0; i < ranger_bees; ++i)
            {
                if (UnUsedNodes.Count == 0)
                {
                    continue;
                }

                int index = new Random().Next(UnUsedNodes.Count);
                res.Add(UnUsedNodes[index]);
                UnUsedNodes.RemoveAt(index);
            }
            return res;
        }

        private bool IsGraphRightColored()
        {
            for (int i = 0; i < graph.Size; ++i)
            {
                for (int j = 0; j < graph.Size; ++j)
                {
                    if (graph.Matrix[i,j] == 1 && graph.Nodes[i].Color != -1 && graph.Nodes[i].Color == graph.Nodes[j].Color)
                    {
                        return false;
                    }
                }
            }

            for (int i = 0; i < graph.Size; ++i)
            {
                if (graph.Nodes[i].Color == -1)
                {
                    return false;
                }
            }

            return true;
        }

        private void ResetAlg()
        {
            UsedColor.Clear();
            graph = new Graph(initialGraph);
            UnUsedNodes = new List<Node>(graph.Nodes);
        }

        
        
    }
}
