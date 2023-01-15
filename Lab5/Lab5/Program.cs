using System;

namespace Lab5 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph test = new Graph(300);

            test.generate_relations();
            //test.print_matrix();
            //Console.ReadLine();

            AntColony testColoy = new AntColony(15, 50, test);
            int l = testColoy.start_algo(3,3, 0.2);

            Console.WriteLine(l);
            for (int i = 0; i < testColoy.tbest.Count; i++)
            {
                Console.Write(testColoy.tbest[i].Num + " ");
            }
            Console.ReadLine();
        }
    }
}