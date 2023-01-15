using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Lab1_algoritm
{
    internal class SimpleMergeSort
    {
        public void divideInTwoFiles(string path, string tempPathB, string tempPathC)
        {
            BinaryReader readA = new BinaryReader(new FileStream(path, FileMode.Open));
            BinaryWriter TempB = new BinaryWriter(File.Open(tempPathB, FileMode.OpenOrCreate));
            BinaryWriter TempC = new BinaryWriter(File.Open(tempPathC, FileMode.OpenOrCreate));
            int count = 0;
            int curr, prev = readA.ReadInt32();
            while (readA.BaseStream.Position != readA.BaseStream.Length)
            {
                curr = readA.ReadInt32();
                if (count % 2 == 0)
                {
                    if (prev <= curr)
                    {
                        TempB.Write(prev);
                        prev = curr;
                    }
                    else
                    {
                        TempB.Write(prev);
                        prev = curr;
                        count++;
                    }
                }
                else
                {
                    if (prev <= curr)
                    {
                        TempC.Write(prev);
                        prev = curr;
                    }
                    else
                    {
                        TempC.Write(prev);
                        prev = curr;
                        count++;
                    }
                }
            }
            readA.Close();
            TempB.Close();
            TempC.Close();
        }

        public bool isSorted(string path)
        {
            BinaryReader readA = new BinaryReader(File.Open(path, FileMode.Open));
            int prev = readA.ReadInt32();
            int curr = readA.ReadInt32();
            while (readA.BaseStream.Position != readA.BaseStream.Length)
            {
                if (prev > curr)
                {
                    readA.Close();
                    return false;
                }

                prev = curr;
                curr = readA.ReadInt32();
            }
            readA.Close();
            return true;
        }

        public void merge(string path, string tempB, string tempC)
        {
            BinaryReader readerB = new BinaryReader(File.Open(tempB, FileMode.Open));
            BinaryReader readerC = new BinaryReader(File.Open(tempC, FileMode.Open));
            BinaryWriter writeA = new BinaryWriter(File.Open(path, FileMode.Truncate));

            int prevB, prevC;
            int currB = readerB.ReadInt32();
            int currC = readerC.ReadInt32();

            while (true)
            {
                if (readerB.BaseStream.Position == readerB.BaseStream.Length)
                {
                    while (readerC.BaseStream.Position != readerC.BaseStream.Length)
                    {
                        writeA.Write(readerC.ReadInt32());
                    }
                    break;
                }
                if (readerC.BaseStream.Position == readerC.BaseStream.Length)
                {
                    while (readerB.BaseStream.Position != readerB.BaseStream.Length)
                    {
                        writeA.Write(readerB.ReadInt32());
                    }
                    break;
                }

                if (currB >= currC)
                {
                    writeA.Write(currC);

                    prevC = currC;
                    currC = readerC.ReadInt32();

                    if (prevC > currC && readerB.BaseStream.Position != readerB.BaseStream.Length)
                    {
                        do
                        {
                            writeA.Write(currB);
                            prevB = currB;
                            currB = readerB.ReadInt32();
                        } while (prevB <= currB && readerB.BaseStream.Position != readerB.BaseStream.Length);
                    }
                }
                else
                {
                    writeA.Write(currB);

                    prevB = currB;
                    currB = readerB.ReadInt32();

                    if (prevB > currB && readerC.BaseStream.Position != readerC.BaseStream.Length)
                    {
                        do
                        {
                            writeA.Write(currC);
                            prevC = currC;
                            currC = readerC.ReadInt32();
                        } while (prevC <= currC && readerC.BaseStream.Position != readerC.BaseStream.Length);
                    }
                }
            }
            readerB.Close();
            readerC.Close();
            writeA.Close();

            File.Delete(tempC);
            File.Delete(tempB);
        }
    }
}
