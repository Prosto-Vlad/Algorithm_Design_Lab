using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_algoritm
{
    internal class Generator
    {
        public void generate(int count_gig)
        {
            int one_gig = 262144;
            using (BinaryWriter writer = new BinaryWriter(File.Open("UnsortedFille.txt", FileMode.OpenOrCreate)))
            {
                Random rnd = new Random();
                Byte[] b = new Byte[4096];
                for (int i = 0; i < count_gig*one_gig; i++)
                {
                    rnd.NextBytes(b);
                    writer.Write(b);
                }
                Console.WriteLine("Numbers genered!");
            }
        }
    }
}
