using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Msagl.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Lab4
{
    public partial class Form1 : Form
    {
        Graph graph;
        Hive hive;
        List<System.Drawing.Color> AllColor = new List<System.Drawing.Color>();
        public Form1()
        {
            InitializeComponent();

            Random rand = new Random();
            System.Drawing.Color col;
            for (int i = 0; i < 1000; i++)
            {
                col = System.Drawing.Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
                if (AllColor.IndexOf(col) == -1 && col != System.Drawing.Color.Black)
                {
                    AllColor.Add(col);
                }
            }
        }

        private void Generate_button_Click(object sender, EventArgs e)
        {
            
            if (Graph_size.Text != "")
            {
                graph = new Graph(Convert.ToInt32(Graph_size.Text));
                Microsoft.Msagl.Drawing.Graph graphVis = new Microsoft.Msagl.Drawing.Graph();

                graph.generate_relations();

                for (int i = 0; i < graph.Size; i++)
                {
                    graphVis.AddNode((i).ToString()).Attr.Shape = Microsoft.Msagl.Drawing.Shape.Circle;
                }

                for (int i = 0; i < graph.Size; i++)
                {
                    for (int j = 0; j < graph.Size; j++)
                    {
                        if (graph.Matrix[i, j] == 1 && j >= i)
                        {
                            graphVis.AddEdge(i.ToString(), j.ToString()).Attr.ArrowheadAtTarget = Microsoft.Msagl.Drawing.ArrowStyle.None;
                        }
                    }
                }
                gViewer1.Graph = graphVis;
            }
            else
            {
                MessageBox.Show("Заповніть розмір графа");
            }
        }

        private void ABC_button_Click(object sender, EventArgs e)
        {
            if (iteration_box.Text != "" && gViewer1.Graph != null && bee_box.Text != "" && ranger_box.Text != "")
            {
                hrom_histori.Text = "";
                int iter = Convert.ToInt32(iteration_box.Text);
                int bees = Convert.ToInt32(bee_box.Text);
                int ranger = Convert.ToInt32(ranger_box.Text);
                hive = new Hive(iter, bees, ranger, ref graph, graph, AllColor);
                hrom_histori.Text = hive.ABC();

                int i = 0;
                foreach (var node in gViewer1.Graph.Nodes)
                {
                    if (graph.Nodes[i].Color != System.Drawing.Color.Black)
                    {
                        System.Drawing.Color c = graph.Nodes[i].Color;
                        node.Attr.FillColor = new Microsoft.Msagl.Drawing.Color((byte)c.R, (byte)c.G, (byte)c.B);
                        //node.LabelText = AllColor.IndexOf(c).ToString();

                    }
                    i++;
                }
                chrom_num.Text = graph.Crhome_num.ToString();
                 

                gViewer1.Refresh();

            }
        }
    }
}
