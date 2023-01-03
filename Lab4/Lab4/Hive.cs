using Microsoft.Msagl.Core.Layout;
//using Microsoft.Msagl.Drawing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Hive
    {
        private Graph initialGraph;
        private Graph graph;

        private int free_bees;
        private int ranger_bees;
        private List<Color> AllColor = new List<Color>();
        private List<Color> UsedColor = new List<Color>();
        private List<Node> UnUsedNodes = new List<Node>();
        //private Color[] BestColor;

        private int max_crhome_num;
        private int max_iter;
        //private int best_chrom;

        public Hive(int max_iter, int all_bees, int ranger_bees, ref Graph graph, Graph inGraph, List<Color> col, int max_crhome_num = int.MaxValue)
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

        public string ABC()
        {
            string chorm_history = "";
            int best_chrom_num = FindChromNum();
            chorm_history += best_chrom_num;
            ResetAlg();

            for (int i = 0; i < max_iter; i++)
            {
                int new_chrom = FindChromNum();
                if (new_chrom < best_chrom_num)
                {
                    best_chrom_num = new_chrom;
                    graph.Crhome_num = best_chrom_num;
                }
                if (i%20 == 0)
                {
                    chorm_history += ", " + best_chrom_num.ToString();
                }

                ResetAlg();
            }
            return chorm_history;
        }

        private int FindChromNum()
        {
            while (!IsGraphRightColored())
            {
                List<Node> RangerNodes = SendRangerBees();
                SendFreeBees(RangerNodes);
            }

            return UsedColor.Count;
        }

        private void SendFreeBees(List<Node> RangerNodes)
        {
            int[] WageRangerNodes = new int[RangerNodes.Count];
            for (int i = 0; i < WageRangerNodes.Length; i++)
            {
                WageRangerNodes[i] = graph.Nodes[graph.Nodes.IndexOf(RangerNodes[i])].Weight;
            }
            int[] FreeBeesSplit = SplitFreeBees(WageRangerNodes);


            for (int i = 0; i < RangerNodes.Count; i++)
            {
                int free_bees_for_node = FreeBeesSplit[i];
                List<Node> relates = graph.FindRelate(RangerNodes[i]);
                for (int j = 0; j < relates.Count; j++)
                {
                    if (j < free_bees_for_node)
                    {
                        ColorNode(relates[i]);
                    }
                }
                ColorNode(RangerNodes[i]);
            }
        }

        private void ColorNode(Node coloring)
        {
            List<Color> colors = new List<Color>();
            for (int i = 0; i < UsedColor.Count; i++)
            {
                colors.Add(UsedColor[i]);
            }

            bool isEnd = false;

            while (isEnd != true)
            {
                if (colors.Count == 0)
                {
                    UsedColor.Add(AllColor[UsedColor.Count]);

                    coloring.Color = AllColor[UsedColor.Count];
                    isEnd = true;
                }
                else
                {
                    Color NewColor = colors[0];
                    Color OldColor = coloring.Color;
                    coloring.Color = NewColor;
                    isEnd = true;

                    bool isValid = IsGraphRightColored();

                    if (!isValid)
                    {
                        coloring.Color = OldColor;
                        isEnd = false;
                    }

                    colors.Remove(NewColor);
                }
            }
        }

        private int[] SplitFreeBees(int[] wages)
        {
            double[] Nectar = GetNectar(wages);
            int[]   res = new int[Nectar.Length];
            int freeB = free_bees;
            for (int i = 0; i < Nectar.Length; i++)
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
            for (int i = 0; i < wages.Length; i++)
            {
                Nectar[i] = (double)wages[i] / total_wage;
            }
            return Nectar;
        }

        private List<Node> SendRangerBees()
        {
            List<Node> res = new List<Node>();

            for (int i = 0; i < ranger_bees; i++)
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
            for (int i = 0; i < graph.Size; i++)
            {
                for (int j = 0; j < graph.Size; j++)
                {
                    if (graph.Matrix[i,j] == 1 && graph.Nodes[i].Color != Color.Black && graph.Nodes[i].Color == graph.Nodes[j].Color)
                    {
                        return false;
                    }
                }
            }

            for (int i = 0; i < graph.Size; i++)
            {
                if (graph.Nodes[i].Color == Color.Black)
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

        
        /*
        private bool IsUnicNode(Node unic, List<Node> ranger_nodes)
        {
            if (ranger_nodes.Count != 0)
            {
                foreach (Node node in ranger_nodes)
                {
                    if (node == unic)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private List<Node> FindRelate(Node node)
        {
            List<Node> nodes = new List<Node>();
            int num = graph.Nodes.IndexOf(node);
            for (int i = 0; i < graph.Size; i++)
            {
                if (graph.Matrix[num, i] == 1)
                {
                    nodes.Add(graph.Nodes[i]);
                }
            }
            return nodes;
        }

        private void saveBestColor()
        {
            for (int i = 0; i < graph.Nodes.Count; i++)
            {
                BestColor[i] = graph.Nodes[i].Color;
            }

            best_chrom = graph.Crhome_num;
        }

        private void Color(Node cur)
        {
            List<Color> colors = new List<Color>();
            for (int i = 0; i < UsedColor.Count; i++)
            {
                colors.Add(UsedColor[i]);
            }

            bool isEnd = false;
            int index = 0;

            while (isEnd != true)
            {
                if (colors.Count == 0)
                {
                    UsedColor.Add(AllColor[UsedColor.Count]);

                    cur.Color = AllColor[UsedColor.Count];
                    isEnd = true;
                }
                else
                {
                    Color color = colors[0];
                    List<Node> relate = FindRelate(cur);
                    bool isValid = true;

                    foreach (Node rel in relate)
                    {
                        if (rel.Color == color)
                        {
                            isValid = false;
                        }
                    }

                    if (isValid)
                    {
                        cur.Color = color;
                        isEnd = true;
                    }

                    colors.Remove(color);
                    index++;
                }
            }

            //
            int color = 0;
            List<Node> nodes = FindRelate(cur);

            foreach (Node node in nodes)
            {
                if (AllColor[color] == node.Color)
                {
                    color++;
                }
            }

            if (UsedColor.Count > color && UsedColor.Count != 0)
            {
                cur.Color = UsedColor[color];
            }
            else
            {
                cur.Color = AllColor[color];
                UsedColor.Add(AllColor[color]);
            }
            //
            //
            List<Node> relate = FindRelate(cur);

            foreach (Node rel in relate)
            {
                int color = 0;
                List<Node> nodes = FindRelate(rel);

                foreach (Node node in nodes)
                {
                    if (AllColor[color] == node.Color)
                    {
                        color++;
                    }
                }

                if (UsedColor.Count >= color && UsedColor.Count != 0)
                {
                    rel.Color = UsedColor[color];
                }
                else
                {
                    rel.Color = AllColor[color];
                    UsedColor.Add(AllColor[color]);
                }
            }
            //
        }

        private bool IsColorUsed(Color color)
        {
            bool isUsed = false;
            for (int i = 0; i < graph.Nodes.Count; i++)
            {
                if (graph.Nodes[i].Color == color)
                {
                    isUsed = true;
                }
            }
            return isUsed;
        }

        private void refreshUsedColor()
        {
            List<Color> colors = new List<Color>();
            for (int i = 0; i < UsedColor.Count; i++)
            {
                colors.Add(UsedColor[i]);
            }

            for (int i = 0; i < colors.Count; i++)
            {
                if (!IsColorUsed(colors[i]))
                {
                    UsedColor.Remove(colors[i]);
                }
            }
        }

        public string ABC()
        {
            //Graph temp = new Graph();
            //temp = graph;
            int iter = 0;
            string hrom_histori = "";
            while (iter != max_iter)
            {
                Random rand = new Random();
                int num;

                int freeBees = free_bees;

                List<Node> ranger_nodes = new List<Node>();
                for (int i = 0; i < ranger_bees; i++)
                {
                    do
                    {
                        num = rand.Next(graph.Size);
                    } while (!IsUnicNode(graph.Nodes[num], ranger_nodes));

                    ranger_nodes.Add(graph.Nodes[num]);
                }

                foreach (Node node in ranger_nodes)
                {
                    if (freeBees == 0)
                    {
                        break;
                    }

                    List<Node> relates = FindRelate(node);
                    int needBees = Math.Min(relates.Count, freeBees);
                    freeBees -= needBees;
                    for (int i = 0; i < needBees; i++)
                    {
                        Color(relates[i]);
                    }

                    if (needBees == relates.Count)
                        Color(node);
                }

                refreshUsedColor();

                graph.Crhome_num = UsedColor.Count();

                //if (UsedColor.Count < best_chrom)
                //{
                //    saveBestColor();
                //}
                //else
                //{
                //    for (int i = 0; i < graph.Nodes.Count; i++)
                //    {
                //        graph.Nodes[i].Color = BestColor[i];
                //    }
                //    graph.Crhome_num = best_chrom;
                //}

                iter++;
                if (iter % 20 == 0)
                {
                    hrom_histori = hrom_histori + graph.Crhome_num.ToString() + ", ";
                }

            }

            return hrom_histori;

        }

        private List<Node> SortNodes(List<Node> nodes)
        {
            bool swaped = true;
            Node temp;
            while (swaped)
            {
                swaped = false;
                for (int i = 1; i < nodes.Count; i++)
                {
                    if (nodes[i].Weight > nodes[i - 1].Weight)
                    {
                        swaped = true;
                        temp = nodes[i];
                        nodes[i] = nodes[i - 1];
                        nodes[i - 1] = temp;
                    }
                }
            }
            return nodes;
        }

        public void greedy_color()
        {
            UsedColor.Clear();
            int uncolored_nodes = graph.Nodes.Count;
            graph.Nodes = SortNodes(graph.Nodes);

            int index = 0, colored = 0;

            while (uncolored_nodes > 0)
            {
                colored = 0;
                List<Node> relate = FindRelate(graph.Nodes[index]);

                foreach (Node node in relate)
                {
                    if (node.Color == System.Drawing.Color.Black)
                        colored++;
                    Color(node);
                }
                if (graph.Nodes[index].Color == System.Drawing.Color.Black)
                    colored++;
                Color(graph.Nodes[index]);
                index++;
                uncolored_nodes -= colored;
            }

            refreshUsedColor();
            graph.Crhome_num = UsedColor.Count;
            //saveBestColor();
        }

        */
    }
}
