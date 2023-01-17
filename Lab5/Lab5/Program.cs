using System;

namespace Lab5 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph test = new Graph(300);

            test.generate_relations();
           // test.print_matrix();
            //Console.ReadLine();

            for (int i = 1; i <= 9; i++)
            {
                AntColony testColoy = new AntColony(5, 25, test, 1500);
                int l = testColoy.start_algo(2, 2, (double)i/10);

                Console.WriteLine("Q = " + (double)i /10);
                Console.WriteLine(l);
                //for (int j = 0; j < testColoy.tbest.Count; j++)
                //{
                //    Console.Write(testColoy.tbest[j].Num + " ");
                //}
                Console.WriteLine();
                
            }
            Console.ReadLine();
            //AntColony testColoy = new AntColony(5, 25, test, 300);
            //int l = testColoy.start_algo(3,3, 0.2);

            //Console.WriteLine(l);
            //for (int i = 0; i < testColoy.tbest.Count; i++)
            //{
            //    Console.Write(testColoy.tbest[i].Num + " ");
            //}
            //Console.ReadLine();
        }
    }
}