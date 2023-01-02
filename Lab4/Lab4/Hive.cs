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
        private Graph graph;

        private int free_bees;
        private int ranger_bees;
        private List<Color> AllColor = new List<Color>();
        private List<Color> UsedColor = new List<Color>();
        private Color[] BestColor;

        private int max_crhome_num;
        private int max_iter;
        private int best_chrom;

        public Hive( int max_iter, int all_bees,int ranger_bees, ref Graph graph, List<Color> col, int max_crhome_num = int.MaxValue)
        {
            this.max_crhome_num = max_crhome_num;
            this.max_iter = max_iter;

            this.free_bees = all_bees - ranger_bees;
            this.ranger_bees = ranger_bees;

            this.graph = graph;
            AllColor = col;

            BestColor = new Color[graph.Nodes.Count];
        }

        private bool IsUnicNode(Node unic, List<Node> ranger_nodes)
        {
            if (ranger_nodes.Count != 0)
            {
                foreach(Node node in ranger_nodes)
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
                if (graph.Matrix[num,i] == 1)
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

            /*
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
            */
            /*
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
            */
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
                if (iter%20 == 0)
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
            while(swaped) 
            {
                swaped = false;
                for (int i = 1; i < nodes.Count; i++)
                {
                    if (nodes[i].Weight > nodes[i-1].Weight)
                    {
                        swaped = true;
                        temp = nodes[i];
                        nodes[i] = nodes[i-1];
                        nodes[i-1] = temp;
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

    }
}
