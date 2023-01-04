using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab4_console;
class Program
{
    static void Main(string[] args)
    {
        List<int> AllColor = new List<int>();
        for (int i = 0; i < 1000; i++)
        {
            AllColor.Add(i);
        }

        Graph graph;
        Console.WriteLine("Graph size");
        int size;
        size = Convert.ToInt32(Console.ReadLine());
        graph = new Graph(size);
        graph.generate_relations();

        Console.WriteLine("Bee count");
        int bee;
        bee = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Ranger count");
        int ranger;
        ranger = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Iteration count");
        int iter;
        iter = Convert.ToInt32(Console.ReadLine());

        Hive hive = new Hive(iter, bee, ranger, ref graph, graph, AllColor);

        List<int> history = hive.ABC();

        for (int i = 0; i < history.Count; i++)
        {
            Console.Write("Iteration " + (i*20).ToString() + ": ");
            Console.WriteLine(history[i].ToString());
        }
        Console.WriteLine();

        //graph.print_matrix();

        Console.ReadLine();
    }
}




