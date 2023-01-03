using System.IO;
using System.Diagnostics;
namespace Lab1_algoritm
{
    class Program
    {

        static void generete(string path, ulong size)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                int temp;
                Random rnd = new Random();
                for (ulong i = 0; i < size; i++)
                {
                    temp = rnd.Next(0, 1000);
                    writer.Write(temp);
                }
                Console.WriteLine("Numbers genered!");
            }
        }
        static void Main()
        {
            string path = "UnsortedFille.txt";
            string tempPathB = "TempFileB.txt";
            string tempPathC = "TempFileC.txt";
            int switcher;
            Console.WriteLine("How big file generate?\n1 - 10 mb\n2 - 1 gb\n3 - 32 gb");
            switcher = Convert.ToInt32(Console.ReadLine());

            switch(switcher)
            {
                case 1:
                    generete(path, 2621440);
                    break;
                case 2:
                    generete(path, 268435456);
                    break;
                case 3:
                    generete(path, 38654705664);
                    break;
            }

            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();
            SimpleMergeSort merge = new SimpleMergeSort();

            while (!merge.isSorted(path))
            {

                merge.divideInTwoFiles(path, tempPathB, tempPathC);
                merge.merge(path, tempPathB, tempPathC);
            }

            Console.WriteLine("File sorted!");
            Console.WriteLine("Show first 1000 numbers?\n1 - yes\n2 - no");
            switcher=Convert.ToInt32(Console.ReadLine());
            if (switcher == 1)
            {
                BinaryReader readA = new BinaryReader(new FileStream(path, FileMode.Open));
                for (int i = 0; i < 1000; i++)
                {
                    Console.Write(readA.ReadInt32());
                    Console.Write(", ");
                }
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }
    }
}



